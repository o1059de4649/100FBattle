using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput{
public class CameraControll : MonoBehaviour
{
        
    public GameObject camera_player;
    GameObject maincamera;
    Vector3 playerPos;
    Vector3 cameraPos;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
           
           


            if (PhotonControll.playerCreate > 0 && camera_player == null)
        {




            camera_player = PhotonControll.player.transform.Find("CameraStork").gameObject;
            playerPos = camera_player.transform.position;
            this.transform.position = new Vector3(playerPos.x + 0.5f, playerPos.y, playerPos.z -2f);
            this.transform.parent = camera_player.transform;

            if (maincamera == null)
            {
                maincamera = PhotonControll.player.transform.Find("CameraStork/MainCamera").gameObject;
                maincamera.GetComponent<TPSControll_y>().enabled = true;
            }
        }


    }
}
}
