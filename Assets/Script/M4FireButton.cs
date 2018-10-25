using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class M4FireButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public GameObject m4;
        Text text;
        public float time;
        bool shotOn = false;
        public float gun_rpm = 80;
        public UnityChanControlScriptWithRgidBody p_ucrb;

        void FixedUpdate()
        {
            time += Time.deltaTime;
            if (shotOn == true)
            {
               
                if (time >= 60 / gun_rpm)
                {
                    m4.GetComponent<M4Shot>().M4Shooting();
                    time = 0;
                }
            }



            if (text == null)
            {
                text = GetComponentInChildren<Text>();
            }
            text.text = (p_ucrb.gun_magazine_bullet[3].ToString() + "/" + p_ucrb.middleBullet.ToString());
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            shotOn = true;
            if (m4 == null)
            {
                m4 = PhotonControll.player.transform.Find("Character1_Reference/Character1_Hips/Character1_Spine/Character1_Spine1/Character1_Spine2/Character1_RightShoulder/Character1_RightArm/Character1_RightForeArm/Character1_RightHand/M4").gameObject;
            }
            PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().ShotGunFire();

        }

        public void OnPointerExit(PointerEventData eventData)
        {
            shotOn = false;
        }
    }
}