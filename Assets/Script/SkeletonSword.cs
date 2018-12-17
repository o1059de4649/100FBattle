using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class SkeletonSword : MonoBehaviour
    {
        BoxCollider boxCollider;
        public float _swordPower;
        float _attackDelay;
        bool isSetUp;
        // Use this for initialization
        void Start()
        {
            boxCollider = GetComponent<BoxCollider>();
            boxCollider.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            _attackDelay += Time.deltaTime;

            if(!isSetUp && this.gameObject.GetComponentInParent<PlayerTeamAI>() != null){
                _swordPower += this.gameObject.GetComponentInParent<PlayerTeamAI>()._monsterLevel / 4;
                isSetUp = true;
            }
        }

        public void OnTriggerEnter(Collider col)
        {
            
            if (col.gameObject.tag == "Enemy" && this.gameObject.GetComponentInParent<PlayerTeamAI>() != null)
            {
                col.gameObject.GetComponent<SkeletonStatus>()._life -= _swordPower + this.gameObject.GetComponentInParent<PlayerTeamAI>()._attackPlus;
                this.gameObject.GetComponentInParent<PlayerTeamAI>()._exp += col.gameObject.GetComponent<SkeletonStatus>()._monster_level;
            }

            if (_attackDelay > 0.5f)
            {



                if (col.gameObject.tag == "Player" && this.gameObject.GetComponentInParent<PlayerTeamAI>() == null)
                {
                    if (col.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>()._isCrystal == true)
                    {
                        col.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().life -= _swordPower / 3;
                        _attackDelay = 0;
                        return;
                    }
                    col.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().life -= _swordPower;
                }



                if (col.gameObject.tag == "Team" && this.gameObject.GetComponentInParent<PlayerTeamAI>() == null)
                {
                    col.gameObject.GetComponent<PlayerTeamAI>()._life -= _swordPower;
                    _attackDelay = 0;
                }
            }
        }
    }
}
