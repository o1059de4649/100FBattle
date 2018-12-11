using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class FireMagic : MonoBehaviour
    {

        public GameObject player;
        private string[] _enemyname_Three = {"golem","icedemon","Shell_Crab", "Imomusi","ImomusiBoss" , "Imomusi2" ,"ImomusiDark","Spider"};
        private string[] _enemyname_LittleDamage = {"wizard","SkeletonWizard","SkeletonDarkKnight","Skeleton","SkeletonWeak1",
            "SkeletonWeak2", "SkeletonMedium1","SkeletonMedium2","SkeletonStrong"};
        private string[] _enemyname_normal = {"troll","goblin","Hobgoblin"};
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
                for (int i = 0; _enemyname_Three.Length > i;i++)
                {
                    if (enemyObj.name == _enemyname_Three[i])
                    {
                        enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 3;
                        enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                    }
                }

                for (int i = 0; _enemyname_LittleDamage.Length > i; i++)
                {
                    if (enemyObj.name == _enemyname_LittleDamage[i])
                    {
                        enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 0.1f;
                        enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                    }
                }

               

                for (int i = 0; _enemyname_normal.Length > i; i++)
                {
                    if (enemyObj.name == _enemyname_normal[i])
                    {
                        enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower;
                        enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                    }
                }
            }
        }
    }
}