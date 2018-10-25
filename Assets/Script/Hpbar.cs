using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class Hpbar : MonoBehaviour
    {
        Slider hpbarslider;

        GameObject p_player;
        // Use this for initialization
        void Start()
        {

           
            hpbarslider = GetComponent<Slider>();
        }

        // Update is called once per frame
        void Update()
        {
            if(p_player == null){
                p_player = PhotonControll.player;
            }

            if (PhotonControll.playerCreate > 0)
            {
                if (p_player)
                {
                    hpbarslider.value = p_player.GetComponent<UnityChanControlScriptWithRgidBody>().life;
                }
               
            }
        }
    }
}
