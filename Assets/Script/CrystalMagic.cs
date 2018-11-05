﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class CrystalMagic : MonoBehaviour
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
            player.GetComponent<UnityChanControlScriptWithRgidBody>().OnCrystal();

            if (enemyObj.tag == "Enemy")
            {
                if(enemyObj.name == "golem(Clone)"){
                    enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 0.1f;
                    enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                }

                if (enemyObj.name == "Skeleton(Clone)" || enemyObj.name == "SkeletonWeak1(Clone)" || enemyObj.name == "SkeletonWeak2(Clone)" || enemyObj.name == "SkeletonMedium1(Clone)" || enemyObj.name == "SkeletonMedium2(Clone)"|| enemyObj.name == "SkeletonStrong(Clone)")
                {
                    enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 0.1f;
                    enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;

                }

                if (enemyObj.name == "Imomusi(Clone)" || enemyObj.name == "ImomusiBoss(Clone)")
                {
                    enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 0.1f;
                    enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                }
            }
        }
    }
}