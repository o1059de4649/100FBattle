using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class UziEquip : MonoBehaviour, IPointerEnterHandler
    {
        public GameObject Uzi_obj;
        public GameObject firebutton;
        GameObject user_player;
        PhotonView button_photonView;
        public GameObject weapon_off;
        public GameObject reload_button;


        public void OnPointerEnter(PointerEventData eventData)
        {
           
            
            button_photonView = GetComponent<PhotonView>();
            user_player = PhotonControll.player;
            Uzi_obj = user_player.transform.Find("Character1_Reference/Character1_Hips/Character1_Spine/Character1_Spine1/Character1_Spine2/Character1_RightShoulder/Character1_RightArm/Character1_RightForeArm/Character1_RightHand/Uzi").gameObject; ;
            button_photonView.RPC("OnUziEquip", PhotonTargets.All);
            Debug.Log("Equip");
        }

        [PunRPC]
        public void OnUziEquip()
        {
            if (!button_photonView)
            {
                return;
            }
            user_player.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("AllGunOff", PhotonTargets.All);
            user_player.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("UziOn", PhotonTargets.All);

            reload_button.SetActive(true);
            firebutton.SetActive(true);
        }
    }
}
