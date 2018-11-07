using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class WeaponTable : MonoBehaviour
    {
        public Canvas player_canvas;
        public Canvas playerCamera_canvas;

        public Canvas weaponShop_canvas;
        // Use this for initialization
        void Start()
        {
            player_canvas = GameObject.Find("Player/Canvas").GetComponent<Canvas>();
            playerCamera_canvas = GameObject.Find("DualTouchControls").GetComponent<Canvas>();

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.tag == "Player"){
                weaponShop_canvas.enabled = true;
                player_canvas.enabled = false;
                playerCamera_canvas.enabled = false;
            }
        }

        public void OnTriggerExit(Collider col)
        {
            if (col.gameObject.tag == "Player")
            {
                OffShop();
            }
        }

        public void OffShop()
        {
            weaponShop_canvas.enabled = false;
            player_canvas.enabled = true;
            playerCamera_canvas.enabled = true;
        }
    }
}