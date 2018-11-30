using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class FireMagic : MonoBehaviour
    {

        public GameObject player;
        public string[] _enemyname_Three = {"golem(Clone)","icedemon(Clone)","Shell_Crab(Clone)", "Imomusi(Clone)","ImomusiBoss(Clone)" , "Imomusi2(Clone)" ,"ImomusiDark(Clone)"};
        public string[] _enemyname_LittleDamage = {"wizard(Clone)","SkeletonWizard(Clone)","SkeletonDarkKnight(Clone)","Skeleton(Clone)","SkeletonWeak1(Clone)",
            "SkeletonWeak2(Clone)", "SkeletonMedium1(Clone)","SkeletonMedium2(Clone)","SkeletonStrong(Clone)"};
        public string[] _enemyname_normal = {"troll(Clone)","goblin(Clone)","Hobgoblin(Clone)"};
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