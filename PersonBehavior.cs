using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersonBehavior : MonoBehaviour {
	Person person;
	Building currentBuilding;

	[SerializeField]
	public ScienceField.Scfield scienceField;
	[SerializeField]
	public string pname = "testguy1";

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

    void OnGUI()
    {
        GUI.skin.label.fontSize = 12;
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(25, 225, 100, 100), "Food: " + person.health.food.ToString("F"));
        GUI.Label(new Rect(25, 240, 100, 100), "Happiness: " + person.health.happiness.ToString("F"));
    }
}
