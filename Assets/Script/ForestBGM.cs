using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{

    public class ForestBGM : MonoBehaviour
    {
        public AudioSource forest_audioSource;
        AudioClip audioClip;
       

        // Use this for initialization
        void Start()
        {
            forest_audioSource = GetComponent<AudioSource>();
           
        }

        // Update is called once per frame
        void Update()
        {
          
        }

        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "MyPlayer"){
                this.forest_audioSource.Play();
            }

        }

        private void OnTriggerExit(Collider col)
        {
            if (col.gameObject.tag == "MyPlayer")
            {
                this.forest_audioSource.Stop();
            }
        }
    }
}
