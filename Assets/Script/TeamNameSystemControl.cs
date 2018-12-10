using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class TeamNameSystemControl : MonoBehaviour
    {
        InputField inputField;
        SkeletonStatus skeletonStatus;
        public string save_Code;
        public int some_team = 0;
        // Use this for initialization
        void Start()
        {
            inputField = GetComponentInChildren<InputField>();
        }

        // Update is called once per frame
        void Update()
        {
            if(this.gameObject.transform.parent.GetComponent<PlayerTeamAI>() != null){
                Destroy(this.gameObject);
            }
        }

        public void NameDeside(){
            if(inputField.text == null){
                return;
            }

            some_team = PlayerPrefs.GetInt("SomeTeam",0);
           

            skeletonStatus = this.transform.parent.GetComponent<SkeletonStatus>();

            save_Code = (this.gameObject.transform.parent.name + "/" + inputField.text + "/" + skeletonStatus._monster_level.ToString() + "/" + skeletonStatus._maxLife.ToString());
            PlayerPrefs.SetString("SaveCode" + some_team.ToString(), save_Code);
            Debug.Log("SaveCode" + some_team.ToString());


            this.gameObject.transform.parent.name = inputField.text;
            this.gameObject.transform.parent.gameObject.AddComponent<PlayerTeamAI>();
            this.gameObject.transform.parent.gameObject.GetComponent<PlayerTeamAI>().count = some_team;
            this.gameObject.transform.parent.gameObject.GetComponent<PlayerTeamAI>()._monsterLevel = skeletonStatus._monster_level;
            this.gameObject.transform.parent.gameObject.GetComponent<PlayerTeamAI>()._maxLife = skeletonStatus._maxLife;
            this.transform.GetComponentInChildren<Canvas>().enabled = false;
           
            some_team++;
            PlayerPrefs.SetInt("SomeTeam", some_team);



            Destroy(skeletonStatus);
           

           // Destroy(this.transform.parent.gameObject);
            Destroy(this.gameObject);
        }

        public void DestroyParent(){
            Destroy(this.transform.parent.gameObject);
        }

        public void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject.tag == "Player"){
                this.transform.GetComponentInChildren<Canvas>().enabled = true;
            }
        }

        public void OnTriggerExit(Collider collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                this.transform.GetComponentInChildren<Canvas>().enabled = false;
            }
        }
    }
}