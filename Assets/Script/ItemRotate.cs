using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        this.transform.Rotate(Random.Range(-90.0f,90.0f),Random.Range(-90.0f, 90.0f),Random.Range(-90.0f, 90.0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
