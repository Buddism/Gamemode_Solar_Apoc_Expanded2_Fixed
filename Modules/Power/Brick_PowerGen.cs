datablock AudioProfile(ManualCrankLoopSound)
{
   filename    = "./Sounds/Crank.wav";
   description = AudioCloseLooping3d;
   preload = true;
};

datablock fxDTSBrickData(brickEOTWManualCrankData)
{
	brickFile = "./Shapes/HandCrank.blb";
	category = "Solar Apoc";
	subCategory = "Power Gen";
	uiName = "Manual Crank";
	iconName = "Add-Ons/Gamemode_Solar_Apoc_Expanded2_Fixed/Modules/Power/Icons/ManualCrank";

    isPowered = true;
	powerType = "Source";
	inspectMode = 1;

	processSound = ManualCrankLoopSound;
};
$EOTW::CustomBrickCost["brickEOTWManualCrankData"] = 1.00 TAB "7a7a7aff" TAB 256 TAB "Iron" TAB 128 TAB "Copper" TAB 128 TAB "Lead";
$EOTW::BrickDescription["brickEOTWManualCrankData"] = "A basic device that allows power generation while activated, at the cost of your personal time.";

function brickEOTWManualCrankData::onTick(%this, %obj) {
    //Nothing!
}

function brickEOTWManualCrankData::onInspect(%this, %obj, %client) {
	if (getSimTime() - %obj.lastCrankTime[%client] >= 500)
	{
		%obj.lastCrankTime[%client] = getSimTime();
		%obj.changeBrickPower($EOTW::PowerLevel[0] >> 1);
	}
}

datablock AudioProfile(FueledBoilerLoopSound)
{
   filename    = "./Sounds/Boiler.wav";
   description = AudioCloseLooping3d;
   preload = true;
};

datablock fxDTSBrickData(brickEOTWFueledBoilerData)
{
	brickFile = "./Shapes/Boiler.blb";
	category = "Solar Apoc";
	subCategory = "Power Gen";
	uiName = "Fueled Boiler";
	iconName = "Add-Ons/Gamemode_Solar_Apoc_Expanded2_Fixed/Modules/Power/Icons/FueledBoiler";

    isPowered = true;
	powerType = "Source";
	isProcessingMachine = true;

	hasInventory = true;
    matterSize = 256;
	matterSlots["Input"] = 2;
	matterSlots["Output"] = 1;

	processSound = FueledBoilerLoopSound;
};
$EOTW::CustomBrickCost["brickEOTWFueledBoilerData"] = 1.00 TAB "7a7a7aff" TAB 256 TAB "Steel" TAB 256 TAB "Silver" TAB 256 TAB "Gold";
$EOTW::BrickDescription["brickEOTWFueledBoilerData"] = "Allows the controled boiling of water into steam. Requires burnable fuel (i.e. coal) and water.";

$EOTW::FueledBoilerThreshold = 256;
function brickEOTWFueledBoilerData::onTick(%this, %obj) {
	if (%obj.machineHeat < 1 && %obj.machineHeat < $EOTW::FueledBoilerThreshold)
	{
		for (%i = 0; %i < %this.matterSlots["Input"]; %i++)
		{
			%matter = getMatterType(getField(%obj.matter["Input", %i], 0));
			if (%matter.fuelPower > 0)
			{
				%amount = $EOTW::FueledBoilerThreshold - %obj.machineHeat;
				%burned = %obj.ChangeMatter(%matter.name, %amount * -1, "Input");
				
				%obj.machineHeat -= %burned * %matter.fuelPower;

				%obj.machineBonus = getMax(1.0, %matter.fuelMultiplier);
			}
		}
	}

	if (%obj.machineHeat > 0)
	{
		%obj.machineBonus = getMax(1.0, %obj.machineBonus);
		%convertCount = getMin(%obj.GetMatter("Water", "Input"), getMin(%obj.machineHeat, $EOTW::PowerLevel[0] * %obj.machineBonus));
		%obj.lastDrawTime = getSimTime();
		%obj.lastDrawSuccess = getSimTime();
		%obj.ChangeMatter("Water", %convertCount * -1, "Input");
		%obj.ChangeMatter("Steam", %convertCount, "Output");
		%obj.machineHeat -= %convertCount;

		if (isObject(%this.processSound))
		{
			if (!isObject(%obj.audioEmitter))
				%obj.playSoundLooping(%this.processSound);

			cancel(%obj.EndSoundsLoopSchedule);
			%obj.EndSoundsLoopSchedule = %obj.schedule($EOTW::PowerTickRate * 1.1, "playSoundLooping");
		}
	}
    
}

