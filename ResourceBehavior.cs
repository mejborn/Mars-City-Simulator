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
	public double wastePoop;// { get; private set; }
    [SerializeField]
    public double wastePee;// { get; private set; }
    [SerializeField]
    public double soil;// { get; private set; }
    [SerializeField]
    public double dirt;// { get; private set; }
    [SerializeField]
	public double science;// { get; private set; }
    [SerializeField]
	public double money;// { get; private set; }

    public enum Resources {food,water,energy,wastePoop,wastePee,soil,dirt,science,money};
	public Resource resource { get; private set; }

	void Awake(){
        resource = new Resource (food, water, energy, wastePoop, wastePee, soil, dirt, science, money);
        //foreach (GameObject go in FindObjectsOfType<GameObject>()) {
        //		resource.gameObjects.Add (go.GetInstanceID(), go.GetComponent<Building>());
        //}
    }

	// Use this for initialization
	void Start () {
		resource.setupDropDownMenu ();
    }
	
	// Update is called once per frame
	void Update () {
		resource.updateResources ();
	}

    void OnGUI()
    {
        GUI.skin.label.fontSize = 12;
        GUI.contentColor = Color.white;
        GUI.skin.label.fontStyle = FontStyle.Bold;
        GUI.Box(new Rect(0, Screen.height - 175, 200, 200), "Resources");
        GUI.skin.label.fontStyle = FontStyle.Normal;
        GUI.Label(new Rect(25, Screen.height - 120 - 30, 200, 100), "Energy: " + ((int)resource.energy));
        GUI.Label(new Rect(25, Screen.height - 105 - 30, 200, 100), "Food: " + ((int)resource.food));
        GUI.Label(new Rect(25, Screen.height - 90 - 30, 200, 100), "Money: " + ((int)resource.money));
        GUI.Label(new Rect(25, Screen.height - 75 - 30, 200, 100), "Dirt: " + ((int)resource.dirt));
        GUI.Label(new Rect(25, Screen.height - 60 - 30, 200, 100), "Science: " + ((int)resource.science));
        GUI.Label(new Rect(25, Screen.height - 45 - 30, 200, 100), "Waste (Poop): " + ((int)resource.wastePoop));
        GUI.Label(new Rect(25, Screen.height - 30 - 30, 200, 100), "Waste (Pee): " + ((int)resource.wastePee));
        GUI.Label(new Rect(25, Screen.height - 15 - 30, 200, 100), "Soil: " + ((int)resource.soil));
        GUI.Label(new Rect(25, Screen.height - 0 - 30, 200, 100), "Water: " + ((int)resource.water));
    }
}
