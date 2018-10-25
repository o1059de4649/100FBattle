using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class BigBullet : Photon.MonoBehaviour
    {

        PhotonView bullet_photonView;
        GameObject p_player;


        void Update()
        {
            if (p_player == null)
            {
                p_player = PhotonControll.player;
            }



        }

        void OnCollisionStay(Collision col)
        {
            if (col.gameObject == p_player)
            {


                bullet_photonView = GetComponent<PhotonView>();
                p_player.GetComponent<UnityChanControlScriptWithRgidBody>().exp_point += 10;
                p_player.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("BigBulletGet", PhotonTargets.All);
                bullet_photonView.RPC("DestroyBullet", PhotonTargets.All);


            }
        }



        [PunRPC]
        void DestroyBullet()
        {


            Destroy(this.gameObject);
        }


    }
}
