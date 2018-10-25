using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class M107FireButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public GameObject m107;
        Text text;
        public float time;
        bool shotOn = false;
        public float gun_rpm = 14;

        void FixedUpdate()
        {
            time += Time.deltaTime;
            if (shotOn == true)
            {
               
                if (time >= 60 / gun_rpm)
                {
                    m107.GetComponent<M107Shot>().M107Shooting();
                    time = 0;
                }
            }



            if (text == null)
            {
                text = GetComponentInChildren<Text>();
            }
            text.text = (PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().bigBullet.ToString());
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            shotOn = true;
            if (m107 == null)
            {
                m107 = PhotonControll.player.transform.Find("Character1_Reference/Character1_Hips/Character1_Spine/Character1_Spine1/Character1_Spine2/Character1_RightShoulder/Character1_RightArm/Character1_RightForeArm/Character1_RightHand/M107").gameObject;
            }
            PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().ShotGunFire();

        }

        public void OnPointerExit(PointerEventData eventData)
        {
            shotOn = false;
        }
    }
}
