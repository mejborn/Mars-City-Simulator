using UnityEngine;
using System.Collections;

public class Building {
	private double revenue;
	public int consume ()
	{
		int tmp = 0;
		if (revenue > 1) {
			tmp = (int)revenue;
			revenue = revenue % 1;
		}
		return tmp;
	}

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
		Skillset skillset = person.getSkillset ();

		switch (buildingType) {
		case BuildingType.Growhouse:
			revenue += (0.01 * skillset.farming);
			break;
		default:
			break;
		}
	}

}
