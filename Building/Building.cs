using UnityEngine;
using System.Collections;

class Building {
	public enum BuildingType 
	{
		Growhouse,
		WaterTreatment,
		WasteTreatment,
		EnergyGenerator,
		ResearchCenter,
		LoadingDock,
		Habitation
	}
	private BuildingType buildingType;
	public Building(BuildingType bt){
		this.buildingType = bt;
	}
	public BuildingType getBuildingType(){
		return buildingType;
	}
}
