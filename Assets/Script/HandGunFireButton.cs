using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class HandGunFireButton : MonoBehaviour, IPointerEnterHandler
    {
        public GameObject handgun;
        public UnityChanControlScriptWithRgidBody p_ucrb;
        Text text;
        void Update(){
            if(text == null){
                text = GetComponentInChildren<Text>();
            }
            text.text = (p_ucrb.gun_magazine_bullet[0].ToString() + "/" + p_ucrb.smallbullet.ToString());
        }

        public void OnPointerEnter(PointerEventData eventData)
        {

            if (handgun == null)
            {
                handgun = PhotonControll.player.transform.Find("Character1_Reference/Character1_Hips/Character1_Spine/Character1_Spine1/Character1_Spine2/Character1_RightShoulder/Character1_RightArm/Character1_RightForeArm/Character1_RightHand/HandGun").gameObject;
            }

            handgun.GetComponent<HandGunShot>().HandGunShooting();
            PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().PistolFire();

        }
    }
}