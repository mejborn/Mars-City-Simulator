using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceBehavior : MonoBehaviour {
	[SerializeField]
	int food,water,energy,waste,science,money;
	LinkedList<Building> buildings;

	// Use this for initialization
	void Start () {
		this.buildings = new LinkedList<Building> ();
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
}
