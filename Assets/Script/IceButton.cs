using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class IceButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        public UnityChanControlScriptWithRgidBody _unityChanControl;
        public GameObject _ice;
        public bool _isIceUse;

        public Slider slider;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
           
            slider.maxValue = _unityChanControl._maxEssence;
            slider.value = _unityChanControl._CrystalEssence;


            if (_unityChanControl._CrystalEssence < 1)
            {
                _ice.GetComponent<IceBallSpawner>()._shot = false;
                _isIceUse = false;
            }
        }

        public void OnPointerEnter(PointerEventData pointerEventData)
        {

            if (_unityChanControl._CrystalEssence >= 1)
            {
                _unityChanControl._CrystalEssence -= 1;
                _isIceUse = true;
      
                _ice.GetComponent<IceBallSpawner>()._shot = true;
            }


        }

        public void OnPointerExit(PointerEventData pointerEventData)
        {
            _ice.GetComponent<IceBallSpawner>()._shot = false;
            _isIceUse = false;
        }
    }
}