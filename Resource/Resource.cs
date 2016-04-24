using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Resource {
	public enum Resources {food,water,energy,wastePoop,wastePee,soil,dirt,science,money};
	public LinkedList<Building> buildings { get; private set; }
	public LinkedList<Person> people { get; private set; }
	public double food { get; private set; }
	public double water { get; private set; }
	public double energy { get; private set; }
	public double wastePoop {get; private set;}
	public double wastePee {get; private set;}
	public double soil {get; private set;}
	public double dirt {get; private set;}
	public double science { get; private set; }
	public double money {get; private set;}
	private Dropdown dp, db;

	public Resource(double food, double water, double energy, double wastePoop, double wastePee, double soil, double dirt, double science, double money){

        this.food = food;
        this.water = water;
        this.energy = energy;
        this.wastePoop = wastePoop;
        this.wastePee = wastePee;
        this.soil = soil;
        this.dirt = dirt;
        this.science = science;
        this.money = money;

		this.buildings = new LinkedList<Building> ();
		this.people = new LinkedList<Person> ();
	}

	public void setupDropDownMenu(){
		dp = GameObject.Find("Dropdown_People").GetComponent<Dropdown> ();
		db = GameObject.Find ("Dropdown_Buildings").GetComponent<Dropdown> ();
		dp.gameObject.AddComponent<MenuBehavior> ();
		dp.itemText.text = "People";
		dp.captionText.text = "People";
		db.gameObject.AddComponent<MenuBehavior> ();
		dp.options.Clear ();
		db.options.Clear ();
		db.captionText.text = "Buildings";
		db.itemText.text = "Buildings";
	}

	public void updateMenus ()
	{
		dp.options.Clear ();
		db.options.Clear ();
		foreach (Person person in this.people){
			dp.options.Add (new Dropdown.OptionData() {text = person.name} );
		}
		foreach (Building building in this.buildings) {
			if (!(Building.BuildingType.Connector.Equals(building.getBuildingType()))) {
				db.options.Add (new Dropdown.OptionData () { text = building.getBuildingType ().ToString () });
			}
		}
	}

	public void updateResources ()
	{
		foreach (Building building in buildings) {
			switch (building.getBuildingType()) {
			case Building.BuildingType.Habitation:
				energy -= building.consume ();
				break;
			case Building.BuildingType.Growhouse:
				food += building.consume ();
				water -= building.consume ();
				soil -= building.consume ();
				energy -= building.consume ();
				break;
			case Building.BuildingType.SolarPanel:
				energy += building.consume ();
				break;
			case Building.BuildingType.ResearchCenter:
				science += building.consume ();
				water -= building.consume ();
				energy -= building.consume ();
				break;
			case Building.BuildingType.WaterTreatment:
				food += building.consume ();
				water += building.consume ();
				soil += building.consume ();
				waste -= building.consume ();
				dirt -= building.consume ();
				energy -= building.consume ();
				break;
			case Building.BuildingType.Drill:
				water += building.consume ();
				science += building.consume ();
				dirt += building.consume ();
				energy -= building.consume ();
				break;
			default:
				break;
			}
		}
	}

	public void addBuilding(Building building){
		buildings.AddLast (building);
		updateMenus ();
	}

	public void addPerson (Person person)
	{
		people.AddLast (person);
	}

	public void consumeResource(Resources res, double amount){
		switch (res) {
		case Resource.Resources.energy:
			this.energy -= amount;
			break;
		case Resource.Resources.food:
            this.food -= amount;
            break;
		case Resource.Resources.money:
			this.money -= amount;
			break;
		case Resource.Resources.science:
			this.science -= amount;
			break;
		case Resource.Resources.water:
			this.water -= amount;
			break;
		default:
			break;
		}
		if (Resource.Resources.science > 0) {
			money += (Resource.Resources.science * 10000000);
			Resource.Resources.science = 0;
			science = Resource.Resources.science;
		}
	}

	public void generateWaste(Resources res, double amount){
		switch (res) {
		case Resource.Resources.wastePoop:
			this.wastePoop += amount;
			break;
		case Resource.Resources.wastePee:
			this.wastePee += amount;
			break;
		default:
			break;
		}
	}
}
