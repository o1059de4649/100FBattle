﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{

    public class SaveData : MonoBehaviour
    {
        public int p_Level;
        public float p_exp;
        public float p_lifePlus;
        public float p_Protect;
        public float p_Power;

        public float p_magicPower;
        public float p_money;

        public int p_MaxFloor;
        public string player_name;
        public GameObject player;
        public EnemyCount enemyCount;

        public float p_boneEssence;
        public float p_stringEssence;
        public float p_fireEssence;
        public float p_iceEddence;
        public float p_crystalEssence;

        public float p_EssencePlus;

        public int p_floorLevel;

        public float p_blood;

        public float p_wallSpace;
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
            Debug.Log("SaveOn");
            p_exp = player.GetComponent<UnityChanControlScriptWithRgidBody>().exp_point;

            p_Level = player.GetComponent<UnityChanControlScriptWithRgidBody>().player_Level;

            p_Protect = player.GetComponent<UnityChanControlScriptWithRgidBody>().protectPlus;


            p_lifePlus = player.GetComponent<UnityChanControlScriptWithRgidBody>().lifePlus;
            p_Power = player.GetComponent<UnityChanControlScriptWithRgidBody>()._attackPower;
            p_magicPower = player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPowerPlus;
            p_money = player.GetComponent<UnityChanControlScriptWithRgidBody>()._money;
            p_MaxFloor = enemyCount._MaxFloorLevel;

            p_boneEssence = player.GetComponent<UnityChanControlScriptWithRgidBody>()._boneEssence;
            p_stringEssence = player.GetComponent<UnityChanControlScriptWithRgidBody>()._stringEssence;
            p_fireEssence = player.GetComponent<UnityChanControlScriptWithRgidBody>()._fireEssence;
            p_iceEddence = player.GetComponent<UnityChanControlScriptWithRgidBody>()._iceEssence;
            p_crystalEssence = player.GetComponent<UnityChanControlScriptWithRgidBody>()._CrystalEssence;

            p_EssencePlus = player.GetComponent<UnityChanControlScriptWithRgidBody>()._maxEssencePlus;

            p_blood = player.GetComponent<UnityChanControlScriptWithRgidBody>()._bloodEssence;

            p_wallSpace = player.GetComponent<UnityChanControlScriptWithRgidBody>()._wallSpace;



            PlayerPrefs.SetFloat("Exp", p_exp);
            PlayerPrefs.SetInt("Level", p_Level);
            PlayerPrefs.SetString("playername", player_name);

            PlayerPrefs.SetFloat("LifePlus",p_lifePlus);
            PlayerPrefs.SetFloat("ProtectPlus", p_Protect);
            PlayerPrefs.SetFloat("PowerPlus", p_Power);

            PlayerPrefs.SetFloat("MagicPowerPlus", p_magicPower);
            PlayerPrefs.SetFloat("Money", p_money);
            PlayerPrefs.SetInt("FloorLevel", p_MaxFloor);

            PlayerPrefs.SetFloat("BoneEssence", p_boneEssence);
            PlayerPrefs.SetFloat("StringEssence", p_stringEssence);
            PlayerPrefs.SetFloat("FireEssence", p_fireEssence);
            PlayerPrefs.SetFloat("IceEssence", p_iceEddence);
            PlayerPrefs.SetFloat("CrystalEssence", p_crystalEssence);

            PlayerPrefs.SetFloat("EssencePlus", p_EssencePlus);
            PlayerPrefs.SetFloat("Blood", p_blood);

            PlayerPrefs.SetFloat("WallSpace",p_wallSpace);




            PlayerPrefs.Save();
        }

        public void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject.tag == "Player"){
                

                collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().life = collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().maxLife;
                collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().Save();

                player.GetComponent<UnityChanControlScriptWithRgidBody>().SetUp();

                GameObject[] team = new GameObject[3];
                 team = GameObject.FindGameObjectsWithTag("Team");

                for (int i = 0;  team.Length > i;i++){
                    team[i].GetComponent<PlayerTeamAI>()._life += 99999;
                }
            }


        }
    }

}
