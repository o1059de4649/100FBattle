using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugeHouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.transform.Translate(Random.Range(-50, 50), 0, Random.Range(-50, 50));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
