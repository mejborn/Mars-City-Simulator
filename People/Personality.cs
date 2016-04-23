using UnityEngine;
using System.Collections;

class Personality
{
	int D,I,S,C;
	public Personality()
	{
		Random rnd = new Random ();
		this.D = rnd.Next (1, 10);
		this.I = rnd.Next (1, 10);
		this.S = rnd.Next (1, 10);
		this.C = rnd.Next (1, 10);
	}
}
