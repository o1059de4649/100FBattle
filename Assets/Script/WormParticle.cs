﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class WormParticle : MonoBehaviour
    {
        public GameObject _user;

        private void Start()
        {
            
        }

        private void OnParticleCollision(GameObject playerObj)
        {
            if (playerObj.gameObject.tag == "Player" && playerObj.GetComponent<UnityChanControlScriptWithRgidBody>()._isStringed == false)
            {

                playerObj.GetComponent<UnityChanControlScriptWithRgidBody>().OnWormString();
                   
            }
        }

      
    }
}