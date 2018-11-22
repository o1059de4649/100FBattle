using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class MyRoomSaveSystem : MonoBehaviour
    {
        public GameObject[] _obj;
        public bool[] _isobj;
        public string[] dataString;
        public string[] _splitType;
        public string[] item_name = {"Mirror","Table","Chair","SpotLight","Cabinet","Vase","Portal"};
        void Start()
        {
            

            if(this.gameObject.name == item_name[0] && PlayerPrefs.HasKey(item_name[0]) == true){
                //座標挿入
                dataString[0] = PlayerPrefs.GetString(this.gameObject.name, "default");
                _splitType = dataString[0].Split(new []{ ',', '(', ')'},System.StringSplitOptions.RemoveEmptyEntries);

                this.gameObject.transform.position = new Vector3 (float.Parse(_splitType[0]),float.Parse(_splitType[1]),float.Parse(_splitType[2]));
                this.gameObject.transform.localEulerAngles = new Vector3(float.Parse(_splitType[3]), float.Parse(_splitType[4]), float.Parse(_splitType[5]));
            }

            if (this.gameObject.name == item_name[1] && PlayerPrefs.HasKey(item_name[1]) == true)
            {
                //座標挿入
                dataString[0] = PlayerPrefs.GetString(this.gameObject.name, "default");
                _splitType = dataString[0].Split(new[] { ',', '(', ')' }, System.StringSplitOptions.RemoveEmptyEntries);

                this.gameObject.transform.position = new Vector3(float.Parse(_splitType[0]), float.Parse(_splitType[1]), float.Parse(_splitType[2]));
                this.gameObject.transform.localEulerAngles = new Vector3(float.Parse(_splitType[3]), float.Parse(_splitType[4]), float.Parse(_splitType[5]));
            }

            if (this.gameObject.name == item_name[2] && PlayerPrefs.HasKey(item_name[2]) == true)
            {
                //座標挿入
                dataString[0] = PlayerPrefs.GetString(this.gameObject.name, "default");
                _splitType = dataString[0].Split(new[] { ',', '(', ')' }, System.StringSplitOptions.RemoveEmptyEntries);

                this.gameObject.transform.position = new Vector3(float.Parse(_splitType[0]), float.Parse(_splitType[1]), float.Parse(_splitType[2]));
                this.gameObject.transform.localEulerAngles = new Vector3(float.Parse(_splitType[3]), float.Parse(_splitType[4]), float.Parse(_splitType[5]));
            }

            if (this.gameObject.name == item_name[3] && PlayerPrefs.HasKey(item_name[3]) == true)
            {
                //座標挿入
                dataString[0] = PlayerPrefs.GetString(this.gameObject.name, "default");
                _splitType = dataString[0].Split(new[] { ',', '(', ')' }, System.StringSplitOptions.RemoveEmptyEntries);

                this.gameObject.transform.position = new Vector3(float.Parse(_splitType[0]), float.Parse(_splitType[1]), float.Parse(_splitType[2]));
                this.gameObject.transform.localEulerAngles = new Vector3(float.Parse(_splitType[3]), float.Parse(_splitType[4]), float.Parse(_splitType[5]));
            }

            if (this.gameObject.name == item_name[4] && PlayerPrefs.HasKey(item_name[4]) == true)
            {
                //座標挿入
                dataString[0] = PlayerPrefs.GetString(this.gameObject.name, "default");
                _splitType = dataString[0].Split(new[] { ',', '(', ')' }, System.StringSplitOptions.RemoveEmptyEntries);

                this.gameObject.transform.position = new Vector3(float.Parse(_splitType[0]), float.Parse(_splitType[1]), float.Parse(_splitType[2]));
                this.gameObject.transform.localEulerAngles = new Vector3(float.Parse(_splitType[3]), float.Parse(_splitType[4]), float.Parse(_splitType[5]));
            }

            if (this.gameObject.name == item_name[5] && PlayerPrefs.HasKey(item_name[5]) == true)
            {
                //座標挿入
                dataString[0] = PlayerPrefs.GetString(this.gameObject.name, "default");
                _splitType = dataString[0].Split(new[] { ',', '(', ')' }, System.StringSplitOptions.RemoveEmptyEntries);

                this.gameObject.transform.position = new Vector3(float.Parse(_splitType[0]), float.Parse(_splitType[1]), float.Parse(_splitType[2]));
                this.gameObject.transform.localEulerAngles = new Vector3(float.Parse(_splitType[3]), float.Parse(_splitType[4]), float.Parse(_splitType[5]));
            }

            if (this.gameObject.name == item_name[6] && PlayerPrefs.HasKey(item_name[6]) == true)
            {
                //座標挿入
                dataString[0] = PlayerPrefs.GetString(this.gameObject.name, "default");
                _splitType = dataString[0].Split(new[] { ',', '(', ')' }, System.StringSplitOptions.RemoveEmptyEntries);

                this.gameObject.transform.position = new Vector3(float.Parse(_splitType[0]), float.Parse(_splitType[1]), float.Parse(_splitType[2]));
                this.gameObject.transform.localEulerAngles = new Vector3(float.Parse(_splitType[3]), float.Parse(_splitType[4]), float.Parse(_splitType[5]));
            }
        }

      
        void Update()
        {
            if(this.transform.position.y < -1.0f){
                this.transform.position =new Vector3(this.transform.position.x,5.0f,this.transform.position.z);
            }
        }

        public void SaveMyRoom()//位置保存
        {
            //Mirror(試作)
            if (this.gameObject.name == item_name[0])
            {
                _obj[0] = this.gameObject;
                dataString[0] = _obj[0].transform.position.ToString() + "," + _obj[0].transform.localEulerAngles.ToString();
              
                PlayerPrefs.SetString(this.gameObject.name, dataString[0]);
                PlayerPrefs.Save();
            }

            //Table(試作)
            if (this.gameObject.name == item_name[1])
            {
                _obj[0] = this.gameObject;
                dataString[0] = _obj[0].transform.position.ToString() + "," + _obj[0].transform.localEulerAngles.ToString();

                PlayerPrefs.SetString(this.gameObject.name, dataString[0]);
                PlayerPrefs.Save();
            }

            //Chair(試作)
            if (this.gameObject.name == item_name[2])
            {
                _obj[0] = this.gameObject;
                dataString[0] = _obj[0].transform.position.ToString() + "," + _obj[0].transform.localEulerAngles.ToString();

                PlayerPrefs.SetString(this.gameObject.name, dataString[0]);
                PlayerPrefs.Save();
            }

            //SpotLight(試作)
            if (this.gameObject.name == item_name[3])
            {
                _obj[0] = this.gameObject;
                dataString[0] = _obj[0].transform.position.ToString() + "," + _obj[0].transform.localEulerAngles.ToString();

                PlayerPrefs.SetString(this.gameObject.name, dataString[0]);
                PlayerPrefs.Save();
            }

            //Cabinet(試作)
            if (this.gameObject.name == item_name[4])
            {
                _obj[0] = this.gameObject;
                dataString[0] = _obj[0].transform.position.ToString() + "," + _obj[0].transform.localEulerAngles.ToString();

                PlayerPrefs.SetString(this.gameObject.name, dataString[0]);
                PlayerPrefs.Save();
            }

            //Vase(試作)
            if (this.gameObject.name == item_name[5])
            {
                _obj[0] = this.gameObject;
                dataString[0] = _obj[0].transform.position.ToString() + "," + _obj[0].transform.localEulerAngles.ToString();

                PlayerPrefs.SetString(this.gameObject.name, dataString[0]);
                PlayerPrefs.Save();
            }

            //Vase(試作)
            if (this.gameObject.name == item_name[6])
            {
                _obj[0] = this.gameObject;
                dataString[0] = _obj[0].transform.position.ToString() + "," + _obj[0].transform.localEulerAngles.ToString();

                PlayerPrefs.SetString(this.gameObject.name, dataString[0]);
                PlayerPrefs.Save();
            }
        }



        //Move
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                this.gameObject.GetComponent<MyRoomObjectMovement>().enabled = true;
                this.gameObject.GetComponentInChildren<Canvas>().enabled = true;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if(other.gameObject.tag == "Player"){
                SaveMyRoom();
                this.gameObject.GetComponent<MyRoomObjectMovement>().enabled = false;
                this.gameObject.GetComponentInChildren<Canvas>().enabled = false;
            }
        }
    }
}