using UnityEngine;
using System.Collections;

class Skillset
{
	public int science { get; }
	public int engineering { get; }
	public int farming { get; }

	public Skillset(int science, int engineering, int farming){
		this.science = science;
		this.engineering = engineering;
		this.farming = farming;
	}
}