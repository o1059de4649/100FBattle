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
        public bool _isBoneUse;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(_isBoneUse){
                _unityChanControl._boneEssence -= 0.05f;
            }

            if(_unityChanControl._boneEssence < 1){
                _bone.SetActive(false);
                _isBoneUse = false;
            }
        }

        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            
            if(_unityChanControl._boneEssence >= 1){
                _isBoneUse = true;
                _bone.SetActive(true);
            }
           

        }

        public void OnPointerExit(PointerEventData pointerEventData)
        {
            _bone.SetActive(false);
            _isBoneUse = false;
        }

    }
}
