function SetupMatterData()
{
	if (isObject(MatterData))
	{
		MatterData.deleteAll();
		MatterData.delete();
	}

	new SimSet(MatterData)
	{
		//Buildable Material
		new ScriptObject(MatterType) { name="Wood";			color="75502eff";	spawnWeight=30;	spawnVeinSize=8;	spawnValue=256;	collectTime=2000;	placable=true;	health=1.0;	heatCapacity=25;	meteorImmune=false;	gatherableDB="brickEOTWGatherableBasicData";	fuelPower=2;					helpText="A primitive, basic building material. High quanity but exceptionally low quality building material. Will burn on hotter days."; };
		new ScriptObject(MatterType) { name="Granite";		color="c1a872ff";	spawnWeight=60;	spawnVeinSize=4;	spawnValue=128;	collectTime=4000;	placable=true;	health=2.0;	heatCapacity=50;	meteorImmune=false;	gatherableDB="brickEOTWGatherableBasicData"; 									helpText="One of the few building materials. Will not melt in the sunlight but is still vulnerable to meteor strikes.";	};
		new ScriptObject(MatterType) { name="Iron";			color="7a7a7aff";	spawnWeight=40;	spawnVeinSize=6;	spawnValue=128;	collectTime=12000;	placable=true;	health=4.0;	heatCapacity=60;	meteorImmune=true;	gatherableDB="brickEOTWGatherableMetalData";									helpText="The bread and butter of civilization and technology. Can be used to build. Immune to meteors and sunlight.";	};
		new ScriptObject(MatterType) { name="Quartz";		color="181c26a8";	spawnWeight=20;	spawnVeinSize=3;	spawnValue=128;	collectTime=8000;	placable=true;	health=3.0;	heatCapacity=50;	meteorImmune=true;	gatherableDB="brickEOTWGatherableCrystalData"; 									helpText="Transparent building material, allowing transparent paint colors. Immune to both sunlight and meteors.";	};
		new ScriptObject(MatterType) { name="Sturdium";		color="646defff";	spawnWeight=02;	spawnVeinSize=2;	spawnValue=128;	collectTime=24000;	placable=true;	health=999;	heatCapacity=90;	meteorImmune=true;	gatherableDB="brickEOTWGatherableMetalData";									helpText="An ultra rare strange blue shaded metal with almost magic-like properties. Immune to meteors and sunlight and is used for high tier crafting.";	};
		//Growable Organics
		new ScriptObject(MatterType) { name="Moss";			color="446942ff";	spawnWeight=10;	spawnVeinSize=2;	spawnValue=128;	collectTime=1000;	gatherableDB="brickEOTWGatherableBasicData";																										helpText="Strange tasting moss. Grows horizontally on wood and itself when placed."; };
		new ScriptObject(MatterType) { name="Vines";		color="264b38ff";	spawnWeight=10;	spawnVeinSize=2;	spawnValue=128;	collectTime=1500;	gatherableDB="brickEOTWGatherableBasicData";																										helpText="Thick sturdy vines full of biomatter. Grows downward on wood and itself when placed.";	 };
		new ScriptObject(MatterType) { name="Cacti";		color="56643bff";	spawnWeight=10;	spawnVeinSize=2;	spawnValue=128;	collectTime=2000;	gatherableDB="brickEOTWGatherableBasicData";																										helpText="An exotic type of cacti. Grows upward on wood or itself.";	 };
		//Basic Gatherable Materials
		new ScriptObject(MatterType) { name="Copper";		color="d36b04ff";	spawnWeight=30;	spawnVeinSize=2;	spawnValue=128;	collectTime=13000;	gatherableDB="brickEOTWGatherableMetalData";																										helpText="One of the variant metals, primarily used for electrical applications."; };
		new ScriptObject(MatterType) { name="Silver";		color="e0e0e0ff";	spawnWeight=15;	spawnVeinSize=4;	spawnValue=128;	collectTime=14000;	gatherableDB="brickEOTWGatherableMetalData";	 																									helpText="A variant of metal with uses in machine construction.";	};
		new ScriptObject(MatterType) { name="Lead";			color="533d60ff";	spawnWeight=20;	spawnVeinSize=4;	spawnValue=128;	collectTime=15000;	gatherableDB="brickEOTWGatherableMetalData";					 																					helpText="Tastes sweet, must be edible. Used for matter transfer and machine construction.";	};
		new ScriptObject(MatterType) { name="Gold";			color="e2af14ff";	spawnWeight=10;	spawnVeinSize=2;	spawnValue=128;	collectTime=20000;	gatherableDB="brickEOTWGatherableMetalData";																										helpText="We're rich! This rather rare metal has important use in making higher tier metal alloys."; };
		new ScriptObject(MatterType) { name="Diamond";		color="00d0ffa8";	spawnWeight=04;	spawnVeinSize=1;	spawnValue=128;	collectTime=22000;	gatherableDB="brickEOTWGatherableCrystalData";	 																									helpText="Who knew carbon could be so rare and expensive. Has niche but useful uses in tools and Adamantine production.";	};
		//Complex Gatherable Materials
		new ScriptObject(MatterType) { name="Coal";			color="000000ff";	spawnWeight=30;	spawnVeinSize=4;	spawnValue=128;	collectTime=10000;	gatherableDB="brickEOTWGatherableBasicData";	fuelPower=16;																						helpText="Burnable carbon useful in both fuel and steel production.";	};
		new ScriptObject(MatterType) { name="Crude Oil";	color="1c1108ff";																																																								helpText="Unrefined fossil fuels ready to be refined into valuable oil products.";	};
		new ScriptObject(MatterType) { name="Fluorspar";	color="1f568cff";	spawnWeight=05;	spawnVeinSize=4;	spawnValue=128;	collectTime=10000;	gatherableDB="brickEOTWGatherableCrystalData";																										helpText="A special material with some useful applications in lategame materials.";	};
		new ScriptObject(MatterType) { name="Uraninite";	color="007c3fff";	spawnWeight=10;	spawnVeinSize=2;	spawnValue=128;	collectTime=18000;	gatherableDB="brickEOTWGatherableCrystalData";																										helpText="Spicy rocks which can be further refined into uranium.";	};
		new ScriptObject(MatterType) { name="Water";		color="000000ff"; };
		//Processed Gatherables
		new ScriptObject(MatterType) { name="Steam";		color="000000ff"; };
		new ScriptObject(MatterType) { name="Brimstone";	color="ffffffff"; };
		new ScriptObject(MatterType) { name="Fluorine";		color="ffffffff"; };
		new ScriptObject(MatterType) { name="Calcium";		color="ffffffff"; };
		new ScriptObject(MatterType) { name="Uranium-238";	color="ffffffff"; };
		new ScriptObject(MatterType) { name="Uranium-235";	color="ffffffff"; };
		new ScriptObject(MatterType) { name="Salt";			color="ffffffff"; };
		new ScriptObject(MatterType) { name="Rubber";		color="000000ff"; };
		//Chemistry
		new ScriptObject(MatterType) { name="Oxygen";		color="ffffffff"; };
		new ScriptObject(MatterType) { name="Hydrogen";		color="ffffffff"; };
		new ScriptObject(MatterType) { name="Biomass";		color="ffffffff";	fuelPower=64; };
		new ScriptObject(MatterType) { name="Ethanol";		color="ffffffff"; };
		new ScriptObject(MatterType) { name="Sulfuric Acid";color="ffffffff"; };
		new ScriptObject(MatterType) { name="Ethylene";		color="ffffffff"; };
		//Basic Petrochemistry
		new ScriptObject(MatterType) { name="Naphata";		color="ffffffff"; };
		new ScriptObject(MatterType) { name="Light Oil";	color="ffffffff"; };
		new ScriptObject(MatterType) { name="Heavy Oil";	color="ffffffff"; };
		new ScriptObject(MatterType) { name="Diesel";		color="ffffffff";	fuelPower=512; };
		new ScriptObject(MatterType) { name="Paraffin";		color="ffffffff"; };
		new ScriptObject(MatterType) { name="Jet Fuel";		color="ffffffff";	fuelPower=128; };
		new ScriptObject(MatterType) { name="Lubricant";	color="ffffffff"; };
		new ScriptObject(MatterType) { name="Asphalt";		color="ffffffff";	placable=true;	health=4.0;	heatCapacity=60;	meteorImmune=true; };
		//Advanced Petrochemistry
		new ScriptObject(MatterType) { name="Propylene";	color="ffffffff"; };
		new ScriptObject(MatterType) { name="Toulene";		color="ffffffff"; };
		new ScriptObject(MatterType) { name="Explosives";	color="ffffffff"; };
		new ScriptObject(MatterType) { name="Acetone";		color="ffffffff"; };
		new ScriptObject(MatterType) { name="Phenol";		color="ffffffff"; };
		new ScriptObject(MatterType) { name="Bisphenol";	color="ffffffff"; };
		new ScriptObject(MatterType) { name="Epichlorohydrin";	color="ffffffff"; };
		//Plastics
		new ScriptObject(MatterType) { name="Plastic";		color="ffffffff"; };
		new ScriptObject(MatterType) { name="Teflon";		color="ffffffff"; };
		new ScriptObject(MatterType) { name="Epoxy";		color="ffffffff"; };
		//Metal Alloys & Components
		//t1
		new ScriptObject(MatterType) { name="Electrum";		color="dfc47cff"; };
		new ScriptObject(MatterType) { name="Red Gold";		color="ffffffff"; };
		new ScriptObject(MatterType) { name="Steel";		color="ffffffff"; };
		//t2
		new ScriptObject(MatterType) { name="Energium";		color="ffffffff"; };
		new ScriptObject(MatterType) { name="Naturum";		color="ffffffff"; };
		new ScriptObject(MatterType) { name="Adamantine";	color="ffffffff"; };
		new ScriptObject(MatterType) { name="GT Diamond";	color="ffffffff"; };
		new ScriptObject(MatterType) { name="PlaSteel";		color="ffffffff";	placable=true;	health=4.0;	heatCapacity=60;	meteorImmune=true; };
		new ScriptObject(MatterType) { name="Granite Polymer";		color="ffffffff"; };
		//Nuclear
		new ScriptObject(MatterType) { name="Plutonium";	color="ffffffff"; };
		new ScriptObject(MatterType) { name="Heavy Water";	color="ffffffff"; };
		new ScriptObject(MatterType) { name="Deuterium";	color="ffffffff"; };
		new ScriptObject(MatterType) { name="Tritium";		color="ffffffff"; };
		new ScriptObject(MatterType) { name="Helium";		color="ffffffff"; };
		//Exotic
		new ScriptObject(MatterType) { name="Boss Essence";	color="ffffffff"; };
		new ScriptObject(MatterType) { name="Rare Earths";	color="ffffffff"; };
		new ScriptObject(MatterType) { name="dog";			color="ffffffff"; };
		//Ammunition
		new ScriptObject(MatterType) { name="Rifle Round";	color="ffffffff"; };
		new ScriptObject(MatterType) { name="Shotgun Shell";color="ffffffff"; };
		new ScriptObject(MatterType) { name="Launcher Load";color="ffffffff"; };
		new ScriptObject(MatterType) { name="Nuke";			color="ffffffff"; };
	};
	
	$EOTW::PlacableList = "";
	for (%i = 0; %i < MatterData.getCount(); %i++)
		if (MatterData.getObject(%i).placable)
			$EOTW::PlacableList = $EOTW::PlacableList TAB MatterData.getObject(%i).name;
	$EOTW::PlacableList = trim($EOTW::PlacableList);
	
	$EOTW::MatSpawnWeight = 0;
	$EOTW::MatSpawnList = "";
	for (%i = 0; %i < MatterData.getCount(); %i++)
	{
		if (MatterData.getObject(%i).spawnWeight > 0)
		{
			$EOTW::MatSpawnList = $EOTW::MatSpawnList TAB MatterData.getObject(%i).name;
			$EOTW::MatSpawnWeight += MatterData.getObject(%i).spawnWeight;
		}
	}
	$EOTW::MatSpawnList = trim($EOTW::MatSpawnList);

	schedule(10, 0, "EOTWbsm_PopulateRecipesMenu");
}
SetupMatterData();

