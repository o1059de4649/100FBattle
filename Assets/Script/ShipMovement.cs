using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityStandardAssets.CrossPlatformInput
{
    public class ShipMovement : Photon.MonoBehaviour
    {

        Rigidbody rb;
        bool ship_move_ref = false;
        public GameStart gameStart;
        PhotonView photonView;
        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            photonView = GetComponent<PhotonView>();
        }

        // Update is called once per frame
        void Update()
        {
            
            if (gameStart.game_start == true && ship_move_ref == false)
            {
                rb.velocity = new Vector3(0, 0, 5);
            }

            if (gameStart.game_start == true && ship_move_ref == true)
            {
                rb.velocity = new Vector3(0, 0, -5);
            }





        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Reflect1")
            {
                photonView.RPC("ReflecOn",PhotonTargets.All);
            }

            if (collision.gameObject.tag == "Reflect2")
            {
                photonView.RPC("ReflecOff", PhotonTargets.All);
            }
        }

        [PunRPC]
        public void ReflecOn(){
            ship_move_ref = true;
        }

        [PunRPC]
        public void ReflecOff()
        {
            ship_move_ref = false;
        }
    }
}
