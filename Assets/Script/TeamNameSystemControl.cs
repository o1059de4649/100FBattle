using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class TeamNameSystemControl : MonoBehaviour
    {
        InputField inputField;

        // Use this for initialization
        void Start()
        {
            inputField = GetComponentInChildren<InputField>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void NameDeside(){
            this.gameObject.transform.parent.name = inputField.text;
            this.gameObject.transform.parent.gameObject.AddComponent<PlayerTeamAI>();
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