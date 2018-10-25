using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{

    public class ChestItemSpawn : Photon.MonoBehaviour
    {
        Animation item_animation;

        public GameObject photonController = null;
        PhotonView item_PhotonView;
        public GameObject[] item;
       
        public bool spawn = false;


        // Use this for initialization
        void Start()
        {
            item_animation = GetComponent<Animation>();
            item_PhotonView = GetComponent<PhotonView>();

            if (photonController == null)
            {
                photonController = GameObject.Find("PhotonController");
            }
        }

        public void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "MyPlayer")
            {

                if (spawn == false)
                {
                    if (!collider.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.isMine)
                    {
                        return;
                    }
                    item_PhotonView.RPC("Spawn", PhotonTargets.All);
                    Invoke("Item_Spawn", 3.0f);
                   

                }
            }
        }



        public void Item_Spawn()
        {
            item_PhotonView.RPC("OnDestroy", PhotonTargets.All);
            if (!item_PhotonView)
            {
                return;
            }


            PhotonNetwork.Instantiate(item[0].name,
                                      this.transform.localPosition + new Vector3(3, 1, 1.5f),
                                      Quaternion.identity,
                                      0);



            PhotonNetwork.Instantiate(item[1].name,
                                      this.transform.localPosition + new Vector3(1.5f, 1, 1.5f),
                                      Quaternion.identity
                                      , 0);


            PhotonNetwork.Instantiate(item[2].name,
                                      this.transform.localPosition + new Vector3(-1.5f, 1, 1.5f),
                                      Quaternion.identity
                                      , 0);

            PhotonNetwork.Instantiate(item[3].name,
                                      this.transform.localPosition + new Vector3(-3, 1, 1.5f),
                                      Quaternion.identity,
                                      0);

        }








        [PunRPC]
        public void Spawn()
        {
            item_animation.Play();
            spawn = true;
        }

        [PunRPC]
        public void OnDestroy()
        {
            Destroy(this.gameObject);
        }

      
    }
}
