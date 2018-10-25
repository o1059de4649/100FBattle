using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class Shildscript : Photon.MonoBehaviour
    {
        public GameObject p_player;
        public GameObject col_player;
        public GameObject col_otherPlayer;
        GameObject otherShirld;
        GameObject MyShirld;
        PhotonView p_photonView;
        PhotonView photonView;
        // Use this for initialization

        // Update is called once per frame
        void Update()
        {
            if (p_player == null)
            {
                p_player = PhotonControll.player;
            }

            if(photonView == null){
                photonView = GetComponent<PhotonView>();
            }


        }

        void OnCollisionStay(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
               

            }

            if (col.gameObject == p_player && p_player.GetComponent<UnityChanControlScriptWithRgidBody>().protect == 0)
            {

                Debug.Log("colMyPlayer");
               
                p_player.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("Shirld", PhotonTargets.AllBuffered);
                photonView.RPC("Destroy", PhotonTargets.All);

            }

           

        }
       
       

       

       
       
        [PunRPC]
        public void Destroy()
        {
           
            Destroy(this.gameObject);

        }
       
    }


}