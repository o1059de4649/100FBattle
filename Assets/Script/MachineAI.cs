using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class MachineAI : MonoBehaviour
    {
        GameObject player, enemy;
        float _attackDelay;
        Ray ray;
        RaycastHit hit;
        float _power;
        public GameObject spawnerPos;
        Rigidbody user_rigidbody;
        // Use this for initialization
        void Start()
        {
            user_rigidbody = GetComponent<Rigidbody>();
            player = GameObject.Find("Player");
            _power = this.gameObject.GetComponent<SkeletonStatus>()._monster_level / 10;
        }

        // Update is called once per frame
        void Update()
        {
            _attackDelay += Time.deltaTime * Random.Range(1,2);

        }

        void GunShot(){
            ray = new Ray(spawnerPos.transform.position, spawnerPos.transform.forward);
            if(Physics.Raycast(ray, out hit)){

                if (hit.collider.tag == "Enemy" && this.gameObject.GetComponent<PlayerTeamAI>() != null)
                {
                    hit.collider.GetComponent<SkeletonStatus>()._life -= _power;
                    return;
                }

                if(hit.collider.tag == "Player" && this.gameObject.GetComponent<PlayerTeamAI>() == null){
                    hit.collider.GetComponent<UnityChanControlScriptWithRgidBody>().life -= _power;
                }

            }
        }

        public void OnTriggerStay(Collider col)
        {
            if(col.gameObject.tag == "Player" && _attackDelay > 1.0f){
                GunShot();
                _attackDelay = 0;

            }
        }

        public void Broken(){
            if(user_rigidbody.useGravity == false){
                user_rigidbody.useGravity = true;
                Invoke("DisBroken", 5.0f);
            }
        }

        void DisBroken(){
            user_rigidbody.useGravity = false;
        }
    }
}