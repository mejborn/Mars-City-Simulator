using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Person
{
	private const double waterConsumationModifier = 0.01;
	private const double foodConsumationModifier = 0.01;

	public enum State {working, interracting, home, sleeping}

	private string name;
	private Health health;
	private ScienceField scfield;
	private Personality personality;
	private State state;
	private Building currentBuilding;
	private Person interractee;
	private ResourceBehavior resource;

	public Person(string name,ScienceField.Scfield scfield,ResourceBehavior resourceBehavior){
		this.name = name;
		this.scfield = new ScienceField(scfield);
		this.personality = new Personality ();
		this.state = State.home;
		this.resource = resourceBehavior;
	}
	public Personality getPersonality(){
		return this.personality;
	}
	public Skillset getSkillset(){
		return scfield.getSkillset();
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
		if (health.addFood()) {
			resource.consumeResource (ResourceBehavior.Resource.food, foodConsumationModifier);
		}
		if (health.addWater()) {
			resource.consumeResource (ResourceBehavior.Resource.water, waterConsumationModifier);
		}
	}

	public void updateHealth ()
	{
		health.update ();
	}

}