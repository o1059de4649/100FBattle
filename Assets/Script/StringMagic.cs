using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class StringMagic : MonoBehaviour
    {
        public GameObject player;
        private string[] _enemyname = {"SkeletonDarkKnight","Skeleton" 
                    ,"SkeletonWeak1", "SkeletonWeak2"
                    ,"SkeletonMedium1","SkeletonMedium2"
                    ,"golem" ,"icedemon"
                    ,"ImomusiDark", "SkeletonWizard"
                    ,"wizard","troll", "goblin", "Hobgoblin"};
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