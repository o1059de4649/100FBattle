using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class SkyBoxTrigger : MonoBehaviour
    {
        public GameObject player_cam;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnTriggerEnter(Collider col)
        {
            if (col.gameObject == PhotonControll.player)
            {
                player_cam = col.gameObject.transform.Find("CameraStork/MainCamera").gameObject;
                player_cam.GetComponent<SkyBoxChanger>().OnNeon();
            }
        }

        public void OnTriggerExit(Collider col)
        {
            if (col.gameObject == PhotonControll.player)
            {
                player_cam = col.gameObject.transform.Find("CameraStork/MainCamera").gameObject;
                player_cam.GetComponent<SkyBoxChanger>().OffNeon();
            }
        }
    }
}
