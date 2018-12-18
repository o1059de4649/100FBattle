using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class KukuriAttackButton : MonoBehaviour,IPointerUpHandler,IPointerDownHandler,IPointerEnterHandler
    {
        public GameObject player;
        Animator anim;
        float _enterTime;
        public BoxCollider _boxCollider_right;
        public BoxCollider _boxCollider_left;
        bool isEnter = false;
        public float _rpm = 1;

        // Use this for initialization
        void Start()
        {
            anim = player.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if(isEnter == true){
                _enterTime += Time.deltaTime;

            }else{
                
            }
           
            if (0 < _enterTime && _enterTime <= 1.0f * _rpm)
            {
                
                anim.SetTrigger("Kukuri2");
            }

            if (1.0f * _rpm < _enterTime && _enterTime <= 2.0f * _rpm)
            {
                
                anim.SetTrigger("Kukuri3");
            }

            if (2.0f * _rpm < _enterTime && _enterTime <= 3.0f * _rpm)
            {
                
                anim.SetTrigger("Kukuri4");
                _enterTime = 0;
            }

        }

        public void OnPointerDown(PointerEventData eventData){
            
            if (_enterTime <= 0)
            {
                
                anim.SetTrigger("Kukuri1");
            }
            isEnter = true;

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
          


         
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isEnter = false;
            AttackOff();
        }

        void AttackOff(){
          
            anim.SetTrigger("Kukurioff");
            _enterTime = 0;
        }

       
    }
}