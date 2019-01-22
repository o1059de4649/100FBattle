using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class GetItemObject : Photon.MonoBehaviour
    {

        float v;
        float h;
        private Vector3 velocity;
        bool _isGet = false;

        PhotonView photonView;
        GameObject targetObj;

        public string[] item_name;
        public PhotonView target_photonView;
        public int view_ID_target;
        // Use this for initialization
        void Start()
        {
            this.gameObject.GetPhotonView().TransferOwnership(0);
            this.gameObject.name = this.gameObject.name.Replace("(Clone)", "");
            Destroy(this.gameObject, 100.0f);
            photonView = GetComponent<PhotonView>();
        }

        // Update is called once per frame
        void Update()
        {



        }

        void OnTriggerStay(Collider col)
        {/*
            if (col.gameObject.name == "MyPlayer")
            {              
                if(!target_photonView){
                    return;
                }

                if (this.gameObject != PhotonNetwork.isMasterClient)
                {
                    return;
                }

                transform.LookAt(targetObj.transform);
                velocity = new Vector3(h, 0, v);
                velocity = transform.TransformDirection(velocity);
                transform.localPosition += velocity * Time.fixedDeltaTime * 10;
                v += Time.deltaTime;
            }*/
        }

        private void OnTriggerEnter(Collider col)
        {
            /*
            if(col.gameObject.tag == "Player"){
                targetObj = col.gameObject;
                target_photonView = targetObj.GetPhotonView();
                view_ID_target = target_photonView.viewID; 
                targetObj = PhotonView.Find(view_ID_target).gameObject;
            }*/
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "MyPlayer")
            {
                //破壊のためのオーナーID譲渡処理
                //this.gameObject.GetPhotonView().TransferOwnership(collision.gameObject.GetPhotonView().ownerId);

              

                if(this.transform.gameObject.name == "WoodItem"){
                    collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().wooditem++;
                }

                if (this.transform.gameObject.name == "StoneItem")
                {
                    collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().stoneitem++;
                }

                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().GetEssence();


                photonView.RPC("OnDestroy",PhotonTargets.All);

               
             
                //photonView.RPC("OnDestroy", PhotonTargets.All);
            }
        }

        [PunRPC]
        public void OnDestroy()
        {
            Destroy(this.gameObject);
        }

        void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
           
          
           

            if (stream.isWriting)
            {
               // stream.SendNext(view_ID_target);
                //stream.SendNext(targetObj);
            }
            else
            {
               // view_ID_target = (int)stream.ReceiveNext();
                //targetObj = (GameObject)stream.ReceiveNext();
            }

           

        }
    }
}