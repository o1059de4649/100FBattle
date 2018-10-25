using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{

    public class HandGunObj : MonoBehaviour
    {
        public PhotonView handgun_photonview;

        void Start()
        {
            handgun_photonview = GetComponent<PhotonView>();
        }

        [PunRPC]
        void DestroyHandGun()
        {
            Destroy(this.gameObject);
        }


    }
}
