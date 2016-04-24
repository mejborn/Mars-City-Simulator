using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building {
	const double productionRate = 0.01;

	public BuildingType buildingType;

	private double revenue;
	private LinkedList<Person> occupants;
	private int maxOccupants = 4;
	private int currentOccupants = 0;


	public Building(BuildingType bt){
		this.revenue = 0;
		this.buildingType = bt;

        occupants = new LinkedList<Person>();
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
        Debug.Log(person.name);
		if (currentOccupants < maxOccupants) {
			occupants.AddLast (person);
            currentOccupants++;

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

	public BuildingType getBuildingType(){
		return buildingType;
	}

	public LinkedList<Person> getOccupants(){
		return this.occupants;
	}

	public void performWork (Person person)
	{
		Skillset skillset = person.getSkillset ();
		double DISCfactor = calculateDICSFactor ();
		switch (buildingType) {
		case BuildingType.Growhouse:
			revenue += (productionRate * skillset.farming * DISCfactor);
			break;
		default:
			break;
		}
	}

	double calculateDICSFactor ()
	{
		double numD = 0, numI = 0, numS = 0, numC = 0;
		double bonus = 1;
		foreach (Person person in occupants) {
			numD += person.personality.getD();
			numI += person.personality.getI();
			numS += person.personality.getS();
			numC += person.personality.getC();
		}
		if (numD <= 10) {
			bonus -= 0.1;
		} else if (numD <= 15) {
			bonus += 0.1;
		} else if (numD <= 20) {
			bonus -= 0.1;
		} else {
			bonus -= 0.3;
		}
		throw new System.NotImplementedException ();
	}

}
