using UnityEngine;
using System.Collections;

public class Personality
{
	int D,I,S,C ;
	public Personality()
	{
		this.D = Random.Range (1, 10);
		this.I = Random.Range (1, 10);
		this.S = Random.Range (1, 10);
		this.C = Random.Range (1, 10);
	}
	public int getD(){
		return D;
	}
	public int getI(){
		return I;
	}
	public int getS(){
		return S;
	}
	public int getC(){
		return C;
	}
}
