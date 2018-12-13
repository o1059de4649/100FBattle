using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class MagicPowerUpdate : MonoBehaviour,IPointerEnterHandler
    {
        GameObject player;

        public float _maxCost = 0;
        public Text costText;
        float _showCost;
        // Use this for initialization
        void Start()
        {
            player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
            _maxCost = PlayerPrefs.GetFloat("MagicPowerPlus", 0) * 250;
            _showCost = _maxCost + 100;
            costText.text = ("コスト" + _showCost);
        }

        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            if (player.GetComponent<UnityChanControlScriptWithRgidBody>()._money >= 100 + _maxCost)
            {
                player.GetComponent<UnityChanControlScriptWithRgidBody>()._money -= 100 + _maxCost;
                player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPowerPlus++;


                _maxCost = player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPowerPlus * 500;


                PlayerPrefs.SetFloat("MagicPowerPlus", player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPowerPlus);


            }
        }

    }
}