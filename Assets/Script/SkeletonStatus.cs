using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

        public GameObject _damegeText;

        float _randomPos;

        [SerializeField]
        private float h;

        public float v;

        [SerializeField]
        private float _itemDropForce;
        private float _itemDropForceRL;

        private Vector3 velocity;
        float _delay_attack;
        public BoxCollider boxCollider;

        public bool _isMagic = false;
        public EnemyCount enemyCount;

        public bool _isString = false;

        public GameObject _instatinateParticle;

        public float _runSpeed = 1;
        public float _animDelay = 1.0f;

        public float _enemyWeak = 1;

        public float _bloodEssence;
        float _timeHitDamage;
        GameObject camera;
        public GameObject teamNameSystem;
        // Use this for initialization
        void Start()
        {
            teamNameSystem = GameObject.Find("FloorControl").GetComponent<EnemyCount>().teamNameSysytem;
            _monster_level = GameObject.Find("FloorControl").GetComponent<EnemyCount>()._floorLevel + Random.Range(0,35);


            player = GameObject.Find("Player");
            camera = GameObject.Find("Player/CameraStork/MainCamera");
            rb = GetComponent<Rigidbody>();
            anim = GetComponent<Animator>();

            enemyCount = GameObject.Find("FloorControl").GetComponent<EnemyCount>();
            enemyCount._enemyCount++;

            GameObject obj = Instantiate(_instatinateParticle,this.transform.position, Quaternion.identity);
            Destroy(obj, 2.0f);
            _maxLife += _maxLife/100 * _monster_level * _enemyWeak;
            _life = _maxLife;

            _exp += _monster_level;
            _enemyMoney += _monster_level;
          
        }

        // Update is called once per frame
        void Update()
        {
            if(_maxLife <= _life){
                _life = _maxLife;
            }

            if (_life <= 0)
            {
                v = 0;

                if(_isDeath == false){
                    Death();
                }
            }

            if (_isString)
            {
                OnString();
                return;
            }

            _delay_attack += Time.deltaTime;

            if(_isDeath == false){
                transform.LookAt(player.transform);
            }
          
            velocity = new Vector3(h, 0, v * _runSpeed);
            velocity = transform.TransformDirection(velocity);

            transform.localPosition += velocity * Time.fixedDeltaTime;


            v += Time.deltaTime;
            _timeHitDamage += Time.deltaTime;
            anim.SetFloat("speedh", v);
            if (v >= 2)
            {
                v = 2;
            }


            if(_preLife != _life && _isDeath == false){
                _randomPos = Random.Range(-2,2);
                anim.SetTrigger("Hit1");

                if(_timeHitDamage >= 0.3f){
                    GameObject damegeText = Instantiate(_damegeText, _spawnPosObj.transform.position, Quaternion.identity);
                    damegeText.GetComponentInChildren<Text>().text = ((Mathf.RoundToInt(_preLife) - Mathf.RoundToInt(_life)).ToString());
                    damegeText.transform.LookAt(camera.transform);
                    Destroy(damegeText, 3.0f);
                    _timeHitDamage = 0;
                }
              

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
                v = 0;
                boxCollider.enabled = true;
                anim.SetTrigger("Attack1h1");
                _delay_attack = 0;
                Invoke("OffAttack", _animDelay);
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
            player.GetComponent<UnityChanControlScriptWithRgidBody>()._bloodEssence += _bloodEssence;

            int count = Random.Range(1, 100);
            if(count <= 2){
                GameObject teamNameCanvas = Instantiate(teamNameSystem,this.transform.position, Quaternion.identity);
                teamNameCanvas.transform.parent = this.transform;
                return;
            }

           
            Destroy(this.gameObject, 2.0f);

        }

        void OffAttack(){
            boxCollider.enabled = false;
        }

        void OnString(){
            v = 0;
            Invoke("OffString", 10.0f);
        }

        void OffString(){
            _isString = false;
        }


    }
}
