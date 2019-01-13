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
       
        bool isSetUp = false;
        public GameObject[] on_to_off;
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
            if(on_to_off.Length == 0){
                return;
            }

            if (option_On == true)
            {
                option_On = false;

                for (int i = 0; content.Length > i; i++)
                {
                    content[i].SetActive(false);
                }
                Duo_Panel.GetComponent<Canvas>().enabled = true;

                for (int i = 0; on_to_off.Length > i; i++)
                {
                    on_to_off[i].SetActive(true);
                }
               

            }
            else
            {

                option_On = true;
                for (int i = 0; content.Length > i; i++)
                {
                    content[i].SetActive(true);
                }
                Duo_Panel.GetComponent<Canvas>().enabled = false;

                for (int i = 0; on_to_off.Length > i; i++)
                {
                    on_to_off[i].SetActive(false);
                }

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
