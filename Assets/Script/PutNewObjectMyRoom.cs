using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class PutNewObjectMyRoom : MonoBehaviour
    {
        public GameObject _spawnPos;

        public InputField itemInputField;
        public GameObject[] gameObjects;

        public UnityChanControlScriptWithRgidBody _uc;
        public string[] item_name;
        // Use this for initialization
        void Start()
        {
            item_name = GameObject.Find("Portal").GetComponent<MyRoomSaveSystem>().item_name;

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ResetSpawn(){

            for (int i = 0; i < item_name.Length; i++)
            {
                if (itemInputField.text == item_name[i])
                {
                    GameObject _obj = GameObject.Find(item_name[i]);
                    _obj.transform.position = _spawnPos.transform.position;
                    _obj.GetComponent<MyRoomSaveSystem>().SaveMyRoom();
                }
            } 


           
        }

        public void PutOn()
        {

            for (int i = 0; i < item_name.Length; i++)
            {
                if (itemInputField.text == item_name[i] && _uc.itemList[i] >= 1)
                {
                    PlayerPrefs.DeleteKey(item_name[i]);
                    GameObject itemObj = Instantiate(gameObjects[i], _spawnPos.transform.position, Quaternion.identity);
                    itemObj.name = item_name[i];
                    _uc.itemList[i]--;
                    itemObj.GetComponent<MyRoomSaveSystem>().SaveMyRoom();
                }
            }

           
        }
    }
}