using UnityEngine;
using System.Collections;

public class PeopleSpawnerBehavior : MonoBehaviour
{
    void Start()
    {
        Resource resourse = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceBehavior>().resource;
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
        person.GetComponent<PersonBehavior>().getPerson().name = "Dee";
        person.GetComponent<PersonBehavior>().scienceField = ScienceField.Scfield.Scientist;

        resourse.updateMenus();
    }
}
