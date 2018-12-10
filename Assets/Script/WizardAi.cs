using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class WizardAi : MonoBehaviour
    {
        public GameObject _fireBallet;
        public GameObject _bulletSpawner;
        public float speed;
        float _attackDelay;
        public float _magicDeelay;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            _attackDelay += Time.deltaTime;
        }

        public void OnTriggerStay(Collider col)
        {
            if(this.gameObject.tag == "Death"){
                return;
            }

            if(col.gameObject.tag == "Enemy" && _attackDelay >= 3.0f && this.transform.gameObject.GetComponent<PlayerTeamAI>() != null){
                Invoke("WizardMagicTeam", _magicDeelay);
                return;
            }

            if(col.gameObject.tag == "Player" && _attackDelay >= 3.0f && this.transform.gameObject.GetComponent<PlayerTeamAI>() == null){
               
                Invoke("WizardMagic",_magicDeelay);
            }


        }

        public void WizardMagic(){
            Instantiate(_fireBallet,_bulletSpawner.transform.position, Quaternion.identity);
           
            _attackDelay = 0;

        }

        public void WizardMagicTeam(){
            GameObject obj = Instantiate(_fireBallet, _bulletSpawner.transform.position, Quaternion.identity);
            obj.GetComponent<FireEnemyBullet>()._isTeam = true;
            _attackDelay = 0;
        }


    }
}