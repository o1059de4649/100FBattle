using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class UziFireButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public GameObject uzi;
        Text text;
        public float time;
        bool shotOn  = false;
        public float gun_rpm = 1000;
        public UnityChanControlScriptWithRgidBody p_ucrb;

        void Update()
        {
            time += Time.deltaTime;
            if (shotOn == true)
            {
              
                if (time >= 60/gun_rpm)
                {
                    uzi.GetComponent<UziShot>().UziShooting();
                    time = 0;
                }
            }

          

            if (text == null)
            {
                text = GetComponentInChildren<Text>();
            }
            text.text = (p_ucrb.gun_magazine_bullet[1].ToString() + "/" + p_ucrb.smallbullet.ToString());
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            shotOn = true;
            if (uzi == null)
            {
                uzi = PhotonControll.player.transform.Find("Character1_Reference/Character1_Hips/Character1_Spine/Character1_Spine1/Character1_Spine2/Character1_RightShoulder/Character1_RightArm/Character1_RightForeArm/Character1_RightHand/Uzi").gameObject;
            }
            PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().PistolFire();

        }

        public void OnPointerExit(PointerEventData eventData){
            shotOn = false;
        }
    }
}