using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class BoneMagic : MonoBehaviour
    {
        public GameObject player;
        private string[] _enemyname_normal = {"SkeletonDarkKnight","icedemon","Skeleton","SkeletonWeak1","SkeletonWeak2",
            "SkeletonMedium1","SkeletonMedium2","demon","SkeletonStrong","demonBoss",
            "SkeletonWizard","wizard","troll","goblin","Hobgoblin","WarriorMachine","FlyMachine"};

        private string[] _enemyname_weak = { "ImomusiDark", "Imomusi", "ImomusiBoss", "Imomusi2" ,"Spider","SpiderBoss"};
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