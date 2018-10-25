using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{

    public class CameraStork : Photon.MonoBehaviour
    {
        public GameObject p_player;
        PhotonView p_photonView;
        float eulerAngleX;
       
        // Use this f

        void Start()
        {
            p_photonView = GetComponent<PhotonView>();
        }

        // Update is called once per frame
        void Update()
        {
           
            if (!p_photonView.isMine)
            {
                return;
            }

            if(transform.localEulerAngles.z == 180 && transform.localEulerAngles.x < 90){
                transform.localEulerAngles = new Vector3(80, 0, 0);
            }

            if (transform.localEulerAngles.z == 180 && transform.localEulerAngles.x > 270)
            {
                transform.localEulerAngles = new Vector3(280, 0, 0);
            }

            if(transform.localEulerAngles.x > 80 && transform.localEulerAngles.x < 180){
                transform.localEulerAngles = new Vector3(80,0,0);
            }

            if (transform.localEulerAngles.x < 280 && transform.localEulerAngles.x >= 180)
            {
                transform.localEulerAngles = new Vector3(280, 0, 0);
            }
           
          
            if (PhotonControll.playerCreate > 0)
            {
                p_player = PhotonControll.player;
                this.transform.position = p_player.transform.position + new Vector3(0,1.4f,0);

            }

            if (PhotonControll.playerCreate > 0)
            {


            }


        }



    }
}
