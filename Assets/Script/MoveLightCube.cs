using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLightCube : MonoBehaviour {
    float time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, time*16,0);
	}
}
