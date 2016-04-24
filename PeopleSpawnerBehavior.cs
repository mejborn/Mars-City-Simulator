using UnityEngine;
using System.Collections;

public class PeopleSpawnerBehavior : MonoBehaviour
{
    void Start()
    {
        Resource resourse = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceBehavior>().resource;
        GameObject person; 
        for (int i = 0; i < FindObjectOfType<GlobalData>().names.Count; i++)
        {
            person = new GameObject();
            
            person.AddComponent<PersonBehavior>();
            person.GetComponent<PersonBehavior>().getPerson().name = FindObjectOfType<GlobalData>().names[i];

            switch (FindObjectOfType<GlobalData>().names[i])
            {
                case "astronaut":
                    person.GetComponent<PersonBehavior>().scienceField = ScienceField.Scfield.Astronaut;
                    break;
                case "tourist":
                    person.GetComponent<PersonBehavior>().scienceField = ScienceField.Scfield.Tourist;
                    break;
                case "farmer":
                    person.GetComponent<PersonBehavior>().scienceField = ScienceField.Scfield.Farmer;
                    break;
                case "engineer":
                    person.GetComponent<PersonBehavior>().scienceField = ScienceField.Scfield.Engineer;
                    break;
                case "scientist":
                    person.GetComponent<PersonBehavior>().scienceField = ScienceField.Scfield.Scientist;
                    break;
            }
            person.GetComponent<PersonBehavior>().scienceField = ScienceField.Scfield.Engineer;

        }
        /*

        
        GameObject person = new GameObject();
        person.AddComponent<PersonBehavior>();
        person.GetComponent<PersonBehavior>().getPerson().name = "Frank";
        person.GetComponent<PersonBehavior>().scienceField = ScienceField.Scfield.Astronaut;

        person = new GameObject();
        person.AddComponent<PersonBehavior>();
        person.GetComponent<PersonBehavior>().getPerson().name = "Dennis";
        person.GetComponent<PersonBehavior>().scienceField = ScienceField.Scfield.Engineer;

        person = new GameObject();
        person.AddComponent<PersonBehavior>();
        person.GetComponent<PersonBehavior>().getPerson().name = "Charlie";
        person.GetComponent<PersonBehavior>().scienceField = ScienceField.Scfield.Tourist;

        person = new GameObject();
        person.AddComponent<PersonBehavior>();
        person.GetComponent<PersonBehavior>().getPerson().name = "Mac";
        person.GetComponent<PersonBehavior>().scienceField = ScienceField.Scfield.Farmer;

		person = new GameObject();
		person.AddComponent<PersonBehavior>();
		person.GetComponent<PersonBehavior>().getPerson().name = "Cheese";
		person.GetComponent<PersonBehavior>().scienceField = ScienceField.Scfield.Farmer;

        person = new GameObject();
        person.AddComponent<PersonBehavior>();
        person.GetComponent<PersonBehavior>().getPerson().name = "Dee";
        person.GetComponent<PersonBehavior>().scienceField = ScienceField.Scfield.Scientist;
        */
        resourse.updateMenus();
    }
}
