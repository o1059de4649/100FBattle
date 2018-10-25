using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


    public class BloomOn : MonoBehaviour, IPointerDownHandler
        {
            public bool bloom = true;
            
            // Use this for initialization
            void Start()
            {

            }

            // Update is called once per frame
            void Update()
            {

            }

            public void OnPointerDown(PointerEventData eventData)
            {

                if (bloom == true)
                {
                    bloom = false;
                BloomEffectOf();
            }else{
                bloom = true;
                BloomEffectOn();
            }

            }

        void BloomEffectOn(){
           
        }

        void BloomEffectOf(){
            
        }
        }

