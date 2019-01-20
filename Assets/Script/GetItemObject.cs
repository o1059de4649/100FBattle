using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class GetItemObject : MonoBehaviour
    {

        float v;
        float h;
        private Vector3 velocity;
        bool _isGet = false;

        PhotonView photonView;
        GameObject targetObj;

        public string[] item_name;
        // Use this for initialization
        void Start()
        {
            this.gameObject.name = this.gameObject.name.Replace("(Clone)", "");
            Destroy(this.gameObject, 100.0f);
            photonView = GetComponent<PhotonView>();
        }

        // Update is called once per frame
        void Update()
        {



        }

        void OnTriggerStay(Collider col)
        {
            if (col.gameObject.tag == "Player")
            {
                targetObj = col.gameObject;
                transform.LookAt(targetObj.transform);
                velocity = new Vector3(h, 0, v);
                velocity = transform.TransformDirection(velocity);
                transform.localPosition += velocity * Time.fixedDeltaTime * 10;
                v += Time.deltaTime;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                if(this.transform.gameObject.name == "WoodItem"){
                    collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().wooditem++;
                }

                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().GetEssence();
                photonView.RPC("OnDestroy", PhotonTargets.All);
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
                stream.SendNext(targetObj);
            }
            else
            {
                targetObj = (GameObject)stream.ReceiveNext();
            }
        }
    }
}