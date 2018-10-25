using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityStandardAssets.CrossPlatformInput
{
    public class M107Obj : MonoBehaviour
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
                if (PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().have_M107 == 0)
                {
                    PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().have_M107++;
                    this.gameObject.GetComponent<PhotonView>().RPC("DestroyM107", PhotonTargets.All);
                }
            }
        }


        [PunRPC]
        void DestroyM107()
        {
            Destroy(this.gameObject);
        }
    }
}
