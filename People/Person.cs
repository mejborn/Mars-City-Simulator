using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Person
{
	public enum State {working, interracting, home, sleeping}

	private Health health;
	private ScienceField scfield;
	private Personality personality;
	private State state;
	private Building currentBuilding;

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
		
	public void performInterraction (Person person)
	{
		throw new NotImplementedException ();
	}

	public State getState(){
		return state;
	}

	public void performInterraction ()
	{
		currentBuilding.performWork (this);
	}

	public bool enterBuilding(Building building){
		if (building.enter (this)) {
			currentBuilding = building;
			if (Building.BuildingType.Habitation.Equals(building.getBuildingType())) {
				state = State.home;
			}else { state = State.working; }
			return true;
		} else {
			return false;
		}
	}

	public void consumeResources ()
	{
		throw new NotImplementedException ();
	}

	public void updateHealth ()
	{
		health.update ();
	}

}