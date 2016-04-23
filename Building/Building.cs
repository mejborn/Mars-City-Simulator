using UnityEngine;
using System.Collections;

class Building {
	private float revenue;
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
		this.revenue = 0;
		this.buildingType = bt;
	}
	public BuildingType getBuildingType(){
		return buildingType;
	}

	public void performWork (Person person)
	{
		Skillset skillset = person.getSkillset;

		switch (buildingType) {
		case BuildingType.Growhouse:
			revenue += skillset.farming;
			break;
		default:
			break;
		}
	}

}
