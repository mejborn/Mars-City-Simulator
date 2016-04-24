using UnityEngine;
using System.Collections;

public class AnimatedRotation : MonoBehaviour {
    BuildingBehavior parentBuilding;
    float rotation = 0;

    // Use this for initialization
    void Start () {
        parentBuilding = gameObject.transform.parent.GetComponent<BuildingBehavior>();
    }
	
	// Update is called once per frame
	void Update () {
		if (parentBuilding.isActive)
        {
            rotation += 0.1f;
            this.transform.rotation = Quaternion.Euler(0, rotation, 0);
        }
	
	}
}
