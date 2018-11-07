using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class IceBallSpawner : MonoBehaviour
    {
        public GameObject _iceballet;
        public float speed;
        float _attackTime;
        public bool _shot = false;
        // Use this for initialization
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            _attackTime += Time.deltaTime;

            if( 1.0f <= _attackTime && _shot == true){
                GameObject _iceballets = Instantiate(_iceballet) as GameObject;
                Vector3 force = this.gameObject.transform.forward * speed;
                _iceballets.GetComponent<Rigidbody>().AddForce(force);
                _iceballets.transform.position = this.transform.position;
                _attackTime = 0;
                _shot = false;
            }
        }
    }
}