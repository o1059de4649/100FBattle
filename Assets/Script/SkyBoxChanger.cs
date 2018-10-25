using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class SkyBoxChanger : MonoBehaviour
    {
        public Material default_sky;
        public Material change_to_sky;
        Skybox default_skybox;

        // Use this for initialization
        void Start()
        {
            default_skybox = GetComponent<Skybox>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

       
            

        public void OnNeon(){
            default_skybox.enabled = false;
           RenderSettings.skybox = change_to_sky;
            DynamicGI.UpdateEnvironment();
        }

        public void OffNeon(){
            default_skybox.enabled = true;
            RenderSettings.skybox = default_sky;
            DynamicGI.UpdateEnvironment();
        }

    }
}
