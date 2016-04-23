using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersonBehavior : MonoBehaviour {
	Person person;
	Building currentBuilding;

	[SerializeField]
	ScienceField.Scfield scienceField;
	
	// Use this for initialization
	void Start () {
		this.person = new Person (scienceField,GameObject.FindGameObjectWithTag("resources").GetComponent<ResourceBehavior>());
	}
	
	// Update is called once per frame
	void Update () {
		switch (person.getState ()) {
		case Person.State.home:
			person.consumeResources ();
			break;
		case Person.State.sleeping:
			break;
		case Person.State.working:
			person.performInterraction ();
			break;
		case Person.State.interracting:
			person.performHumanHumanInterractions ();
			break;
		default:
			break;
		}
		person.updateHealth ();
	}

	Personality getPersonality()
	{
		return person.getPersonality ();
	}

	Skillset getSkillset ()
	{
		return person.getSkillset ();
	}

}
