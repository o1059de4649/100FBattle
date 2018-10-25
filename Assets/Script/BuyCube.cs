using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class BuyCube : MonoBehaviour, IPointerClickHandler
    {
   

        // Use this for initialization
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (this.gameObject.name == "RedCubeButton" && PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().red_Cube >= 10)
            {
                PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().red_Cube -= 10;
                PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().bullet_Power++;
            }

            if (this.gameObject.name == "BlueCubeButton" && PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().blue_Cube >= 10)
            {
                PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().blue_Cube -= 10;
                PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().protectPlus++;
            }

            if (this.gameObject.name == "GreenCubeButton" && PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().green_Cube >= 10)
            {
                PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().green_Cube -= 10;
                PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().lifePlus++;
            }


        }





    }
}
