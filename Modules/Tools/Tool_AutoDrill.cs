$EOTW::ItemCrafting["AutoDrillItem"] = (128 TAB "Steel") TAB (64 TAB "Gold");
$EOTW::ItemDescription["AutoDrillItem"] = "An EU-powered drill which gathers a material for you. Base speed of 80%.";

datablock itemData(AutoDrillItem)
{
	uiName = "Auto-Drill I";
	iconName = "./Icons/icon_Drill";
	doColorShift = true;
	colorShiftColor = "0.10 0.10 0.10 1.00";
	
	shapeFile = "./Shapes/Drill.dts";
	image = AutoDrillImage;
	canDrop = true;
	
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;
	
	category = "Tools";
};

datablock shapeBaseImageData(AutoDrillImage)
{
	shapeFile = "./Shapes/Drill.dts";
	item = AutoDrillItem;
	
	mountPoint = 0;
	offset = "0 0.25 0.15";
	rotation = eulerToMatrix("0 5 70");
	
	eyeOffset = "0.75 1.15 -0.24";
	eyeRotation = eulerToMatrix("0 5 70");
	
	correctMuzzleVector = true;
	className = "WeaponImage";
	
	melee = false;
	armReady = true;

	doColorShift = AutoDrillItem.doColorShift;
	colorShiftColor = AutoDrillItem.colorShiftColor;
	
	stateName[0]					= "Start";
	stateTimeoutValue[0]			= 0.5;
	stateTransitionOnTimeout[0]	 	= "Ready";
	stateSound[0]					= weaponSwitchSound;
	
	stateName[1]					= "Ready";
	stateTransitionOnTriggerDown[1] = "Fire";
	stateAllowImageChange[1]		= true;
	
	stateName[2]					= "Fire";
	stateScript[2]					= "onFire";
	stateTimeoutValue[2]			= 0.1;
	stateAllowImageChange[2]		= false;
	stateTransitionOnTimeout[2]		= "checkFire";
	
	stateName[3]					= "checkFire";
	stateTransitionOnTriggerUp[3] 	= "Ready";
};

function AutoDrillImage::onFire(%this, %obj, %slot) { %obj.spawnDrill(%this, 0.8); }

datablock StaticShapeData(AutoDrillStatic)
{
    shapeFile = "./Shapes/Drill.dts";
};

function Player::spawnDrill(%obj, %image, %multiplier)
{
	//get the gatherable brick the player is looking at
	//Account thumpers but not gathering potion buff
	//Place drill and remove item from inventory

	if (!isObject(%client = %obj.client) || !isObject(%hit = %obj.whatBrickAmILookingAt()) || !%hit.isCollectable)
		return;

	if (%client.GetBatteryEnergy() == 0)
	{
		%client.chatMessage("\c6You need battery power to use this drill!");
		return;
	}

	if (%multiplier == 0)
		%multiplier = 1;

	%currSlot = %obj.currTool;
	%item = %obj.tool[%currSlot];
	%obj.tool[%currSlot] = 0;
	%obj.weaponCount--;
	messageClient(%obj.client,'MsgItemPickup','',%currSlot,0);
	serverCmdUnUseTool(%obj.client);

	%drill = new StaticShape()
	{
		datablock = AutoDrillStatic;
		client = %client;
		player = %obj;
		item = %item;
	};

	%hit.lastGatherTick = getSimTime();
	
	initContainerRadiusSearch(%hit.getPosition(), 64, $Typemasks::fxBrickAlwaysObjectType);
	while(isObject(%scan = containerSearchNext()))
		if(%scan.getClassName() $= "fxDtsBrick" && getSimTime() - %scan.lastThump < 1000)
			%multiplier++;

	%drill.setTransform(vectorAdd(%hit.getPosition(), "0 0 1"));
	%drill.setShapeNameDistance(64);
	%drill.schedule(16, "drillCollectLoop", %hit, %multiplier);
}

function StaticShape::drillCollectLoop(%obj, %brick, %multiplier)
{
	cancel(%obj.collectLoop);
	if(!isObject(%client = %obj.client) || !isObject(%player = %client.player)) return %obj.StopDrill();
	if(!isObject(%brick) || %brick.isDead()) return %obj.StopDrill();
	if(%brick && %brick.material !$= "")
	{
		if (!isObject(%brick.matterType))
			%brick.matterType = getMatterType(%brick.material);
			
		cancel(%brick.cancelCollecting);
		
		%reqFuel = %brick.matterType.requiredCollectFuel;
		%powerCost = mRound(-10 * %multiplier);
		if (%reqFuel !$= "" && %player.GetMatterCount(getField(%reqFuel, 0)) < getField(%reqFuel, 1))
		{
			%client.chatMessage("\c6You need atleast " @ getField(%reqFuel, 1) SPC getField(%reqFuel, 0) @ " to drill this " @ %brick.matterType.name @ "!");
			return %obj.StopDrill();
		}

		%change = %client.ChangeBatteryEnergy(%powerCost);
		if (%powerCost < %change)
		{
			%client.chatMessage("\c6You need more battery power to drill this " @ %brick.matterType.name @ "!");
			return %obj.StopDrill();
		}
		if (%brick.gatherProcess >= %brick.matterType.collectTime)
		{
			if (%reqFuel !$= "")
				%player.ChangeMatterCount(getField(%reqFuel, 0), getField(%reqFuel, 1) * -1);

			%oreValue = GetMatterValueData(%brick.matterType.name);
			if (%oreValue != -1)
				%client.incScore(getField(%oreValue, 1));
				
			$EOTW::Material[%client.bl_id, %brick.matterType.name] += %brick.matterType.spawnValue;
			%brick.killBrick();
			return %obj.StopDrill();
		}
		else
		{
			%brick.cancelCollecting = %brick.schedule(10000, "cancelCollecting");
			%brick.beingCollected = %client.bl_id;
			%obj.collectLoop = %obj.schedule(16, "drillCollectLoop", %brick, %multiplier);
			%obj.setShapeName(mFloor((%brick.gatherProcess / %brick.matterType.collectTime) * 100) @ "%");
			%brick.gatherProcess += (getSimTime() - %brick.lastGatherTick) * %multiplier;
			%brick.lastGatherTick = getSimTime();
		}
		
	}
}

function StaticShape::StopDrill(%obj)
{
	//Give player back the drill item
	//Drop it on the floor if there is no player found.
	
	%obj.delete();
	return 0;
}