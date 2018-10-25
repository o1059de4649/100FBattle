using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool jump = false;
        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPointerDown(PointerEventData eventData){
            
            if(jump == false){
                jump = true;
            }

        }

        public void OnPointerUp(PointerEventData eventData){
            jump = false;
        }

        void OffJump(){
            jump = false;
        }
    }
}