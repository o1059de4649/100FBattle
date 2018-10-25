using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{

    public class ADSButton : MonoBehaviour,IPointerClickHandler
    {
        public bool ads_On = false;
        public GameObject fps_button;
        public GameObject cam;
        public GameObject anim_player;
        public TPSCameraControll tpsCameraControll_x;
        public TPSControll_y tpsControll_y;
        public float scorpe = 6;
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
           

            if(ads_On == false){
                fps_button.GetComponent<FpsToTps>().FpsOn();
                cam.GetComponent<Camera>().fieldOfView /= scorpe;
                ads_On = true;
                anim_player.GetComponent<UnityChanControlScriptWithRgidBody>().ADSOnAnim();
                tpsCameraControll_x.speed /= scorpe;
                tpsControll_y.speed /= scorpe;
            }else{
                fps_button.GetComponent<FpsToTps>().FpsOff();
                cam.GetComponent<Camera>().fieldOfView *= scorpe;
                ads_On = false;
                anim_player.GetComponent<UnityChanControlScriptWithRgidBody>().ADSOffAnim();
                tpsCameraControll_x.speed *= scorpe;
                tpsControll_y.speed *= scorpe;

            }
        }
    }
}