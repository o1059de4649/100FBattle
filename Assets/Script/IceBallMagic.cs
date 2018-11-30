using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class IceBallMagic : MonoBehaviour
    {
        GameObject player;
        public string[] _enemy_OneHalf = {"golem(Clone)","Shell_Crab(Clone)"};
        public string[] _enemy_Three = {
            "SkeletonWizard(Clone)","SkeletonDarkKnight(Clone)","SkeletonWeak1(Clone)","SkeletonWeak1(Clone)","SkeletonWeak2(Clone)",
            "SkeletonMedium1(Clone)","SkeletonMedium2(Clone)","SkeletonStrong(Clone)","demon(Clone)","demonBoss(Clone)"};
        public string[] _enemy_Half = {"wizard(Clone)", "Imomusi(Clone)","ImomusiBoss(Clone)","Imomusi2(Clone)","icedemon(Clone)","ImomusiDark(Clone)" };
        public string[] _enemy_One = {"troll(Clone)", "goblin(Clone)","Hobgoblin(Clone)"};
        // Use this for initialization
        void Start()
        {
            player = GameObject.Find("Player");
            Destroy(this.gameObject, 100.0f);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider enemyObj)
        {


            if (enemyObj.tag == "Enemy")
            {
                for (int i = 0; _enemy_OneHalf.Length > i; i++)
                {
                    if (enemyObj.name == _enemy_Three[i])
                    {
                        enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 1.5f;
                        enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;

                    }
                }

                for (int i = 0; _enemy_Three.Length > i; i++)
                {
                    if (enemyObj.name == _enemy_Three[i])
                    {
                        enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 3;
                        enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;

                    }

                }

                for (int i = 0; _enemy_Three.Length > i; i++)
                {
                    if (enemyObj.name == _enemy_Half[i]){
                        enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 0.5f;
                    enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                    }
                }

                for (int i = 0; _enemy_Three.Length > i; i++)
                {
                    if (enemyObj.name == _enemy_One[i])
                    {
                        enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower;
                        enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                    }
                    Destroy(this.gameObject, 10.0f);
                }
            }
        }

       
    }
}