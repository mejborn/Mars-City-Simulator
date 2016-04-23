using UnityEngine;
using System.Collections;

class Person
{
	private Health health;
	private ScienceField scfield;
	private Personality personality;

	public Person(ScienceField.Scfield scfield){
		this.scfield = new ScienceField(scfield);
		this.personality = new Personality ();
	}
	public Personality getPersonality(){
		return this.personality;
	}
	public Skillset getSkillset(){
		return scfield.getSkillset();
	}
}