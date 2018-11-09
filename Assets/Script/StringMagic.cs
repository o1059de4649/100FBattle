﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class StringMagic : MonoBehaviour
    {
        public GameObject player;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnParticleCollision(GameObject enemyObj)
        {
            if (enemyObj.tag == "Enemy")
            {
                if (enemyObj.name == "SkeletonDarkKnight(Clone)"||enemyObj.name == "Skeleton(Clone)" || 
                    enemyObj.name == "SkeletonWeak1(Clone)" || enemyObj.name == "SkeletonWeak2(Clone)" ||
                    enemyObj.name == "SkeletonMedium1(Clone)" || enemyObj.name == "SkeletonMedium2(Clone)" ||
                    enemyObj.name == "golem(Clone)" || enemyObj.name == "icedemon(Clone)"|| 
                    enemyObj.name == "ImomusiDark(Clone)" || enemyObj.name == "SkeletonWizard(Clone)"||
                    enemyObj.name == "wizard(Clone)")
                {
                    enemyObj.GetComponent<SkeletonStatus>()._isString = true;

                }

              
            }
        }
    }
}