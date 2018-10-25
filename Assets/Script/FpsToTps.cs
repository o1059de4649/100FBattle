using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class FpsToTps : MonoBehaviour,IPointerClickHandler
    {
        public GameObject fps_pos;
        public GameObject tps_pos;
        public GameObject cam;
        public bool on_fps = false; 
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPointerClick(PointerEventData eventData)
        {


            if (on_fps == false)
            {
                FpsOn();

            }else{
                FpsOff();
            }
        }

        public void FpsOn(){
            cam.transform.position = fps_pos.transform.position;
            on_fps = true;
        }

        public void FpsOff()
        {
            cam.transform.position = tps_pos.transform.position;
            on_fps = false;
        }

    }
}
