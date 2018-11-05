using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class FireButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
    {

        public UnityChanControlScriptWithRgidBody _unityChanControl;
        public GameObject _fire;
        public bool _isFireUse;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (_isFireUse)
            {
                _unityChanControl._fireEssence -= 0.05f;
            }

            if (_unityChanControl._fireEssence < 1)
            {
                _fire.SetActive(false);
                _isFireUse = false;
            }
        }

        public void OnPointerEnter(PointerEventData pointerEventData)
        {

            if (_unityChanControl._fireEssence >= 1)
            {
                _isFireUse = true;
                _fire.SetActive(true);
            }


        }

        public void OnPointerExit(PointerEventData pointerEventData)
        {
            _fire.SetActive(false);
            _isFireUse = false;
        }
    }
}