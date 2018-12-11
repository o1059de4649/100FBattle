using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class ElementMonsterAI : MonoBehaviour
    {
        SkeletonStatus skeletonStatus;
        // Use this for initialization
        void Start()
        {
            skeletonStatus = GetComponent<SkeletonStatus>();
            skeletonStatus._maxLife += GameObject.Find("Player").GetComponent<UnityChanControlScriptWithRgidBody>().player_Level * 15;
            skeletonStatus._life = skeletonStatus._maxLife;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}