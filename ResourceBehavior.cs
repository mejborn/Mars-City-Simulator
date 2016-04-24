using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ResourceBehavior : MonoBehaviour {
    [SerializeField]
    public double food;//{ get; private set; } 
	[SerializeField]
	public double water;// { get; private set; }
    [SerializeField]
	public double energy;// { get; private set; }
    [SerializeField]
	public double waste;// { get; private set; }
    [SerializeField]
	public double science;// { get; private set; }
    [SerializeField]
	public double money;// { get; private set; }

    public enum Resource {food,water,energy,waste,science,money};


	void Awake(){
		this.resource = new Resource (food, water, energy, waste, science, money);
	}

	// Use this for initialization
	void Start () {
		
		this.buildings = new LinkedList<Building> ();
		this.people = new LinkedList<Person> ();
	}
	
	// Update is called once per frame
	void Update () {
		resource.updateResources ();
	}
	public Resource getResource(){
		return this.resource;
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

    void OnGUI()
    {
        GUI.skin.label.fontSize = 12;
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(15, 15, 100, 100), ("Food: " + food));
        GUI.Label(new Rect(15, 30, 100, 100), ("Water: " + water));
        GUI.Label(new Rect(15, 45, 100, 100), ("Energy: " + energy));
        GUI.Label(new Rect(15, 60, 100, 100), ("Waste: " + waste));
        GUI.Label(new Rect(15, 75, 100, 100), ("Science: " + science));
        GUI.Label(new Rect(15, 90, 100, 100), ("Money: " + money));
    }
}
