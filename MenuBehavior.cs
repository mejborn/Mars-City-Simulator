using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuBehavior : MonoBehaviour { 
	Dropdown personMenu, buildingsMenu;
	Resource resource;

	void Awake(){
		resource = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceBehavior>().resource;
		this.personMenu = GameObject.Find("Dropdown_People").GetComponent<Dropdown>();
		this.buildingsMenu = GameObject.Find ("Dropdown_Buildings").GetComponent<Dropdown> ();
	}

	// Use this for initialization
	void Start () {
		personMenu.options.Clear ();
		buildingsMenu.options.Clear ();
		foreach (Person person in resource.people){
			personMenu.options.Add (new Dropdown.OptionData() {text = person.name} );
		}
		foreach (Building building in resource.buildings) {
			buildingsMenu.options.Add (new Dropdown.OptionData () { text = building.getBuildingType ().ToString() });
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
