using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class SkeletonStatus : MonoBehaviour
    {
        public float _life;
        public float _maxLife;
        public float _exp;
        public float _enemyMoney;
        float _preLife;
        public int _monster_level;
        GameObject player;
        Animator anim;
        Rigidbody rb;
        public GameObject lifeball;
        public GameObject boneball;
        bool _isDeath = false;
        public GameObject _spawnPosObj;
        float _randomPos;

        [SerializeField]
        private float h;
        [SerializeField]
        private float v;

        [SerializeField]
        private float _itemDropForce;
        private float _itemDropForceRL;

        private Vector3 velocity;
        float _delay_attack;
        public BoxCollider boxCollider;

        public bool _isMagic = false;
        EnemyCount enemyCount;
        // Use this for initialization
        void Start()
        {
            player = GameObject.Find("Player");
            rb = GetComponent<Rigidbody>();
            anim = GetComponent<Animator>();

            enemyCount = GameObject.Find("FloorControl").GetComponent<EnemyCount>();
            enemyCount._enemyCount++;

            _maxLife += Random.Range(100.0f,120.0f);
            _maxLife += _monster_level;
            _life = _maxLife;
          
        }

        // Update is called once per frame
        void Update()
        {
            if (_life <= 0)
            {
                v = 0;

                if(_isDeath == false){
                    Death();
                }
            }

            _delay_attack += Time.deltaTime;

            if(_isDeath == false){
                transform.LookAt(player.transform);
            }
          
            velocity = new Vector3(h, 0, v);
            velocity = transform.TransformDirection(velocity);

            transform.localPosition += velocity * Time.fixedDeltaTime;


            v += Time.deltaTime;
            anim.SetFloat("speedh", v);
            if (v >= 2)
            {
                v = 2;
            }



            if(_preLife != _life && _isDeath == false){
                _randomPos = Random.Range(-2,2);
                anim.SetTrigger("Hit1");

                if(_isMagic == false){
                    GameObject _boneball = Instantiate(boneball, _spawnPosObj.transform.position + new Vector3(_randomPos, _randomPos, _randomPos), Quaternion.identity);
                }
               
               
            }
            _preLife = _life;

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
            enemyCount._enemyCount--;
            _delay_attack = -100;
            anim.SetTrigger("Fall1");
            _isDeath = true;
            GameObject _lifeball = Instantiate(lifeball, _spawnPosObj.transform.position, Quaternion.identity);
            player.GetComponent<UnityChanControlScriptWithRgidBody>().exp_point += _exp;
            player.GetComponent<UnityChanControlScriptWithRgidBody>()._money += _enemyMoney;
            Destroy(this.gameObject, 2.0f);

        }

        void OffAttack(){
            boxCollider.enabled = false;
        }

       
    }
}