function brickEOTWFueledBoilerData::getProcessingText(%this, %obj) {
    return %obj.machineHeat > 0 ? "\c2Machine Heated" : "\c7Not fueled";
}

datablock fxDTSBrickData(brickEOTWSolarBoilerData)
{
	brickFile = "./Shapes/SolarPanel.blb";
	category = "Solar Apoc";
	subCategory = "Power Gen";
	uiName = "Solar Boiler";
	iconName = "Add-Ons/Gamemode_Solar_Apoc_Expanded2_Fixed/Modules/Power/Icons/SolarPanel";

    isPowered = true;
	powerType = "Source";
	isProcessingMachine = true;

	hasInventory = true;
    matterSize = 256;
	matterSlots["Input"] = 1;
	matterSlots["Output"] = 1;
};
$EOTW::CustomBrickCost["brickEOTWSolarBoilerData"] = 0.75 TAB "7a7a7aff" TAB 256 TAB "Adamantine" TAB 256 TAB "Quartz" TAB 256 TAB "Teflon";
$EOTW::BrickDescription["brickEOTWSolarBoilerData"] = "Allows the controled boiling of water into steam. Works during the day. Degrades overtime and must be replaced.";

function brickEOTWSolarBoilerData::onTick(%this, %obj) {

	if ($EOTW::Time > 12)
		return;

	%waterCount = %obj.GetMatter("Water", "Input");
    if (%waterCount > 0)
	{
		%obj.lastDrawTime = getSimTime();
		%obj.lastDrawSuccess = getSimTime();
		%amount = getMin(%waterCount, ($EOTW::PowerLevel[0] >> 2) * (1 - %obj.machineHeat));
		if (%amount - mFloor(%amount) > getRandom())
			%amount++;
		%obj.machineHeat = getMin(0.99, getMax(0.01, %obj.machineHeat * 1.00001));
		%obj.ChangeMatter("Water", %amount * -1, "Input");
		%obj.ChangeMatter("Steam", %amount, "Output");
	}
}

function brickEOTWSolarBoilerData::getProcessingText(%this, %obj) {
    return "Efficiency: " @ mRound(100 * (1 - %obj.machineHeat)) @ "\%";
}

datablock AudioProfile(SteamTurbineLoopSound)
{
   filename    = "./Sounds/Turbine.wav";
   description = AudioCloseLooping3d;
   preload = true;
};

datablock fxDTSBrickData(brickEOTWSteamTurbineData)
{
	brickFile = "./Shapes/SteamTurbine.blb";
	category = "Solar Apoc";
	subCategory = "Power Gen";
	uiName = "Steam Turbine";
	iconName = "Add-Ons/Gamemode_Solar_Apoc_Expanded2_Fixed/Modules/Power/Icons/SteamTurbine";

    isPowered = true;
	powerType = "Source";
	isProcessingMachine = true;

	hasInventory = true;
    matterSize = 256;
	matterSlots["Input"] = 1;
	matterSlots["Output"] = 1;

	processSound = SteamTurbineLoopSound;
};
$EOTW::CustomBrickCost["brickEOTWSteamTurbineData"] = 1.00 TAB "7a7a7aff" TAB 512 TAB "Steel" TAB 256 TAB "Copper" TAB 128 TAB "Lead";
$EOTW::BrickDescription["brickEOTWSteamTurbineData"] = "Generates power when inputted with steam. Continuous use will give a power bonus.";

function brickEOTWSteamTurbineData::getProcessingText(%this, %obj) {
    return "Bonus: " @ (1 + %obj.machineHeat) @ "x";
}

function brickEOTWSteamTurbineData::onTick(%this, %obj) {
	%steamCount = %obj.GetMatter("Steam", "Input");
	%bonusChange = 0.01;
    if (%steamCount > 0)
	{
		%obj.machineHeat = getMin(%obj.machineHeat + (%bonusChange * 2), 5);
		%obj.changeBrickPower(%steamCount * (1 + %obj.machineHeat));
		%obj.ChangeMatter("Steam", %steamCount * -1, "Input");
		%obj.ChangeMatter("Water", mFloor(%steamCount / 1.2), "Output");
	}
	else
	{
		%obj.machineHeat = getMax(%obj.machineHeat - %bonusChange, 0);
	}
}
