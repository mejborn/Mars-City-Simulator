using UnityEngine;
using System.Collections;

public class PersonBehavior : MonoBehaviour {
	Person person;
	Building currentBuilding;
	Person interractee;
	[SerializeField]
	ScienceField.Scfield scienceField;
	[SerializeField]
	ResourceBehavior resource;
	
	// Use this for initialization
	void Start () {
		this.person = new Person (scienceField);
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
			person.performInterraction (currentBuilding);
			break;
		case Person.State.interracting:
			person.performInterraction (interractee);
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
