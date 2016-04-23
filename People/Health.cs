using UnityEngine;
using System.Collections;

class Health
{
	enum Mood {Thriving, Happy, Medior, Sad, Angry, Furious};
	private Mood mood { get; set; }
	private int food;
	private int water;
	private int happiness;
}
