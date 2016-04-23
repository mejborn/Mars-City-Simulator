using UnityEngine;
using System.Collections;

class Health
{
	// TODO: Consumption modifiers should be corresponding
	private const double waterConsumationModifier = 0.01;
	private const double foodConsumationModifier = 0.01;
	private const double happinessModifier = 0.1;

	enum Mood {Thriving, Happy, Medior, Sad, Angry, Furious};
	private Mood mood { get; set; }
	private double food;
	private double water;
	private double happiness;

	public Health(){
		this.food = 100;
		this.water = 100;
		this.mood = Mood.Thriving;
		calculateHappiness ();
	}

	public void update(){
		this.water -= waterConsumationModifier;
		this.food -= foodConsumationModifier;
		if (this.food < 25 || this.water < 25) {
			this.happiness -= happinessModifier;
		}
	}

	public bool addFood(){
		if (food >= 95) {
			return false;
		}
		this.food += 10;
		return true;
	}
	public bool addWater(){
		if (water >= 95) {
			return false;
		}
		this.water += 10;
		return true;
	}

	void calculateHappiness ()
	{
		throw new System.NotImplementedException ();
	}

}
