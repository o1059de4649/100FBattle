using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class TPSControll_y : Photon.MonoBehaviour

    {
        public float speed = 1;
        public GameObject y_CameraTarget;

        public CameraRotate cameraRotate;
        public float y;
       
        // Use this for initialization
        void Start()
        {
            cameraRotate = GameObject.Find("DualTouchControls/TurnAndLookTouchpad").GetComponent<CameraRotate>();

        }

        // Update is called once per frame
        public void FixedUpdate()
        {
            
           


           

            if(cameraRotate.m_Dragging == false){
                return;
            }

           
           
                
                
                y = cameraRotate.newAngle_y.x;
                y_CameraTarget.transform.Rotate(-y * speed,0, 0);



           


        }




    }

}