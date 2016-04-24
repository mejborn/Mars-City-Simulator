using UnityEngine;
using System.Collections;

public class SolarTracker : MonoBehaviour {
    SkyLight skylight;
    float angle;
    Vector3 offset = Vector3.up * 1.15f;

    // Use this for initialization
    void Start () {
        skylight = FindObjectsOfType<Terrain>()[0].GetComponent<SkyLight>();
    }
	
	// Update is called once per frame
	void Update () {
        if (skylight != null)
        {
            if (skylight.currentTimeOfDay < 0.2f)
                angle = -45;
            else if (skylight.currentTimeOfDay < 0.8f)
                angle = (skylight.currentTimeOfDay - 0.2f) * 90.0f / 0.6f - 45.0f;
            else
                angle = 45.0f - (skylight.currentTimeOfDay - 0.8f) * 90.0f / 0.2f;


            transform.localPosition = Vector3.zero;
            transform.rotation = Quaternion.Euler(angle, 0, 0);
            transform.localPosition = offset;
        }
    }
}
