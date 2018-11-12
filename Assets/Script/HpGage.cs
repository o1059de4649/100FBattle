using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class HpGage : MonoBehaviour
    {
        public Text _hpText;
        public UnityChanControlScriptWithRgidBody _ucrb;
        // Use this for initialization
        void Start()
        {
            _hpText = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            _hpText.text = ("HP" + _ucrb.life + "/" + _ucrb.maxLife);
        }
    }
}