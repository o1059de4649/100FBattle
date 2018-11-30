using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class MyRoomObjectMovement : MonoBehaviour
    {
       

        public GameObject _spawnPos;
        public GameObject player;
        UnityChanControlScriptWithRgidBody _uc;
        public string[] item_name;

       
        // Use this for initialization
        void Start()
        {
            _spawnPos = GameObject.Find("PlayerMyRoom/CameraStork/MainCamera/SpawnPos");
            player = GameObject.FindWithTag("Player");
            _uc = player.GetComponent<UnityChanControlScriptWithRgidBody>();
            item_name = GetComponent<MyRoomSaveSystem>().item_name;

           
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Move()
        {
            transform.position = _spawnPos.transform.position;
        }

        public void RotateMoveRight(){
            transform.eulerAngles += new Vector3(0, 5, 0);
        }

        public void RotateMoveLeft(){
            transform.eulerAngles += new Vector3(0, -5, 0);
        }

        public void ResetPosition()
        {
            transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);
            transform.position += new Vector3(0, 3, 0);
        }

        public void PickUp(){
            for(int i = 0;i < item_name.Length;i++){
                if (this.gameObject.name == item_name[i])
                {
                    _uc.itemList[i]++;
                }
            }
            /*
            if(this.gameObject.name == item_name[0]){
                
                _uc.itemList[0]++;
            }

            if (this.gameObject.name == item_name[1])
            {
           
                _uc.itemList[1]++;
            }

            if (this.gameObject.name == item_name[2])
            {
          
                _uc.itemList[2]++;
            }

            if (this.gameObject.name == item_name[3])
            {
               
                _uc.itemList[3]++;
            }

            if (this.gameObject.name == item_name[4])
            {
               
                _uc.itemList[4]++;
            }

            if (this.gameObject.name == item_name[5])
            {
               
                _uc.itemList[5]++;
            }

            if (this.gameObject.name == item_name[6])
            {
               
                _uc.itemList[6]++;
            }*/

            Destroy(this.gameObject);
        }

    }
}