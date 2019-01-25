using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class ShowItemCount : MonoBehaviour
    {
        public Text _haveItem;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //for文よりも軽量に動作させるため記述
            if (this.gameObject.name == "ButtonSpawnWood")
            {
                _haveItem.text = GetComponentInParent<UnityChanControlScriptWithRgidBody>().wooditem.ToString();
            }

            if (this.gameObject.name == "ButtonSpawnStone")
            {
                _haveItem.text = GetComponentInParent<UnityChanControlScriptWithRgidBody>().stoneitem.ToString();
            }

            if (this.gameObject.name == "ButtonSpawnMeat")
            {
                _haveItem.text = GetComponentInParent<UnityChanControlScriptWithRgidBody>().meatitem.ToString();
            }

            if (this.gameObject.name == "ButtonSpawnBlueMetal")
            {
                _haveItem.text = GetComponentInParent<UnityChanControlScriptWithRgidBody>().blueMetalitem.ToString();
            }

            if (this.gameObject.name == "ButtonSpawnNuts")
            {
                _haveItem.text = GetComponentInParent<UnityChanControlScriptWithRgidBody>().nutsItem.ToString();
            }

            if (this.gameObject.name == "ButtonSpawnGlass")
            {
                _haveItem.text = GetComponentInParent<UnityChanControlScriptWithRgidBody>().glassItem.ToString();
            }

            if (this.gameObject.name == "ButtonSpawnBottle")
            {
                _haveItem.text = GetComponentInParent<UnityChanControlScriptWithRgidBody>().bottleItem.ToString();
            }

            if (this.gameObject.name == "ButtonSpawnWaterBottle")
            {
                _haveItem.text = GetComponentInParent<UnityChanControlScriptWithRgidBody>().water_bottleItem.ToString();
            }

            if (this.gameObject.name == "ButtonSpawnNutsBottle")
            {
                _haveItem.text = GetComponentInParent<UnityChanControlScriptWithRgidBody>().nuts_bottleItem.ToString();
            }
        }
    }
}