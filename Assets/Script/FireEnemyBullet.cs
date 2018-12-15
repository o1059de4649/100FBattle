using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class FireEnemyBullet : MonoBehaviour
    {
        Rigidbody rb;
        public float _speed;
        public float _magicPower;
        public bool _isTeam = false;
        float _attackDelay;
        // Use this for initialization
        void Start()
        {
           


            if(_isTeam){
                GameObject enemy = GameObject.FindWithTag("Enemy");
                transform.LookAt(enemy.transform);
            }else{
                GameObject player = GameObject.Find("Player");
                transform.LookAt(player.transform);
            }

            rb = GetComponent<Rigidbody>();
            rb.AddForce(this.gameObject.transform.forward * _speed);
            Destroy(this.gameObject,1.5f);
        }

        // Update is called once per frame
        void Update()
        {
            _attackDelay += Time.deltaTime;
        }

        public void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Enemy" && _isTeam == true && _attackDelay > 0.1f)
            {
                col.GetComponent<SkeletonStatus>()._life -= _magicPower;
                _attackDelay = 0;
            }



                if (col.gameObject.tag == "Player" && _isTeam == false && _attackDelay > 0.1f)
                {
                    col.GetComponent<UnityChanControlScriptWithRgidBody>().life -= _magicPower;
                    _attackDelay = 0;
                }

            if (col.gameObject.tag == "Team" && _isTeam == false && _attackDelay > 0.1f)
            {
                col.GetComponent<PlayerTeamAI>()._life -= _magicPower;
                _attackDelay = 0;
            }


           
        }
    }
}