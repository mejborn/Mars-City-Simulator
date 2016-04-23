using UnityEngine;
using System.Collections;

class ScienceField
{
	private Scfield scfield;
	private Skillset skillset;

	public Skillset getSkillset(){
		return skillset;
	}

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
		this.scfield = scfield;

	}

	void instantiateVariables ()
	{
		int science, engineering, farming;

		science = Random.Range (1, 4);
		engineering = Random.Range (1, 4);
		farming = Random.Range (1, 4);

		switch (scfield) {
		case Scfield.Scientist:
			science += 5;
			break;
		case Scfield.Engineer:
			engineering += 5;
			break;
		case Scfield.Farmer:
			farming += 5;
			break;
		case Scfield.Astronaut:
			science += 2;
			engineering += 3;
			break;
		default:
			break;
		}
		this.skillset = new Skillset (science, engineering, farming);
	}
}
