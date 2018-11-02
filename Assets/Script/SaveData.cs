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
        public float p_maxLife;
        public float p_Protect;
        public float p_Power;

        public float p_magicPower;
        public float p_money;

        public int p_MaxFloor;
        public string player_name;
        public GameObject player;
        public EnemyCount enemyCount;

        public int p_floorLevel;
        // Use this for initialization
        void Start()
        {
            player = GameObject.Find("Player");
            enemyCount = GameObject.Find("FloorControl").GetComponent<EnemyCount>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Save(){
            p_exp = player.GetComponent<UnityChanControlScriptWithRgidBody>().exp_point;

            p_Level = player.GetComponent<UnityChanControlScriptWithRgidBody>().player_Level;
            p_RedCube = player.GetComponent<UnityChanControlScriptWithRgidBody>().red_Cube;
            p_BlueCube = player.GetComponent<UnityChanControlScriptWithRgidBody>().blue_Cube;
            p_GreenCube = player.GetComponent<UnityChanControlScriptWithRgidBody>().green_Cube;
            p_Protect = player.GetComponent<UnityChanControlScriptWithRgidBody>().protectPlus;


            p_maxLife = player.GetComponent<UnityChanControlScriptWithRgidBody>().maxLife;
            p_Power = player.GetComponent<UnityChanControlScriptWithRgidBody>()._SwordPower;
            p_magicPower = player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower;
            p_money = player.GetComponent<UnityChanControlScriptWithRgidBody>()._money;
            p_MaxFloor = enemyCount._MaxFloorLevel;

            PlayerPrefs.SetFloat("Exp", p_exp);
            PlayerPrefs.SetInt("Level", p_Level);
            PlayerPrefs.SetString("playername", player_name);
            PlayerPrefs.SetInt("RedCube", p_RedCube);
            PlayerPrefs.SetInt("BlueCube", p_BlueCube);
            PlayerPrefs.SetInt("GreenCube", p_GreenCube);
            PlayerPrefs.SetFloat("MaxLife",p_maxLife);
            PlayerPrefs.SetFloat("ProtectPlus", p_Protect);
            PlayerPrefs.SetFloat("Power", p_Power);

            PlayerPrefs.SetFloat("MagicPower", p_magicPower);
            PlayerPrefs.SetFloat("Money", p_money);
            PlayerPrefs.SetInt("FloorLevel", p_MaxFloor);

            PlayerPrefs.Save();
        }

        public void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject.tag == "Player"){
                collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().life = collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().maxLife;
                Save();
            }


        }
    }

}
