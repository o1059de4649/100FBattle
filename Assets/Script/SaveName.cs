using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class SaveName : MonoBehaviour, IPointerEnterHandler
    {
        public Text player_name;
         string playername;


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            playername = player_name.text;

           
                PlayerPrefs.SetString("playername", playername);
            
        }
    }
}
