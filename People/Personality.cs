using UnityEngine;
using System.Collections;

class Personality
{
	int D,I,S,C;
	public Personality()
	{
		this.D = Random.Range (1, 10);
		this.I = Random.Range (1, 10);
		this.S = Random.Range (1, 10);
		this.C = Random.Range (1, 10);
	}
}
