using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class FloorDestroy : MonoBehaviour
    {
        public GameObject _destroyObj;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player"){
                GameObject enemyDeath = GameObject.FindWithTag("Death");
                Destroy(enemyDeath);
                Destroy(_destroyObj);
            }
        }
    }
}