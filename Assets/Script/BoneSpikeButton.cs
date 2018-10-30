using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class BoneSpikeButton : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
    {
        public UnityChanControlScriptWithRgidBody _unityChanControl;
        public GameObject _bone;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            if(_unityChanControl._boneEssence >= 1){
                _unityChanControl._boneEssence--;
                _bone.SetActive(true);
            }
           

        }

        public void OnPointerExit(PointerEventData pointerEventData)
        {
            _bone.SetActive(false);
        }

    }
}
