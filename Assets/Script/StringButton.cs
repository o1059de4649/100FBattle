using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class StringButton : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler
    {

        public UnityChanControlScriptWithRgidBody _unityChanControl;
        public GameObject _string;
        public bool _isStringUse;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (_isStringUse)
            {
                _unityChanControl._stringEssence -= 0.05f;
            }

            if (_unityChanControl._stringEssence < 1)
            {
                _string.SetActive(false);
                _isStringUse = false;
            }
        }

        public void OnPointerEnter(PointerEventData pointerEventData)
        {

            if (_unityChanControl._stringEssence >= 1)
            {
                _isStringUse = true;
                _string.SetActive(true);
            }


        }

        public void OnPointerExit(PointerEventData pointerEventData)
        {
            _string.SetActive(false);
            _isStringUse = false;
        }

    }
}