using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class WeaponShopExit : MonoBehaviour, IPointerEnterHandler
    {
        public WeaponTable weaponTable;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            weaponTable.OffShop();
        }
    }
}