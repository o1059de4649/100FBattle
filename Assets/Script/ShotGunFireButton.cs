using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class ShotGunFireButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public GameObject shotGun;
        Text text;
        public float time;
        bool shotOn = false;
        public float gun_rpm = 60;
        public UnityChanControlScriptWithRgidBody p_ucrb;

        void Update()
        {
            time += Time.deltaTime;
            if (shotOn == true)
            {
                
                if (time >= 60 / gun_rpm)
                {
                    shotGun.GetComponent<ShotGunShot>().ShotGunShooting();
                    time = 0;
                }
            }



            if (text == null)
            {
                text = GetComponentInChildren<Text>();
            }
            text.text = (p_ucrb.gun_magazine_bullet[2].ToString() + "/" + p_ucrb.shotGunBullet.ToString());
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            shotOn = true;
            if (shotGun == null)
            {
                shotGun = PhotonControll.player.transform.Find("Character1_Reference/Character1_Hips/Character1_Spine/Character1_Spine1/Character1_Spine2/Character1_RightShoulder/Character1_RightArm/Character1_RightForeArm/Character1_RightHand/ShotGun").gameObject;
            }
            PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().ShotGunFire();

        }

        public void OnPointerExit(PointerEventData eventData)
        {
            shotOn = false;
        }
    }
}