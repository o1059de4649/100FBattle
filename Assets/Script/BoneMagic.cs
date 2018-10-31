using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class BoneMagic : MonoBehaviour
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
                if(enemyObj.name == "Skeleton(Clone)"){
                    
                    enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower;
                    enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                }

                if (enemyObj.name == "Imomusi(Clone)")
                {

                    enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 2;
                    enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                }
            }
        }

    }
}