using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AssignmentButton : MonoBehaviour {

    Button thisButton;
    Resource resource;
    Dropdown dp, db;

    // Use this for initialization
    void Start () {
        resource = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceBehavior>().resource;
        dp = GameObject.Find("Dropdown_People").GetComponent<Dropdown>();
        db = GameObject.Find("Dropdown_Buildings").GetComponent<Dropdown>();

        thisButton = gameObject.GetComponent<Button>();
        thisButton.GetComponentInChildren<Text>().text = "Assign Worker";
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void onClick()
    {
        resource.people.ElementAt(dp.value).enterBuilding(resource.buildings.ElementAt(db.value));     
    }
}
