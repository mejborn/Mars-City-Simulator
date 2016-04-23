using UnityEngine;
using System.Collections;

public class BuildingBehavior : MonoBehaviour {
	Building building;

	[SerializeField]
	Building.BuildingType buildingType;
	Resource resource;
	[SerializeField]
    public int extendsX = 2;
    [SerializeField]
    public int extendsZ = 2;

	void Awake(){
		this.resource = GameObject.FindGameObjectWithTag ("ResourceManager").GetComponent<ResourceBehavior> ().resource;
		this.building = new Building (buildingType);
	}

    // Use this for initialization
    void Start () {
		resource.addBuilding (building);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	string getType(){
		return building.getBuildingType().ToString();
	}
}
