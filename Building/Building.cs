using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building {
	private double revenue;
	private LinkedList<Person> occupants;
	private int maxOccupants = 4;
	private int currentOccupants = 0;

	public Building(BuildingType bt){
		this.revenue = 0;
		this.buildingType = bt;
	}

	public int consume ()
	{
		int tmp = 0;
		if (revenue > 1) {
			tmp = (int)revenue;
			revenue = revenue % 1;
		}
		return tmp;
	}

	public bool enter (Person person)
	{
		if (currentOccupants < maxOccupants) {
			occupants.AddLast (person);
			return true;
		}
		return false;
	}

	public void leave(Person person){
		occupants.Remove (person);
		currentOccupants--;
	}

	public enum BuildingType 
	{
		Growhouse,
		WaterTreatment,
		WasteTreatment,
		EnergyGenerator,
		ResearchCenter,
		LoadingDock,
		Habitation,
		Connector
	}
	private BuildingType buildingType;

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
