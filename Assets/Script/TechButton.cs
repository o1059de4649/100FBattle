using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{


    public class TechButton : MonoBehaviour, IPointerDownHandler
        {
        
            public bool tech_mode = true;
        public Text c_text;
        public TouchPad touchPad;
            // Use this for initialization
            void Start()
            {
            touchPad = GameObject.Find("DualTouchControls/TurnAndLookTouchpad").GetComponent<TouchPad>();
            }

            // Update is called once per frame
            void Update()
            {

            }

            public void OnPointerDown(PointerEventData eventData)
            {

            if(tech_mode == true)
                {
                    tech_mode = false;
                BloomEffectOff();
            }else{
                tech_mode = true;
                BloomEffectOn();
            }

            }

        void BloomEffectOn(){
            touchPad.controlStyle = TouchPad.ControlStyle.Relative;
            c_text.text = ("Relativeモード");
        }

        void BloomEffectOff(){
            touchPad.controlStyle = TouchPad.ControlStyle.Swipe;
            c_text.text = ("Swipeモード");
        }
        }
    }