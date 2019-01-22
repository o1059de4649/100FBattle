using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerPlane : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "MyPlayer"){
            collision.gameObject.transform.position = this.gameObject.transform.position;
        }
    }
}
