using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{

    public class DethDropItem : Photon.MonoBehaviour
    {
     
        public int[] guns;
        public int[] items;
        public PhotonView item_photonView;
        // Use this for initialization
        void Start()
        {
            item_photonView = GetComponent<PhotonView>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "MyPlayer"){
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().have_handgun = guns[0];
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().have_Uzi = guns[1];
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().have_ShotGun = guns[2];
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().have_M4 = guns[3];
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().have_M107 = guns[4];

                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().smallbullet += items[0];
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().middleBullet += items[1];
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().bigBullet += items[2];
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().shotGunBullet += items[3];
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().have_aid += items[4];

                item_photonView.RPC("ItemOnDestroy", PhotonTargets.All);

            }
        }

        [PunRPC]
        public void ItemOnDestroy()
        {
            Destroy(this.gameObject);
        }


    }
}