using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class OptionButton : MonoBehaviour, IPointerClickHandler
    {
        public bool option_On = false;

        public GameObject[] content;
        GameObject Duo_Panel;
        InRoomChat inRoomChat;
        // Use this for initialization
        void Start()
        {
            Duo_Panel = GameObject.Find("DualTouchControls");
        }

        // Update is called once per frame
        void Update()
        {
            /*if(inRoomChat == null){
                inRoomChat = GameObject.Find("ChatManager").GetComponent<InRoomChat>();
            }*/
           
        }

        public void OnPointerClick(PointerEventData eventData)
        {
         

            if (option_On == true)
            {
                option_On = false;
                content[0].SetActive(false);
                content[1].SetActive(false);
                content[2].SetActive(false);
                content[3].SetActive(false);
                content[4].SetActive(false);
                Duo_Panel.GetComponent<Canvas>().enabled = true;
                inRoomChat.IsVisible = false;
            }else{
                option_On = true;
                content[0].SetActive(true);
                content[1].SetActive(true);
                content[2].SetActive(true);
                content[3].SetActive(true);
                content[4].SetActive(true);
                Duo_Panel.GetComponent<Canvas>().enabled = false;
                inRoomChat.IsVisible = true;
            }
        }





    }
    }
