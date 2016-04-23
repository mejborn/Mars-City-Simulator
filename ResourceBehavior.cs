using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceBehavior : MonoBehaviour {
	[SerializeField]
	public double food { get; private set; } 
	[SerializeField]
	public double water { get; private set; }
	[SerializeField]
	public double energy { get; private set; }
	[SerializeField]
	public double waste { get; private set; }
	[SerializeField]
	public double science { get; private set; }
	[SerializeField]
	public double money { get; private set; }

	public enum Resource {food,water,energy,waste,science,money};
	public LinkedList<Building> buildings { get; private set; }
	public LinkedList<Person> people { get; private set; }

	// Use this for initialization
	void Start () {
		this.buildings = new LinkedList<Building> ();
		this.people = new LinkedList<Person> ();
	}
	
	// Update is called once per frame
	void Update () {
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
	}

	public void consumeResource(Resource res, double amount){
		switch (res) {
		case Resource.energy:
			this.energy -= amount;
			break;
		case Resource.food:
			this.food -= amount;
			break;
		case Resource.money:
			this.money -= amount;
			break;
		case Resource.science:
			this.science -= amount;
			break;
		case Resource.waste:
			this.waste -= amount;
			break;
		case Resource.water:
			this.water -= amount;
			break;
		default:
			break;
		}
	}
}
