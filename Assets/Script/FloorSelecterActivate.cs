using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class FloorSelecterActivate : MonoBehaviour
    {
        public GameObject _floorSelecterButton;
        // Use this for initialization
        void Start()
        {
            _floorSelecterButton = GameObject.Find("Player/Canvas/FloorInput");
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.tag == "Player"){
                _floorSelecterButton.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider col)
        {
            if (col.gameObject.tag == "Player")
            {
                _floorSelecterButton.SetActive(false);
            }
        }

    }
}
