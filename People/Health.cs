using UnityEngine;
using System.Collections;

class Health
{
	enum Mood {Thriving, Happy, Medior, Sad, Angry, Furious};
	private Mood mood { get; }
	private int food { get; }
	private int water { get; }
	private int happiness;
}
