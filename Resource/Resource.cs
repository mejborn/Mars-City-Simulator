using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Resource {
	public enum Resources {food,water,energy,waste,science,money};
	public LinkedList<Building> buildings { get; private set; }
	public LinkedList<Person> people { get; private set; }
	public double food { get; private set; }
	public double water { get; private set; }
	public double energy { get; private set; }
	public double waste {get; private set;}
	public double science { get; private set; }
	public double money {get; private set;}
	private Dropdown dp, db;

	public Resource(double food, double water, double energy, double waste, double science, double money){
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
			case Building.BuildingType.EnergyGenerator:
				energy += building.consume ();
				break;
			case Building.BuildingType.Growhouse:
				food += building.consume ();
				break;
			case Building.BuildingType.ResearchCenter:
				science += building.consume ();
				break;
			case Building.BuildingType.WasteTreatment:
				break;
			case Building.BuildingType.WaterTreatment:
				water += building.consume ();
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
		case Resource.Resources.waste:
			this.waste -= amount;
			break;
		case Resource.Resources.water:
			this.water -= amount;
			break;
		default:
			break;
		}
	}

}
