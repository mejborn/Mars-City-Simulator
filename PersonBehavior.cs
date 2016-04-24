using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersonBehavior : MonoBehaviour {
	Person person;
	Building currentBuilding;

	[SerializeField]
	ScienceField.Scfield scienceField;
	[SerializeField]
	string pname = "testguy1";

	void Awake(){
		this.person = new Person (pname,scienceField,GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceBehavior>().resource);	
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		person.UpdateState ();
	}

	public Person getPerson(){
		return this.person;
	}

	Personality getPersonality()
	{
		return person.personality;
	}

	Skillset getSkillset ()
	{
		return person.getSkillset ();
	}

}
