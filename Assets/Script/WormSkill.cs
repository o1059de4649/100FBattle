using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class WormSkill : MonoBehaviour
    {
        public GameObject _parrticle;
        GameObject enemy;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(enemy == null){
                _parrticle.SetActive(false);
            }
        }

        private void OnTriggerStay(Collider col)
        {

            if (this.gameObject.GetComponentInParent<PlayerTeamAI>() != null)//仲間の時
            {
              
                if (col.gameObject.tag == "Death")
                {
                    _parrticle.SetActive(false);
                    return;
                }

                if (col.gameObject.tag == "Enemy")
                {
                    enemy = GameObject.FindWithTag("Enemy");
                    _parrticle.SetActive(true);
                }
               
            }


            if(col.gameObject.tag == "Player"){
                if (this.gameObject.GetComponentInParent<PlayerTeamAI>() != null)//仲間の時
                {
                    return;
                }
                _parrticle.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider col)
        {
            if (this.gameObject.GetComponentInParent<PlayerTeamAI>() != null)//仲間の時
            {
                if (col.gameObject.tag == "Enemy")
                {
                    enemy = GameObject.FindWithTag("Enemy");
                    _parrticle.SetActive(false);
                }
            }

            if (col.gameObject.tag == "Player")
            {
             
                _parrticle.SetActive(false);
            }

           
        }
    }
}