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
        // Use this for initialization
        void Start()
        {
            GameObject player = GameObject.Find("Player");
            transform.LookAt(player.transform);
            rb = GetComponent<Rigidbody>();
            rb.AddForce(this.gameObject.transform.forward * _speed);
            Destroy(this.gameObject,3.0f);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.tag == "Player"){
                col.GetComponent<UnityChanControlScriptWithRgidBody>().life -= _magicPower;
               
            }
        }
    }
}