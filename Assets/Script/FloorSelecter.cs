using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class FloorSelecter : MonoBehaviour,IPointerDownHandler
    {
        public InputField inputField;
        string _floorLevel_string;
        public int _floorLevel_int;

        public EnemyCount enemyCount;
        // Use this for initialization
        void Start()
        {
            enemyCount = GameObject.Find("FloorControl").GetComponent<EnemyCount>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPointerDown(PointerEventData data){
            _floorLevel_string = inputField.text;
            Int32.TryParse(_floorLevel_string, out _floorLevel_int);

            if(enemyCount._MaxFloorLevel >= _floorLevel_int){
                enemyCount._floorLevel = _floorLevel_int;
            }
           
        }
    }
}
