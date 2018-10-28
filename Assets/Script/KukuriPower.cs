using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class KukuriPower : MonoBehaviour
    {
        BoxCollider boxCollider;
        public float _swordPower;
        float _waitTime;
        public GameObject _kukuri_effect;
       

        // Use this for initialization
        void Start()
        {
            boxCollider = GetComponent<BoxCollider>();
            _swordPower = 10;
        }

        // Update is called once per frame
        void Update()
        {
            _waitTime += Time.deltaTime;
        }

        public void OnTriggerEnter(Collider col)
        {
            _kukuri_effect.SetActive(true);
            Invoke("OffEffect", 2.0f);

            if (col.gameObject.tag == "Enemy")
            {
                if(_waitTime >= 0.5f){
                    col.gameObject.GetComponent<SkeletonStatus>().life -= _swordPower;
                    _waitTime = 0;
                }

            }
        }

        void OffEffect()
        {
            _kukuri_effect.SetActive(false);  
        }
    }
}