﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class ShopButton : MonoBehaviour, IPointerClickHandler
    {
        public bool shop_On = false;

        public Canvas shop_canvas;
        public Canvas player_canvas;
        public GameObject Duo_Panel;
        public Canvas this_Canvas;

        // Use this for initialization
        void Start()
        {
            Duo_Panel = GameObject.Find("DualTouchControls");
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPointerClick(PointerEventData eventData)
        {

             
                shop_canvas.enabled = true;
                player_canvas = PhotonControll.player.GetComponentInChildren<Canvas>();
                player_canvas.enabled = false;
                Duo_Panel.GetComponent<Canvas>().enabled = false;
            this_Canvas.enabled = false;

        }





    }
}