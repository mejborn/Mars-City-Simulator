﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building{
	const double productionRate = 0.001;
	public enum BuildingType 
	{
		Growhouse,
		Connector,
		Habitation,
		SolarPanel,
		LandingPad,
		ResearchCenter,
		WaterTreatment,
		Drill
	}
	public BuildingType buildingType;

	private double food = 0, water = 0, soil = 0, dirt = 0, money = 0, science = 0, energy = 0, wastePoop = 0, wastePee = 0;

	LinkedList<double> revenue;
	private LinkedList<Person> occupants;
	private int maxOccupants = 4;
	private int currentOccupants = 0;

    public bool isActive;


	public Building(BuildingType bt){
		this.buildingType = bt;
        occupants = new LinkedList<Person>();

        if (bt.Equals(BuildingType.Habitation) || bt.Equals(BuildingType.Drill) || bt.Equals(BuildingType.SolarPanel))
            isActive = true;
    }

	public int consume (Resource.Resources res)
	{
		int tmp = 0;
		switch (res) {
		case Resource.Resources.food:
			tmp = (int)food;
			food = food % 1;
			return tmp;
		case Resource.Resources.water:
			tmp = (int)water;
			water = water % 1;
			return tmp;
		case Resource.Resources.soil:
			tmp = (int)soil;
			soil = soil % 1;
			return tmp;
		case Resource.Resources.dirt:
			tmp = (int)dirt;
			dirt = dirt % 1;
			return tmp;
		case Resource.Resources.science:
			tmp = (int)science;
			science = science % 1;
			return tmp;
		case Resource.Resources.energy:
			tmp = (int)energy;
			energy = energy % 1;
			return tmp;
		case Resource.Resources.wastePoop:
			tmp = (int)wastePoop;
			wastePoop = wastePoop % 1;
			return tmp;
		case Resource.Resources.wastePee:
			tmp = (int)wastePee;
			wastePee = wastePee % 1;
			return tmp;
		case Resource.Resources.money:
			tmp = (int)money;
			money = money % 1;
			return tmp;
		default:
			break;
		}
		return tmp;
	}

	public bool enter (Person person)
	{
		if (currentOccupants < maxOccupants && isActive) {
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

	public BuildingType getBuildingType(){
		return buildingType;
	}

	public LinkedList<Person> getOccupants(){
		return this.occupants;
	}

    public void Update()
    {
        switch (buildingType)
        {
            case BuildingType.SolarPanel:
                energy += 46 * productionRate;
                break;
            case BuildingType.Drill:
                science += 50 * productionRate;
                water += 25 * productionRate;
                dirt += 200 * productionRate;
                energy -= 150 * productionRate;
                break;
            default:
                break;
        }
    }

	public void performWork (Person person)
	{
		Skillset skillset = person.getSkillset ();
		double DISCfactor = calculateDICSFactor ();
		switch (buildingType) {
		case BuildingType.Habitation:
			energy -= (150 * productionRate / (skillset.farming + skillset.engineering + skillset.science) * DISCfactor);
			break;
		case BuildingType.Growhouse:
			food += (30 * productionRate * skillset.farming * DISCfactor);
			water -= (200 * productionRate / (skillset.farming * DISCfactor));
			soil -= (0.01 * productionRate / (skillset.farming * DISCfactor));
			energy -= (10 * productionRate / (skillset.engineering * DISCfactor));
			break;
		case BuildingType.ResearchCenter:
			science += (10 * productionRate * (skillset.science + skillset.engineering) * DISCfactor);
			water -= (100 * productionRate / skillset.science * DISCfactor);
			energy -= (100 * productionRate / skillset.science * DISCfactor);
			break;
		case BuildingType.WaterTreatment:
			food += (100 * productionRate * (skillset.science + skillset.engineering) * DISCfactor);//it's microbiology!
			water += (200 * productionRate * (skillset.farming + skillset.science + skillset.engineering) * DISCfactor);
			soil += (50 * productionRate * (skillset.farming + skillset.farming) * DISCfactor);
			wastePoop -= (100 * productionRate / (skillset.engineering + skillset.science) * DISCfactor);
			wastePee -= (180 * productionRate * (skillset.engineering + skillset.science) * DISCfactor);
			dirt -= (100 * productionRate / (skillset.engineering + skillset.farming) * DISCfactor);
			energy -= (150 * productionRate / (skillset.engineering + skillset.science) * DISCfactor);
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
		return 1;
	}

}
