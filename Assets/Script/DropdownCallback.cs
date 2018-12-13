using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
namespace UnityStandardAssets.CrossPlatformInput
{

    public class DropdownCallback : MonoBehaviour
    {

        [SerializeField]
        public int contents;
        string[] prefab_name_before;
        string[] prefab_name_after;
      
        Dropdown dropdown;
        public Text label,status_text;
        public GameObject user;
        // Use this for initialization

        public List<string> prefab_list = new List<string>();

        public List<string> save_Code = new List<string>();
        public string[] splitCodes;
        public List<string> real_name = new List<string>();
        public List<string> monster_name = new List<string>();
        public List<int> _monster_Level = new List<int>();
        public List<float> _monster_Life = new List<float>();

        public bool isTeam = false;
        void Start()
        {
            

            dropdown = GetComponent<Dropdown>();
            /*
            DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/Resources/" + prefabDir);
            FileInfo[] info = dir.GetFiles();*/

            contents = PlayerPrefs.GetInt("SomeTeam", 0);//info.Length;
            Debug.Log(contents);
            // prefab_name_before = new string[contents];
            // prefab_name_after = new string[contents];
            SetUp();

        }

        public void SetUp(){
            for (int i = 0; contents > i; i++)
            {
                save_Code.Add("null");//要素追加
                monster_name.Add("null");
                real_name.Add("null");
                _monster_Level.Add(0);
                _monster_Life.Add(0);

                if (PlayerPrefs.HasKey("SaveCode" + i.ToString()) == true)
                {
                    Debug.Log(PlayerPrefs.GetString("SaveCode" + i.ToString(), "null"));
                    // prefab_name_before[i] = info[i].Name;
                    //prefab_name_after[i] = prefab_name_before[i].Replace(".prefab", "");

                  
                    save_Code[i] = PlayerPrefs.GetString("SaveCode" + i.ToString(), "null");


                    splitCodes = save_Code[i].Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries); ;
                    prefab_list.Add(splitCodes[1]);
                    // prefab_list.Add(prefab_name_after[i]);



                    monster_name[i] = splitCodes[0];
                    real_name[i] = splitCodes[1];
                    _monster_Level[i] = int.Parse(splitCodes[2]);
                    _monster_Life[i] = float.Parse(splitCodes[3]);
                }

            }

            dropdown.AddOptions(prefab_list);
            dropdown.value = 0;

        }

        // Update is called once per frame
        void Update()
        {
           
        }

        public void OnValueChanged(int result)
        {
            for (int i = 0; contents > i; i++)
            {
                if (label.text == real_name[i])
                {
                    status_text.text = ("種族:" + monster_name[i] 
                                        + "名前:" + real_name[i]
                                        + "レベル" + _monster_Level[i].ToString()
                                        + "体力" + _monster_Life[i].ToString() );
                }
            }
        }

        public void DetaReset(){
          // PlayerPrefs.DeleteAll();return;
            for (int i = 0; contents > i; i++)
            {

                if (label.text == real_name[i])
                {

                    GameObject prefab = (GameObject)Resources.Load("Prefab/" + monster_name[i]);
                    GameObject obj = Instantiate(prefab, user.transform.position, Quaternion.identity);
                    obj.name = real_name[i];

                    obj.GetComponent<SkeletonStatus>()._isEnemy = false;

                    obj.AddComponent<PlayerTeamAI>();
                    obj.GetComponent<PlayerTeamAI>()._maxLife = _monster_Life[i];
                    obj.GetComponent<PlayerTeamAI>()._monsterLevel = _monster_Level[i];
                    obj.GetComponent<PlayerTeamAI>().count = i;
                    obj.GetComponent<PlayerTeamAI>().isDeath = true;
                    dropdown.ClearOptions();

                    GameObject.Find("FloorControl").GetComponent<EnemyCount>()._enemyCount--;

                    prefab_list.Remove(real_name[i]);
                    dropdown.AddOptions(prefab_list);
                    dropdown.value = 0;


                    return;
                }

            }


        }

        public void InstantinateTeam()
        {
            

            for (int i = 0; contents > i; i++)
            {
                
                if (label.text == real_name[i])
                {
                   
                    GameObject prefab = (GameObject)Resources.Load("Prefab/" + monster_name[i]);
                    GameObject obj = Instantiate(prefab, user.transform.position, Quaternion.identity);
                    obj.name = real_name[i];

                    obj.GetComponent<SkeletonStatus>()._isEnemy = false;

                    obj.AddComponent<PlayerTeamAI>();
                    obj.GetComponent<PlayerTeamAI>()._maxLife = _monster_Life[i];
                    obj.GetComponent<PlayerTeamAI>()._monsterLevel = _monster_Level[i];
                    obj.GetComponent<PlayerTeamAI>().count = i;
                    dropdown.ClearOptions();

                    GameObject.Find("FloorControl").GetComponent<EnemyCount>()._enemyCount--;

                    prefab_list.Remove(real_name[i]);
                    dropdown.AddOptions(prefab_list);
                    dropdown.value = 0;
                    return;
                }

            }
            /*
            string prefab_name = label.text;
            GameObject prefab = (GameObject)Resources.Load("Prefab/" + label.text);
            GameObject obj = Instantiate(prefab, user.transform.position, Quaternion.identity);
            obj.name = prefab.name;
            dropdown.ClearOptions();

            prefab_list.Remove(prefab_name);
            dropdown.AddOptions(prefab_list);
            dropdown.value = 0;*/
        }

    }
}