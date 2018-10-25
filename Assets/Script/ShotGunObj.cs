using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityStandardAssets.CrossPlatformInput
{
    public class ShotGunObj : MonoBehaviour
    {
        PhotonView photonView;
        // Use this for initialization
        void Start()
        {
            photonView = GetComponent<PhotonView>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.tag == "MyPlayer")
            {
                if (PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().have_ShotGun == 0)
                {
                    PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().have_ShotGun++;
                    this.gameObject.GetComponent<PhotonView>().RPC("DestroyShotGun", PhotonTargets.All);
                }
            }
        }


        [PunRPC]
        void DestroyShotGun()
        {
            Destroy(this.gameObject);
        }
    }
}

