using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class LogOutButton : MonoBehaviour, IPointerClickHandler
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            GameObject.Find("PhotonController").GetComponent<PhotonControll>().LogoutGame();
        }
    }
}
