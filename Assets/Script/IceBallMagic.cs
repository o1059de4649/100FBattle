using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class IceBallMagic : MonoBehaviour
    {
        GameObject player;
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
                if (enemyObj.name == "golem(Clone)")
                {
                    enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 1.5f;
                    enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                }

                if (enemyObj.name == "Skeleton(Clone)" || enemyObj.name == "SkeletonWeak1(Clone)" || enemyObj.name == "SkeletonWeak2(Clone)" || enemyObj.name == "SkeletonMedium1(Clone)" || enemyObj.name == "SkeletonMedium2(Clone)" || enemyObj.name == "SkeletonStrong(Clone)" ||enemyObj.name == "demon(Clone)" || enemyObj.name == "demonBoss(Clone)")
                {
                    enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 3;
                    enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;

                }

                if (enemyObj.name == "Imomusi(Clone)" || enemyObj.name == "ImomusiBoss(Clone)" || enemyObj.name == "Imomusi2(Clone)" || enemyObj.name == "icedemon(Clone)")
                {
                    enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 3;
                    enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                }
                Destroy(this.gameObject, 10.0f);
            }
        }

       
    }
}