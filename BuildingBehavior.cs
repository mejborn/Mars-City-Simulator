using UnityEngine;
using System.Collections;

public class BuildingBehavior : MonoBehaviour {
	Building building;

	[SerializeField]
	Building.BuildingType buildingType;
	[SerializeField]
	ResourceBehavior resource;
	[SerializeField]
    public int extendsX = 2;
    [SerializeField]
    public int extendsZ = 2;

    // Use this for initialization
    void Start () {
		this.building = new Building (buildingType);
		resource.addBuilding (this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	string getType(){
		return building.getBuildingType().ToString();
	}
}
