using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingBehavior : MonoBehaviour {
	Building building;

	[SerializeField]
	Building.BuildingType buildingType;
	Resource resource;

	[SerializeField]
    public int extendsX = 2;
    [SerializeField]
    public int extendsZ = 2;

	[SerializeField]
	public List<Vector2> entrances;

    public bool isActive;
    
	void Awake(){
		this.resource = GameObject.FindGameObjectWithTag ("ResourceManager").GetComponent<ResourceBehavior> ().resource;
		this.building = new Building (buildingType);
	}
    
    // Use this for initialization
    void Start () {
        if (buildingType == Building.BuildingType.Habitation)
            isActive = true;
		//resource.addBuilding (building);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public Building.BuildingType getType(){
		return buildingType;
	}
}
