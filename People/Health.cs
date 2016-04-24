using UnityEngine;
using System.Collections;

public class Health
{
	// TODO: Consumption modifiers should be corresponding
	private const double waterConsumationModifier = 0.05;
	private const double foodConsumationModifier = 0.05;
	private const double happinessModifier = 0.1;

	enum Mood {Thriving, Happy, Medior, Sad, Angry, Furious};
	private Mood mood { get; set; }
	public double food;
    public double water;
    public double happiness;

	public Health(){
		this.food = 10;
		this.water = 10;
		this.mood = Mood.Thriving;
		calculateHappiness ();
        this.happiness = 10;
    }

	public void update(){
		this.water -= waterConsumationModifier;
		this.food -= foodConsumationModifier;
		if (this.food < 25 || this.water < 25) {
			this.happiness -= happinessModifier;
		}
	}

	public bool addFood(){
        if (food >= 90) {
			return false;
		}
		this.food += 10;
		return true;
	}

	public bool addWater(){
		if (water >= 90) {
			return false;
		}
		this.water += 10;
		return true;
	}

	void calculateHappiness ()
	{
        
		//throw new System.NotImplementedException ();
	}
}
