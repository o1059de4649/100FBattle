using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class HandGunCount : MonoBehaviour
    {


        public void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.tag == "MyPlayer")
            {
                if (PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().have_handgun == 0)
                {
                    PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().have_handgun++;
                    this.gameObject.GetComponent<HandGunObj>().handgun_photonview.RPC("DestroyHandGun", PhotonTargets.All);
                }
            }
        }


       
       
    }
}