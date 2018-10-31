using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class SkeletonSword : MonoBehaviour
    {
        BoxCollider boxCollider;
        public float _swordPower;
        // Use this for initialization
        void Start()
        {
            boxCollider = GetComponent<BoxCollider>();

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Player")
            {
                
                col.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().life -= _swordPower;
            }
        }
    }
}