function GetMatterType(%type)
{
	if (!isObject($EOTW::MatterType[%type]))
		for (%i = 0; %i < MatterData.getCount(); %i++)
			if (MatterData.getObject(%i).name $= %type)
				$EOTW::MatterType[%type] = MatterData.getObject(%i);

	return $EOTW::MatterType[%type];
}

function SetupRecipes()
{
	if (isObject(RecipeData))
	{
		RecipeData.deleteAll();
		RecipeData.delete();
	}

	new SimSet(RecipeData)
	{
		//T1 Alloys
		new ScriptObject(Recipe_Electrum) {	
			recipeType="Alloying";	powerDrain=$EOTW::PowerLevel[0]>>1;	powerCost=$EOTW::PowerLevel[0];	
			input[0]="Silver\t1";	input[1]="Gold\t3";	output[0]="Electrum\t4";	};
		new ScriptObject(Recipe_Red_Gold) {	
			recipeType="Alloying";	powerDrain=$EOTW::PowerLevel[0]>>1;	powerCost=$EOTW::PowerLevel[0];	
			input[0]="Copper\t1";	input[1]="Gold\t3";	output[0]="Red Gold\t4";	};
		new ScriptObject(Recipe_Steel) {	
			recipeType="Alloying";	powerDrain=$EOTW::PowerLevel[0]>>1;	powerCost=$EOTW::PowerLevel[0];	
			input[0]="Coal\t1";	input[1]="Iron\t3";	output[0]="Steel\t4";	};
		//Intermediate Alloys
		new ScriptObject(Recipe_Granite_Polymer) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Granite\t3";	input[1]="Plastic\t1";	output[0]="Granite Polymer\t4";	};
		new ScriptObject(Recipe_GT_Diamond) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Diamond\t1";	input[1]="Sturdium\t1";	input[1]="Epichlorohydrin\t1";	output[0]="GT Diamond\t3";	};
		//T2 Alloys
		new ScriptObject(Recipe_Energium) {	
			recipeType="Alloying";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Electrum\t1";	input[1]="Teflon\t1";	output[0]="Energium\t2";	};
		new ScriptObject(Recipe_Naturum) {	
			recipeType="Alloying";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Red Gold\t1";	input[1]="Teflon\t1";	output[0]="Naturum\t2";	};
		new ScriptObject(Recipe_PlaSteel) {	
			recipeType="Alloying";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Steel\t1";	input[1]="Granite Polymer\t1";	output[0]="PlaSteel\t4";	};
		//Basic Processed Materials
		new ScriptObject(Recipe_Brimstone) {	
			recipeType="Burning";	powerDrain=$EOTW::PowerLevel[0]>>1;	powerCost=$EOTW::PowerLevel[0];	
			input[0]="Crude Oil\t2";	output[0]="Brimstone\t1";	};
		new ScriptObject(Recipe_Uraninite_Processing) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1] * 20;	
			input[0]="Uraninite\t128";	input[1]="Sulfuric Acid\t32";	output[0]="Uranium-238\t128";	output[1]="Uranium-235\t1";	};
		new ScriptObject(Recipe_Fluorspar_Processing) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Fluorspar\t3";	input[1]="Sulfuric Acid\t1";	output[0]="Calcium\t1";	output[1]="Fluorine\t2";	};
		new ScriptObject(Recipe_Rubber) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[0]>>1;	powerCost=$EOTW::PowerLevel[0];	
			input[0]="Wood\t2";	input[1]="Sulfuric Acid\t1";	output[0]="Rubber\t1";	};
		new ScriptObject(Recipe_Salt) {	
			recipeType="Burning";	powerDrain=$EOTW::PowerLevel[0]>>1;	powerCost=$EOTW::PowerLevel[0];	
			input[0]="Water\t64";	output[0]="Salt\t1";	};
		//Chemistry
		new ScriptObject(Recipe_Water_Electrolysis) {	
			recipeType="Seperation";	powerDrain=$EOTW::PowerLevel[0]>>1;	powerCost=$EOTW::PowerLevel[0];	
			input[0]="Water\t3";	output[0]="Hydrogen\t2";	output[1]="Oxygen\t1";	};
		new ScriptObject(Recipe_Biomass) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[0]>>1;	powerCost=$EOTW::PowerLevel[0];	
			input[0]="Vines\t1";	input[1]="Moss\t1";	input[2]="Cacti\t1";	output[0]="Biomass\t3";	};
		new ScriptObject(Recipe_Ethanol) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[0]>>1;	powerCost=$EOTW::PowerLevel[0];	
			input[0]="Biomass\t1";	input[1]="Flesh\t1";	input[2]="Water\t1";	output[0]="Ethanol\t3";	};
		new ScriptObject(Recipe_Sulfuric_Acid) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[0]>>1;	powerCost=$EOTW::PowerLevel[0];	
			input[0]="Brimstone\t1";	input[1]="Water\t2";	output[0]="Sulfuric Acid\t3";	};
		new ScriptObject(Recipe_Ethylene) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[0]>>1;	powerCost=$EOTW::PowerLevel[0];	
			input[0]="Sulfuric Acid\t1";	input[1]="Ethanol\t1";	output[0]="Ethylene\t2";	};
		//Petrochemistry
		new ScriptObject(Recipe_Oil_Refining) {	
			recipeType="Seperation";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Crude Oil\t3";	output[0]="Light Oil\t1";	output[1]="Naphata\t1";	output[2]="Heavy Oil\t1";	};
		new ScriptObject(Recipe_Diesel) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1] * 32;	
			input[0]="Light Oil\t32";	input[1]="Heavy Oil\t32";	output[0]="Diesel\t64";	output[1]="Toulene\t1";	};
		new ScriptObject(Recipe_Paraffin) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Light Oil\t1";	input[1]="Wood\t2";	output[0]="Paraffin\t3";	};
		new ScriptObject(Recipe_Jet_Fuel) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Light Oil\t1";	input[1]="Hydrogen\t2";	output[0]="Jet Fuel\t3";	};
		new ScriptObject(Recipe_Lubricant) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Heavy Oil\t1";	input[1]="Water\t2";	output[0]="Lubricant\t3";	};
		new ScriptObject(Recipe_Asphalt) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Heavy Oil\t1";	input[1]="Stone\t2";	output[0]="Asphalt\t3";	};
		//Advanced Petrochemistry
		new ScriptObject(Recipe_Propylene) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Naphata\t1";	input[1]="Steam\t1";	output[0]="Propylene\t1";	};
		new ScriptObject(Recipe_Toulene_from_Coal) {	
			recipeType="Burning";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Coal\t2";	output[0]="Toulene\t1";	};
		new ScriptObject(Recipe_Toulene_from_Ethylene) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Ethylene\t1";	input[1]="Steam\t2";	output[0]="Toulene\t1";	};
		new ScriptObject(Recipe_Explosives) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Toulene\t2";	input[1]="Brimstone\t1";	input[2]="Paraffin\t1";	output[0]="Explosives\t4";	};
		new ScriptObject(Recipe_Hock_Process) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Toulene\t2";	input[1]="Propylene\t1";	input[2]="Oxygen\t1";	output[0]="Acetone\t2";	output[1]="Phenol\t2";	};
		new ScriptObject(Recipe_Acetone) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Propylene\t2";	input[1]="Hydrogen\t1";	output[0]="Phenol\t3";	};
		new ScriptObject(Recipe_Bisphenol) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Acetone\t1";	input[1]="Bisphenol\t2";	output[0]="Phenol\t3";	};
		new ScriptObject(Recipe_Epichlorohydrin) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Propylene\t1";	input[1]="Sulfuric Acid\t1";	input[2]="Salt\t1";	output[0]="Epichlorohydrin\t3";	};
		//Plastics
		new ScriptObject(Recipe_Plastic) {	
			recipeType="Burning";	powerDrain=$EOTW::PowerLevel[0]>>1;	powerCost=$EOTW::PowerLevel[0];	
			input[0]="Ethylene\t2";	output[0]="Plastic\t1";	};
		new ScriptObject(Recipe_Teflon) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[1]>>1;	powerCost=$EOTW::PowerLevel[1];	
			input[0]="Fluorine\t2";	input[1]="Hydrogen\t1";	input[2]="Ethylene\t1";	output[0]="Teflon\t4";	};
		new ScriptObject(Recipe_Epoxy) {	
			recipeType="Chemistry";	powerDrain=$EOTW::PowerLevel[2]>>1;	powerCost=$EOTW::PowerLevel[2];	
			input[0]="Epichlorohydrin\t1";	input[1]="Bisphenol\t1";	input[2]="Oxygen\t16";	output[0]="Epoxy\t2";	};
	};
}
SetupRecipes();

function cleanRecipeName(%name)
{
	return strReplace(getSubStr(%name, 7, strLen(%name)), "_", " ");
}

function getRecipeText(%recipe)
{
	if (!isObject(%recipe))
		return "---";

	for (%i = 0; %recipe.input[%i] !$= ""; %i++)
		%input = trim(%input SPC "+" SPC getField(%recipe.input[%i], 1) SPC getField(%recipe.input[%i], 0));
	%input = getSubStr(%input, 2, strLen(%input));

	for (%i = 0; %recipe.output[%i] !$= ""; %i++)
		%output = trim(%output SPC "+" SPC getField(%recipe.output[%i], 1) SPC getField(%recipe.output[%i], 0));
	%output = getSubStr(%output, 2, strLen(%output));

	return %input SPC "=(" SPC %recipe.powerCost SPC "EU Cost @" SPC %recipe.powerDrain SPC "EU/tick)=>" SPC %output;
}