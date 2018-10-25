using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
	
    public class FirstAid : Photon.MonoBehaviour {
       GameObject p_plyer;
        public GameObject aidButton;
        PhotonView photonView;
	// Use this for initialization
	void Start () {
            photonView = GetComponent<PhotonView>();
	}
	
	// Update is called once per frame
	void Update () {
            if(p_plyer == null){
                p_plyer = PhotonControll.player;
            }
	}



        void OnCollisionStay(Collision col)
        {
            if(col.gameObject == p_plyer){

                if (aidButton == null)
                {
                    aidButton = p_plyer.GetComponent<UnityChanControlScriptWithRgidBody>().aidbutton;
                }

                col.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("GetAid",PhotonTargets.All);

                aidButton.SetActive(true);

                    
                photonView.RPC("DestroyAid", PhotonTargets.All);
            }

        }


        [PunRPC]
        public void DestroyAid(){
            Destroy(this.gameObject);
        }


}
}