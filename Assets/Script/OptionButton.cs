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
        bool isSetUp = false;
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
            if (!isSetUp)
            {
                for (int i = 0; content.Length > i; i++)
                {
                    content[i].SetActive(true);
                }
                Invoke("SetOff", 1.0f);
                isSetUp = true;
            }


        }

        public void OnPointerClick(PointerEventData eventData)
        {


            if (option_On == true)
            {
                option_On = false;

                for (int i = 0; content.Length > i; i++)
                {
                    content[i].SetActive(false);
                }
                Duo_Panel.GetComponent<Canvas>().enabled = true;

            }
            else
            {

                option_On = true;
                for (int i = 0; content.Length > i; i++)
                {
                    content[i].SetActive(true);
                }
                Duo_Panel.GetComponent<Canvas>().enabled = false;

            }
        }

        void SetOff()
        {
            for (int i = 0; content.Length > i; i++)
            {
                content[i].SetActive(false);
            }
        }
    }
}
