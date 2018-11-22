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

        public void PutOn()
        {

            if(itemInputField.text == item_name[0] && _uc.itemList[0] >= 1){
                PlayerPrefs.DeleteKey(item_name[0]);
                GameObject itemObj = Instantiate(gameObjects[0], _spawnPos.transform.position,Quaternion.identity);
                itemObj.name = item_name[0];
                _uc.itemList[0]--;
                itemObj.GetComponent<MyRoomSaveSystem>().SaveMyRoom();

            }

            if (itemInputField.text == item_name[1] && _uc.itemList[1] >= 1)
            {
                PlayerPrefs.DeleteKey(item_name[1]);
                GameObject itemObj = Instantiate(gameObjects[1], _spawnPos.transform.position, Quaternion.identity);
                itemObj.name = item_name[1];
                _uc.itemList[1]--;
                itemObj.GetComponent<MyRoomSaveSystem>().SaveMyRoom();
            }

            if (itemInputField.text == item_name[2] && _uc.itemList[2] >= 1)
            {
                PlayerPrefs.DeleteKey(item_name[2]);
                GameObject itemObj = Instantiate(gameObjects[2], _spawnPos.transform.position, Quaternion.identity);
                itemObj.name = item_name[2];
                _uc.itemList[2]--;
                itemObj.GetComponent<MyRoomSaveSystem>().SaveMyRoom();
            }

            if (itemInputField.text == item_name[3] && _uc.itemList[3] >= 1)
            {
                PlayerPrefs.DeleteKey(item_name[3]);
                GameObject itemObj = Instantiate(gameObjects[3], _spawnPos.transform.position, Quaternion.identity);
                itemObj.name = item_name[3];
                _uc.itemList[3]--;
                itemObj.GetComponent<MyRoomSaveSystem>().SaveMyRoom();
            }

            if (itemInputField.text == item_name[4] && _uc.itemList[4] >= 1)
            {
                PlayerPrefs.DeleteKey(item_name[4]);
                GameObject itemObj = Instantiate(gameObjects[4], _spawnPos.transform.position, Quaternion.identity);
                itemObj.name = item_name[4];
                _uc.itemList[4]--;
                itemObj.GetComponent<MyRoomSaveSystem>().SaveMyRoom();
            }

            if (itemInputField.text == item_name[5] && _uc.itemList[5] >= 1)
            {
                PlayerPrefs.DeleteKey(item_name[5]);
                GameObject itemObj = Instantiate(gameObjects[5], _spawnPos.transform.position, Quaternion.identity);
                itemObj.name = item_name[5];
                _uc.itemList[5]--;
                itemObj.GetComponent<MyRoomSaveSystem>().SaveMyRoom();
            }

            if (itemInputField.text == item_name[6] && _uc.itemList[6] >= 1)
            {
                PlayerPrefs.DeleteKey(item_name[6]);
                GameObject itemObj = Instantiate(gameObjects[6], _spawnPos.transform.position, Quaternion.identity);
                itemObj.name = item_name[6];
                _uc.itemList[6]--;
                itemObj.GetComponent<MyRoomSaveSystem>().SaveMyRoom();
            }

        }
    }
}