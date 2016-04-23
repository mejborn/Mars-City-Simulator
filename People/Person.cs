using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Person
{
	private Health health;
	private ScienceField scfield;
	private Personality personality;
	private enum State {working, home, sleeping}
	private State state;

	public Person(ScienceField.Scfield scfield){
		this.scfield = new ScienceField(scfield);
		this.personality = new Personality ();
		this.state = State.home;
	}
	public Personality getPersonality(){
		return this.personality;
	}
	public Skillset getSkillset(){
		return scfield.getSkillset();
	}
		
	void performInterraction (Person person)
	{
		throw new NotImplementedException ();
	}

	void performInterraction (Building building)
	{
		building.performWork (this);
	}
}