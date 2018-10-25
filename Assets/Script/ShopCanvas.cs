using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class ShopCanvas : MonoBehaviour
    {
        public Canvas canvas;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "MyPlayer")
            {
                collider.GetComponent<UnityChanControlScriptWithRgidBody>().PlayerSave();
                canvas.enabled = true;
            }
        }

        public void OnTriggerExit(Collider collider)
        {
            if (collider.gameObject.tag == "MyPlayer")
            {
                canvas.enabled = false;
            }
        }
    }
}