using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class Hpbar : MonoBehaviour
    {
        Slider hpbarslider;

        public GameObject p_player;
        // Use this for initialization
        void Start()
        {

           
            hpbarslider = GetComponent<Slider>();
        }

        // Update is called once per frame
        void Update()
        {



            hpbarslider.maxValue = p_player.GetComponent<UnityChanControlScriptWithRgidBody>().maxLife;
            hpbarslider.value = Mathf.RoundToInt(p_player.GetComponent<UnityChanControlScriptWithRgidBody>().life);
               
               

        }
    }
}
