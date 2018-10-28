using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class SkeletonStatus : MonoBehaviour
    {
        public float life;
        public float _maxLife;
        float _preLife;
        public int monster_level;
        GameObject player;
        Animator anim;
        Rigidbody rb;

        [SerializeField]
        private float h;
        [SerializeField]
        private float v;

        private Vector3 velocity;
        float _delay_attack;
        public BoxCollider boxCollider;
        // Use this for initialization
        void Start()
        {
            player = GameObject.Find("Player");
            rb = GetComponent<Rigidbody>();
            anim = GetComponent<Animator>();
            life += Random.Range(100.0f, 120.0f);
            life += monster_level;
            _maxLife = life;
        }

        // Update is called once per frame
        void Update()
        {
            if (life <= 0)
            {
                v = 0;
                Death();

            }

            _delay_attack += Time.deltaTime;

            transform.LookAt(player.transform);
            velocity = new Vector3(h, 0, v);
            velocity = transform.TransformDirection(velocity);

            transform.localPosition += velocity * Time.fixedDeltaTime;


            v += Time.deltaTime;
            anim.SetFloat("speedh", v);
            if (v >= 2)
            {
                v = 2;
            }



            if(_preLife != life){
                anim.SetTrigger("Hit1");
            }
            _preLife = life;

        }

        public void OnTriggerStay(Collider col)
        {
            if(col.gameObject.tag == "Player"){
                OnAttack();
            }
        }

        void OnAttack(){
          

            if(_delay_attack >= 1.5f){
                boxCollider.enabled = true;
                anim.SetTrigger("Attack1h1");
                _delay_attack = 0;
                Invoke("OffAttack", 1.0f);
            }

        }

        void Death(){
            anim.SetTrigger("Fall1");
            Destroy(this.gameObject, 2.0f);
        }

        void OffAttack(){
            boxCollider.enabled = false;
        }


    }
}
