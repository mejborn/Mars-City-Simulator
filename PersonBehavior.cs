using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PersonBehavior : MonoBehaviour {
	Person person;
	Building currentBuilding;

	[SerializeField]
	public ScienceField.Scfield scienceField;
	[SerializeField]
	public string pname = "testguy1";

    private Dropdown dp;

    void Awake(){
		this.person = new Person (pname,scienceField,GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceBehavior>().resource);	
	}

	// Use this for initialization
	void Start () {
        dp = GameObject.Find("Dropdown_People").GetComponent<Dropdown>();
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
        if (dp.captionText.text == person.name)
        {
            GUI.skin.label.fontSize = 12;
            GUI.contentColor = Color.white;
            GUI.skin.label.fontStyle = FontStyle.Normal;
            GUI.Box(new Rect(20, 225, 100, 100), "Settler: " + person.name);
            GUI.Label(new Rect(25, 245, 100, 100), "Food: " + ((int)person.health.food));
            GUI.Label(new Rect(25, 260, 100, 100), "Water: " + ((int)person.health.water));
            GUI.Label(new Rect(25, 275, 100, 100), "Happiness: " + ((int)person.health.happiness));
            GUI.Label(new Rect(25, 290, 100, 100), "Building: " + person.currentBuilding.buildingType.ToString());

        }
    }
}
