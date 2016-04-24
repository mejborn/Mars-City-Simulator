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

    public enum Resources {food,water,energy,waste,science,money};
	public Resource resource { get; private set; }


	void Awake(){
		this.resource = new Resource (food, water, energy, waste, science, money);
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
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(25, 115, 100, 100), "Energy: " + resource.energy.ToString("F"));
        GUI.Label(new Rect(25, 130, 100, 100), "Food: " + resource.food.ToString("F"));
        GUI.Label(new Rect(25, 145, 100, 100), "Money: " + resource.money.ToString("F"));
        GUI.Label(new Rect(25, 160, 100, 100), "Science: " + resource.science.ToString("F"));
        GUI.Label(new Rect(25, 175, 100, 100), "Waste: " + resource.waste.ToString("F"));
        GUI.Label(new Rect(25, 190, 100, 100), "Water: " + resource.water.ToString("F"));
    }
}
