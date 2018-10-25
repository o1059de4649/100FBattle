using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class M4Equip : MonoBehaviour, IPointerEnterHandler
    {
        public GameObject m4_obj;
        public GameObject firebutton;
        GameObject user_player;
        PhotonView button_photonView;
        public GameObject weapon_off;
        public GameObject reload_button;

        public void OnPointerEnter(PointerEventData eventData)
        {

            button_photonView = GetComponent<PhotonView>();
            user_player = PhotonControll.player;
            m4_obj = user_player.transform.Find("Character1_Reference/Character1_Hips/Character1_Spine/Character1_Spine1/Character1_Spine2/Character1_RightShoulder/Character1_RightArm/Character1_RightForeArm/Character1_RightHand/M4").gameObject; ;
            button_photonView.RPC("MfourEquip", PhotonTargets.All);
            Debug.Log("Equip");
        }

        [PunRPC]
        public void MfourEquip()
        {
            if (!button_photonView)
            {
                return;
            }
            user_player.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("AllGunOff", PhotonTargets.All);
            user_player.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("M4On", PhotonTargets.All);
            firebutton.SetActive(true);
            reload_button.SetActive(true);
        }
    }
}
