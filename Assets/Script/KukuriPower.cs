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
        public UnityChanControlScriptWithRgidBody _uniyuchanControl;
        GameObject player;
        // Use this for initialization
        void Start()
        {
            boxCollider = GetComponent<BoxCollider>();

            player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
           
            _waitTime += Time.deltaTime;
        }

        public void OnTriggerEnter(Collider col)
        {
            _kukuri_effect.SetActive(true);
            Invoke("OffEffect", 0.7f);

            if (col.gameObject.tag == "Enemy")
            {
                if(_waitTime >= 0.5f){
                    col.gameObject.GetComponent<SkeletonStatus>()._life -= _swordPower;
                    col.gameObject.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._SwordPower;
                    col.gameObject.GetComponent<SkeletonStatus>()._isMagic = false;
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