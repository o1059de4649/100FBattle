using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class WormSkill : MonoBehaviour
    {
        public GameObject _parrticle;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.tag == "Player"){
                _parrticle.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider col)
        {
            if (col.gameObject.tag == "Player")
            {
                _parrticle.SetActive(false);
            }
        }
    }
}