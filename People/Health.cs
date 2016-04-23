using UnityEngine;
using System.Collections;

class Health
{
	private readonly double waterConsumationModifier = 0.01;
	private readonly double foodConsumationModifier = 0.01;
	private readonly double happinessModifier = 0.1;

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

	void calculateHappiness ()
	{
		throw new System.NotImplementedException ();
	}

}
