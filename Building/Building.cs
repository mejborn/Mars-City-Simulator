using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building {
	const double productionRate = 0.01;

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
		int numD, numI, numS, numC;
		int bonus = 1;
		foreach (Person person in occupants) {
			numD += person.getPersonality ().getD;
			numI += person.getPersonality ().getI;
			numS += person.getPersonality ().getS;
			numC += person.getPersonality ().getC;
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
