using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingBehavior : MonoBehaviour {
	public Building building { get; private set; }

	[SerializeField]
	Building.BuildingType buildingType;
	Resource resource;

	[SerializeField]
    public int extendsX = 2;
    [SerializeField]
    public int extendsZ = 2;

	[SerializeField]
	public List<Vector2> entrances;

	int id;
    
	void Awake(){
		this.resource = GameObject.FindGameObjectWithTag ("ResourceManager").GetComponent<ResourceBehavior> ().resource;
		this.building = new Building (buildingType);
		resource.addBuilding (building);
		resource.gameObjects.Add (this.GetInstanceID(), this.building);
    }
    
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		resource.updateMenus ();
	}
		
	public Building.BuildingType getType(){
		return buildingType;
	}
}
