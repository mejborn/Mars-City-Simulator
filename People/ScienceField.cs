using UnityEngine;
using System.Collections;

class ScienceField
{
	private int science, engineering, farming;
	public enum Scfield 
	{
		Scientist,
		Engineer,
		Farmer,
		Tourist,
		Astronaut
	};

	public ScienceField(Scfield scfield)
	{
		instantiateVariables ();
		switch (scfield) {
		case Scfield.Scientist:
			this.science += 5;
			break;
		case Scfield.Engineer:
			this.engineering += 5;
			break;
		case Scfield.Farmer:
			this.farming += 5;
			break;
		case Scfield.Astronaut:
			this.science += 2;
			this.engineering += 3;
			break;
		default:
			break;
		}		
	}

	void instantiateVariables ()
	{
		Random rnd = new Random();
		this.science = rnd.Next (1, 4);
		this.engineering = rnd.Next (1, 4);
		this.farming = rnd.Next (1, 4);
	}

}
