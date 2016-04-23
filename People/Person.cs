using UnityEngine;
using System.Collections;

class Person
{
	private ScienceField scfield;
	private Personality personality;

	public Person(ScienceField.Scfield scfield){
		this.scfield = new ScienceField(scfield);
		this.personality = new Personality ();
	}
}