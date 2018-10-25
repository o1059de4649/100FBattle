using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.transform.Rotate(0, Random.Range(-90.0f, 90.0f), 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
