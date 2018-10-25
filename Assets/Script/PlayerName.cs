using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class PlayerName : MonoBehaviour
    {
        Text name_text;
        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(!PhotonControll.player){
                return;
            }


            if(name_text == null){
                name_text = GetComponent<Text>();
            }
                name_text.text = (PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().player_Name);

        }
    }
}

