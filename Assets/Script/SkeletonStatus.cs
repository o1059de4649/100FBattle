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

        public float _randomPos,player_dist;

        [SerializeField]
        private float h;

        public float v;

        [SerializeField]
        private float _itemDropForce;
        private float _itemDropForceRL;

        private Vector3 velocity;
        float _delay_attack;
        public BoxCollider boxCollider;

        public bool _isMagic = false,_isString = false,_isEnemy = true,_isSetUp = false;
        public EnemyCount enemyCount;
        public GameObject _instatinateParticle;

        public float _runSpeed = 1,_animDelay = 1.0f,_enemyWeak = 1,_bloodEssence,_probability = 8;
       
        float _timeHitDamage;
        GameObject camera;
        public GameObject teamNameSystem;
        public GameObject team;
        public float _AttackTime = 1.5f,preradius;
        string[] runAwayChara = { "WarriorMachine" };


        // Use this for initialization
        void Start()
        {

            this.gameObject.name = this.gameObject.name.Replace("(Clone)","");
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

          //当たり判定不具合調整
            _spawnPosObj.AddComponent<SkeletonTrigger>();
            _spawnPosObj.GetComponent<SkeletonTrigger>().user_parent = this.gameObject;
            preradius = this.gameObject.GetComponent<SphereCollider>().radius;
            Destroy(this.gameObject.GetComponent<SphereCollider>());
            _isSetUp = true;

        }

        // Update is called once per frame
        void Update()
        {
            if (_isEnemy && _isSetUp == false)
            {
                
            }

            player_dist = Vector3.Distance(player.transform.position, transform.position);
            if(player.transform.position.y - 5.0f > this.transform.position.y){
                this.transform.position =  new Vector3(this.transform.position.x,player.transform.position.y + 3 ,this.transform.position.z);
            }


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

                    if (_isMagic == false)
                    {
                        GameObject _boneball = Instantiate(boneball, _spawnPosObj.transform.position + new Vector3(_randomPos, _randomPos, _randomPos), Quaternion.identity);
                        Destroy(_boneball, 8.0f);
                    }
                }
              

               
               
               
            }
            _preLife = _life;

            if(this.gameObject.GetComponent<MachineAI>() != null && player_dist > 10){
                Invoke("RunAway", 1.0f); 
                return;
            }

            if(team){
                TeamChase();
                OnAttack();
                return;
            }

            if(!team){
                PlayerChase();
            }

            /*for (int i = 0;runAwayChara.Length > i ;i++)
            {
                if (this.gameObject.name != runAwayChara[i])
                {
                    
                }
            }
*/
        }

        public void PlayerChase(){
            if (_isDeath == false)
            {
                transform.LookAt(player.transform);
            }
            velocity = new Vector3(h, 0, v * _runSpeed);
            velocity = transform.TransformDirection(velocity);

            transform.localPosition += velocity * Time.fixedDeltaTime;


            v += Time.deltaTime;
            _timeHitDamage += Time.deltaTime;
            anim.SetFloat("speedh", v);
        }

        public void TeamChase()
        {
            if (_isDeath == false)
            {
                transform.LookAt(team.transform);
            }
            velocity = new Vector3(h, 0, v * _runSpeed);
            velocity = transform.TransformDirection(velocity);

            transform.localPosition += velocity * Time.fixedDeltaTime;


            v += Time.deltaTime;
            _timeHitDamage += Time.deltaTime;
            anim.SetFloat("speedh", v);
        }

        public void RunAway()
        {
            velocity = new Vector3(h, 0, -v * _runSpeed);
            velocity = transform.TransformDirection(velocity);

            transform.localPosition += velocity * Time.fixedDeltaTime;


            v += Time.deltaTime;
            _timeHitDamage += Time.deltaTime;
            anim.SetFloat("speedh", v);
        }
        /*
        public void OnTriggerStay(Collider col)
        {
            if(col.gameObject.tag == "Player"){
                OnAttack();
                return;
            }

            if(col.gameObject.tag == "Team" && player_dist > 15){
                
                if(team == null){
                    team = GameObject.FindWithTag("Team");
                }

                this.gameObject.transform.LookAt(team.transform);
                OnAttack();
                return;
            }
        }*/

        public void OnAttack(){
            if(this.gameObject.tag == "Death"){
                return;
            }


            if(_delay_attack >= _AttackTime){
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
            if(count <= _probability){
                GameObject teamNameCanvas = Instantiate(teamNameSystem,this.transform.position, Quaternion.identity);
                teamNameCanvas.transform.parent = this.transform;
                this.gameObject.tag = "Death";
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
