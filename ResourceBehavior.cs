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
}
