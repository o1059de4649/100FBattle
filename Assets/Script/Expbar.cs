using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class Expbar : MonoBehaviour
    {
        Slider expbarslider;
        public Text exp_text;
        public GameObject p_player;

        public float bar_exp_point;
        public float bar_Max_exp_point;


        // Use this for initialization
        void Start()
        {


            expbarslider = GetComponent<Slider>();
        }

        // Update is called once per frame
        void Update()
        {
            


            bar_exp_point = p_player.GetComponent<UnityChanControlScriptWithRgidBody>().exp_point;
            bar_Max_exp_point = p_player.GetComponent<UnityChanControlScriptWithRgidBody>().Max_exp_point;

            exp_text.text = (p_player.GetComponent<UnityChanControlScriptWithRgidBody>().player_Level.ToString());
            expbarslider.value = bar_exp_point / bar_Max_exp_point;

        }
    }
}
