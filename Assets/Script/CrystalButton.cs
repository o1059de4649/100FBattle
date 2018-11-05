using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class CrystalButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        public UnityChanControlScriptWithRgidBody _unityChanControl;
        public GameObject _crystal;
        public bool _isCrystalUse;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (_isCrystalUse)
            {
                _unityChanControl._CrystalEssence -= 0.05f;
            }

            if (_unityChanControl._CrystalEssence < 1)
            {
                _crystal.SetActive(false);
                _isCrystalUse = false;
            }
        }

        public void OnPointerEnter(PointerEventData pointerEventData)
        {

            if (_unityChanControl._CrystalEssence >= 1)
            {
                _isCrystalUse = true;
                _crystal.SetActive(true);
            }


        }

        public void OnPointerExit(PointerEventData pointerEventData)
        {
            _crystal.SetActive(false);
            _isCrystalUse = false;
        }
    }
}