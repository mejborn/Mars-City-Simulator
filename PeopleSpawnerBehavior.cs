using UnityEngine;
using System.Collections;

public class PeopleSpawnerBehavior : MonoBehaviour
{
    void Start()
    {
        GameObject person = new GameObject();
        person.AddComponent<PersonBehavior>();

        person = new GameObject();
        person.AddComponent<PersonBehavior>();

        person = new GameObject();
        person.AddComponent<PersonBehavior>();

        person = new GameObject();
        person.AddComponent<PersonBehavior>();
    }
}
