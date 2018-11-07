using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class EssenceUpdate : MonoBehaviour,IPointerEnterHandler
    {

        GameObject player;
        // Use this for initialization
        void Start()
        {
            player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            if (player.GetComponent<UnityChanControlScriptWithRgidBody>()._money >= 100)
            {
                player.GetComponent<UnityChanControlScriptWithRgidBody>()._money -= 100;
                player.GetComponent<UnityChanControlScriptWithRgidBody>()._maxEssencePlus++;
            }
        }

    }
}
