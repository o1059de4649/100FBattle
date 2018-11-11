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
                if(enemyObj.name == "SkeletonDarkKnight(Clone)" || enemyObj.name == "icedemon(Clone)" ||
                   enemyObj.name == "Skeleton(Clone)" || enemyObj.name == "SkeletonWeak1(Clone)" || 
                   enemyObj.name == "SkeletonWeak2(Clone)" || enemyObj.name == "SkeletonMedium1(Clone)" ||
                   enemyObj.name == "SkeletonMedium2(Clone)" || enemyObj.name == "demon(Clone)" ||
                   enemyObj.name == "SkeletonStrong(Clone)" || enemyObj.name == "demonBoss(Clone)"||
                   enemyObj.name == "SkeletonWizard(Clone)"||enemyObj.name == "wizard(Clone)"||
                   enemyObj.name == "troll(Clone)"||enemyObj.name == "goblin(Clone)"||enemyObj.name == "Hobgoblin(Clone)")
                {
                    
                    enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower;
                    enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                }

                if (enemyObj.name == "ImomusiDark(Clone)" ||enemyObj.name == "Imomusi(Clone)" || enemyObj.name == "ImomusiBoss(Clone)" || enemyObj.name == "Imomusi2(Clone)")
                {

                    enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 3;
                    enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                }
            }
        }

    }
}