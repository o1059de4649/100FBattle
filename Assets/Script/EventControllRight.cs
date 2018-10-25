using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class EventControllRight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        GameObject p_player;

        void Update()
        {
            if (p_player == null)
            {
                p_player = PhotonControll.player;
            }
        }

        void FixedUpdate()
        {

        }



        public void OnPointerEnter(PointerEventData eventData)
        {

            p_player.GetComponent<UnityChanControlScriptWithRgidBody>().RightOn();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            p_player.GetComponent<UnityChanControlScriptWithRgidBody>().RightOff();
        }
    }
}