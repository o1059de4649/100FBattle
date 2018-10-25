using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{

    public class ChestSpawner : Photon.MonoBehaviour
    {
        PhotonView photonView;
        public GameObject photonController = null;
        public GameObject chest;
        public bool spawned = false;
        // Use this for initialization

        void Start()
        {
            photonView = GetComponent<PhotonView>();
            if (photonController == null)
            {
                photonController = GameObject.Find("PhotonController");
            }
        }

        // Update is called once per frame
        void Update()
        {

            if (photonController.GetComponent<PhotonControll>().createroom == 1 && spawned == false)
            {
                PhotonNetwork.Instantiate(chest.name,
                                          this.transform.position,
                                          this.transform.rotation,
                                          0);
                
                photonView.RPC("OnSpawn", PhotonTargets.All);
            }

            if(photonController.GetComponent<PhotonControll>().createroom == 0 && spawned == true){
                photonView.RPC("OffSpawn", PhotonTargets.All);
            }
        }

        [PunRPC]
        private void OnSpawn()
        {
            spawned = true;
        }

        [PunRPC]
        private void OffSpawn()
        {
            spawned = false;
        }


    }
}