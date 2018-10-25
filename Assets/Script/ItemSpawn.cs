using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{

    public class ItemSpawn : Photon.MonoBehaviour
    {
        public GameObject photonController = null;
        public PhotonView item_PhotonView;
        public GameObject[] item;
        public int random_item = 0;
       
        void Start()
        {
            
            item_PhotonView = GetComponent<PhotonView>();
            Item_Spawn();
            item_PhotonView.RPC("ItemDestroy", PhotonTargets.All);
            if(photonController == null){
                photonController = GameObject.Find("PhotonController");
            }
        }


        public void Item_Spawn(){
            item_PhotonView.RPC("ItemStart", PhotonTargets.All);
           
            if(random_item <= 15){
                PhotonNetwork.Instantiate(item[0].name,
                                             this.transform.position,
                                             new Quaternion(Random.Range(0.0f, 90f), Random.Range(0.0f, 90f), Random.Range(0.0f, 90.0f), 1),
                                             0);
            }

            if (16 <= random_item && random_item <= 30)
            {
                PhotonNetwork.Instantiate(item[1].name,
                                             this.transform.position,
                                             new Quaternion(Random.Range(0.0f, 90f), Random.Range(0.0f, 90f), Random.Range(0.0f, 90.0f), 1),
                                             0);
            }

            if (31 <= random_item && random_item <= 45)
            {
                PhotonNetwork.Instantiate(item[2].name,
                                             this.transform.position,
                                             new Quaternion(Random.Range(0.0f, 90f), Random.Range(0.0f, 90f), Random.Range(0.0f, 90.0f), 1),
                                             0);
            }

            if (46 <= random_item && random_item <= 60)
            {
                PhotonNetwork.Instantiate(item[3].name,
                                             this.transform.position,
                                             new Quaternion(Random.Range(0.0f, 90f), Random.Range(0.0f, 90f), Random.Range(0.0f, 90.0f), 1),
                                             0);
            }

            if (61 <= random_item && random_item <= 70)
            {
                PhotonNetwork.Instantiate(item[4].name,
                                             this.transform.position,
                                             new Quaternion(Random.Range(0.0f, 90f), Random.Range(0.0f, 90f), Random.Range(0.0f, 90.0f), 1),
                                             0);
            }

            if (71 <= random_item && random_item <= 80)
            {
                PhotonNetwork.Instantiate(item[5].name,
                                             this.transform.position,
                                             new Quaternion(Random.Range(0.0f, 90f), Random.Range(0.0f, 90f), Random.Range(0.0f, 90.0f), 1),
                                             0);
            }

            if (81 <= random_item && random_item <= 84)
            {
                PhotonNetwork.Instantiate(item[6].name,
                                             this.transform.position,
                                             new Quaternion(Random.Range(0.0f, 90f), Random.Range(0.0f, 90f), Random.Range(0.0f, 90.0f), 1),
                                             0);
            }

            if (85 <= random_item && random_item <= 88)
            {
                PhotonNetwork.Instantiate(item[7].name,
                                             this.transform.position,
                                             new Quaternion(Random.Range(0.0f, 90f), Random.Range(0.0f, 90f), Random.Range(0.0f, 90.0f), 1),
                                             0);
            }

            if (89 <= random_item && random_item <= 92)
            {
                PhotonNetwork.Instantiate(item[8].name,
                                             this.transform.position,
                                             new Quaternion(Random.Range(0.0f, 90f), Random.Range(0.0f, 90f), Random.Range(0.0f, 90.0f), 1),
                                             0);
            }
                    
            if (93 <= random_item && random_item <= 96)
            {
                PhotonNetwork.Instantiate(item[9].name,
                                             this.transform.position,
                                             new Quaternion(Random.Range(0.0f, 90f), Random.Range(0.0f, 90f), Random.Range(0.0f, 90.0f), 1),
                                             0);
            }

            if (97 <= random_item && random_item <= 101)
            {
                PhotonNetwork.Instantiate(item[10].name,
                                             this.transform.position,
                                             new Quaternion(Random.Range(0.0f, 90f), Random.Range(0.0f, 90f), Random.Range(0.0f, 90.0f), 1),
                                             0);
            }
               
                 
        }

        [PunRPC]
        public void ItemStart(){
            random_item = Random.Range(0, 102);
        }

        [PunRPC]
        public void ItemDestroy(){
            Destroy(this.gameObject);
        }
    }
}
