using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class StringMagic : MonoBehaviour
    {
        public GameObject player;
        public string[] _enemyname = {"SkeletonDarkKnight(Clone)","Skeleton(Clone)" 
                    ,"SkeletonWeak1(Clone)", "SkeletonWeak2(Clone)"
                    ,"SkeletonMedium1(Clone)","SkeletonMedium2(Clone)"
                    ,"golem(Clone)" ,"icedemon(Clone)"
                    ,"ImomusiDark(Clone)", "SkeletonWizard(Clone)"
                    ,"wizard(Clone)","troll(Clone)", "goblin(Clone)", "Hobgoblin(Clone)"};
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

                for (int i = 0; _enemyname.Length > i;i++)
                {
                    if (enemyObj.name == _enemyname[i])
                    {
                        enemyObj.GetComponent<SkeletonStatus>()._isString = true;
                    }
                }
              
            }
        }
    }
}