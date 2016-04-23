using UnityEngine;
using System.Collections;

public class SkyLight : MonoBehaviour {

    public Light sun;

    public float secondsInFullDay = 20f;
    public float marsDay = 24.6f;
    public float phobosDay = 7.66f;
    public float deimosDay = 30.35f;  
    public float currentTimeOfDay = 0;
    public int currentDayNumber = 1;

    public Light night; 


    public GameObject phobos;
    public float phobosOrbitTime;
    public float phobosCurrentTime;

    public GameObject deimos;
    public float deimosOrbitTime;
    public float deimosCurrentTime;


    [HideInInspector]
    public float timeMultiplier = 1f;
    float sunInitialIntensity;
    float nightInitialIntensity; 

    int radius = 1000;  

    void Start()
    {
        sunInitialIntensity = sun.intensity;
        nightInitialIntensity = night.intensity;
        phobosOrbitTime = secondsInFullDay / (marsDay / phobosDay);
        deimosOrbitTime = secondsInFullDay / (marsDay / deimosDay);
    }

    void Update()
    {
        // Update Moons positions
        phobosCurrentTime += (Time.deltaTime / phobosOrbitTime) * timeMultiplier;
        deimosCurrentTime += (Time.deltaTime / deimosOrbitTime) * timeMultiplier;

        if (phobosCurrentTime >= 1)
        {
            phobosCurrentTime = 0;
        }

        if (deimosCurrentTime >= 1)
        {
            deimosCurrentTime = 0;
        }

        deimos.transform.localRotation = Quaternion.Euler((deimosCurrentTime * 360f) - 90, 20, 0);
        phobos.transform.localRotation = Quaternion.Euler((phobosCurrentTime * 360f) - 90, 270, 0);

        deimos.transform.position = new Vector3(500 + radius * Mathf.Cos(deimosCurrentTime * Mathf.PI * 2), radius * Mathf.Sin(deimosCurrentTime * Mathf.PI * 2), 500);
        phobos.transform.position = new Vector3(500 ,radius * Mathf.Sin(phobosCurrentTime * Mathf.PI * 2), 500 + radius * Mathf.Cos(phobosCurrentTime * Mathf.PI * 2));

        // Update Sun and RealTime
        UpdateSun();
     
        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
            currentDayNumber = currentDayNumber + 1; 
        }
    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.77f)
        {
            intensityMultiplier = 0;
        }
        else if (currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }
        night.intensity = 1;
        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }
}

