﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class Portal : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnTriggerEnter(Collider col)
        {
           
        }

        public void UsePortal(){
            SceneManager.LoadScene("Main");
        }
    }
}