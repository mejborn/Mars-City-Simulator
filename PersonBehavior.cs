using UnityEngine;
using System.Collections;

public class PersonBehavior : MonoBehaviour {
	Person person;
	[SerializeField]
	ScienceField.Scfield scienceField;
	
	// Use this for initialization
	void Start () {
		this.person = new Person (scienceField);
	}
	
	// Update is called once per frame
	void Update () {
	
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
