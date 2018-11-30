using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class BoneMagic : MonoBehaviour
    {
        public GameObject player;
        public string[] _enemyname_normal = {"SkeletonDarkKnight(Clone)","icedemon(Clone)","Skeleton(Clone)","SkeletonWeak1(Clone)","SkeletonWeak2(Clone)",
            "SkeletonMedium1(Clone)","SkeletonMedium2(Clone)","demon(Clone)","SkeletonStrong(Clone)","demonBoss(Clone)",
            "SkeletonWizard(Clone)","wizard(Clone)","troll(Clone)","goblin(Clone)","Hobgoblin(Clone)"};

        public string[] _enemyname_weak = { "ImomusiDark(Clone)", "Imomusi(Clone)", "ImomusiBoss(Clone)", "Imomusi2(Clone)" };
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

                for (int i = 0; _enemyname_normal.Length > i; i++){
                    if (enemyObj.name == _enemyname_normal[i])
                    {
                        enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower;
                        enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                    }

                }


                for (int i = 0; _enemyname_weak.Length > i; i++)
                {
                    if (enemyObj.name == _enemyname_weak[i])
                    {

                        enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 3;
                        enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                    }
                }
            }
        }

    }
}