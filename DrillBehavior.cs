﻿using UnityEngine;
using System.Collections;

public class DrillBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = Vector3.up * (Mathf.Sin(Time.time) - 1.0f);
	
	}
}
