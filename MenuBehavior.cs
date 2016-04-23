using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuBehavior : MonoBehaviour {
	Dropdown menu;
	Resource resource;

	void Awake(){
		resource = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceBehavior>().resource;
		this.menu = GameObject.FindGameObjectWithTag("DropDownMenu").GetComponent<Dropdown>();
	}

	// Use this for initialization
	void Start () {
		menu.options.Clear ();
		LinkedList<Person> people = resource.people;

		foreach (Person person in resource.people){
			var p = person.personality;
			menu.options.Add (new Dropdown.OptionData() {text = person.name} );
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
