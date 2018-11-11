using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class WeaponShopExit : MonoBehaviour, IPointerEnterHandler
    {
        public WeaponTable weaponTable;
        public SaveData saveData;
        // Use this for initialization
        void Start()
        {
            saveData = GetComponent<SaveData>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            weaponTable.OffShop();
            saveData.Save();
        }
    }
}