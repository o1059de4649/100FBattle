using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class ShowMoney : MonoBehaviour
    {
        public Text moneytext;
        public UnityChanControlScriptWithRgidBody player_u;
        // Use this for initialization
        void Start()
        {
            moneytext = GetComponent<Text>();
            player_u = GameObject.Find("Player").GetComponent<UnityChanControlScriptWithRgidBody>();
        }

        // Update is called once per frame
        void Update()
        {
            moneytext.text = (player_u._money + "G");
        }
    }
}
