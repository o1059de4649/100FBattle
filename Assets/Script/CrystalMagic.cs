using System.Collections;
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
                
                    enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 0.1f;
                    enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
               
            }
        }
    }
}