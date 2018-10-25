using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class TPSCameraControll : Photon.MonoBehaviour

    {
       
        public float speed = 1;
        public GameObject _player;
        public CameraRotate cameraRotate;

        // Use this for initialization
        void Start()
        {
            cameraRotate = GameObject.Find("DualTouchControls/TurnAndLookTouchpad").GetComponent<CameraRotate>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            
            if(!photonView.isMine){
                return;
            }

            if (cameraRotate.m_Dragging == false)
            {
                return;
            }

            if (photonView.isMine)
            {
               
                float x= CrossPlatformInputManager.GetAxis("Mouse X");
                x = cameraRotate.newAngle_x.y;
                    transform.Rotate(0,-x * speed, 0);
 
            }

        }


    }
}
