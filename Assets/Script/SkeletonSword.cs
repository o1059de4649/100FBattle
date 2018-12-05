﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class SkeletonSword : MonoBehaviour
    {
        BoxCollider boxCollider;
        public float _swordPower;
        // Use this for initialization
        void Start()
        {
            boxCollider = GetComponent<BoxCollider>();
            boxCollider.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.tag == "Enemy" && this.gameObject.GetComponentInParent<PlayerTeamAI>() != null){
                col.gameObject.GetComponent<SkeletonStatus>()._life -= _swordPower + this.gameObject.GetComponentInParent<PlayerTeamAI>()._attackPlus;
            }

            if (col.gameObject.tag == "Player")
            {
                if(col.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>()._isCrystal == true){
                    col.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().life -= _swordPower / 3;
                    return;
                }
                col.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().life -= _swordPower;
            }

            if(col.gameObject.tag =="Team"){
                col.gameObject.GetComponent<PlayerTeamAI>()._life -= _swordPower;
            }
        }
    }
}
