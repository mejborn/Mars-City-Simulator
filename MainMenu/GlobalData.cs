using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalData : MonoBehaviour {

    public List<string> names;
    public List<string> classes;

    // Use this for initialization
    void Start () {
        names = new List<string>();
        classes = new List<string>();

        DontDestroyOnLoad(this);
    }
}
