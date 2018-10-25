using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{

    public class SaveData : MonoBehaviour
    {
        public int p_Level;
        public int p_RedCube;
        public int p_BlueCube;
        public int p_GreenCube;
        public float p_exp;
        public float p_lifePlus;
        public float p_Protect;
        public float p_BulletPower;

        public string player_name;
       
        // Use this for initialization
        void Start()
        {
          
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Save(){
            p_exp = PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().exp_point;
            player_name = GameObject.Find("PhotonController").GetComponent<PhotonControll>().playerName.text;
            p_Level = PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().player_Level;
            p_RedCube = PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().red_Cube;
            p_BlueCube = PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().blue_Cube;
            p_GreenCube = PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().green_Cube;
            p_lifePlus = PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().lifePlus;
            p_Protect = PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().protectPlus;
            p_BulletPower = PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().bullet_Power;

            PlayerPrefs.SetFloat("Exp", p_exp);
            PlayerPrefs.SetInt("Level", p_Level);
            PlayerPrefs.SetString("playername", player_name);
            PlayerPrefs.SetInt("RedCube", p_RedCube);
            PlayerPrefs.SetInt("BlueCube", p_BlueCube);
            PlayerPrefs.SetInt("GreenCube", p_GreenCube);
            PlayerPrefs.SetFloat("LifePuls",p_lifePlus);
            PlayerPrefs.SetFloat("ProtectPlus", p_Protect);
            PlayerPrefs.SetFloat("BulletPower", p_BulletPower);


            PlayerPrefs.Save();
        }
    }

}
