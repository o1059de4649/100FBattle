using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.eulerAngles += new Vector3(0, 5, 0); 
	}
}
