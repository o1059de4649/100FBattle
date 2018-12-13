using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class PlayerTeamAI : MonoBehaviour
    {
        public GameObject player;
        public GameObject enemy;
        private Vector3 velocity;

        [SerializeField]
        float _runSpeed = 2;

        float v;
        float h;
        Animator anim;

        public float _life = 1,_preLife = 0,_maxLife = 1,_delay_attack,_animDelay,_hitDelay,_chaseRange = 7.0f,_lifeDelay,_attackPlus;
        public string team_name;
        public bool isTeam = true,isEnemy = false,isDeath = false;
        BoxCollider boxCollider;
        EnemyCount enemyCount;


        public string[] saveCodes;

        public int count;
        public int _monsterLevel;

        float _enemyLife;

        public float _exp;
        bool isSet = false;
        // Use this for initialization
        private void Awake()
        {
            
        }

        void Start()
        {
           

            this.gameObject.GetComponent<Rigidbody>().mass = 0.01f;

            _animDelay = this.gameObject.GetComponent<SkeletonStatus>()._animDelay;
            boxCollider = this.gameObject.GetComponent<SkeletonStatus>().boxCollider;
            anim = GetComponent<Animator>();
            anim.SetTrigger("Hit1");
            anim.SetTrigger("Attack1h1");
            enemyCount = GameObject.Find("FloorControl").GetComponent<EnemyCount>();
            enemyCount._teamCount++;

            _maxLife = this.gameObject.GetComponent<SkeletonStatus>()._maxLife + _monsterLevel;
            _life = _maxLife;


            this.gameObject.tag = "Team";

           

            player = GameObject.Find("Player");
            this.transform.localScale += new Vector3(_monsterLevel * 0.0025f, _monsterLevel * 0.0025f, _monsterLevel * 0.0025f);


        }

        // Update is called once per frame
        void Update()
        {
            if(!isSet){
                this.gameObject.GetComponent<SkeletonStatus>()._spawnPosObj.GetComponent<SphereCollider>().radius += 25;
                Destroy(this.gameObject.GetComponent<SkeletonStatus>());
                isSet = true;
            }

            if(_exp >= _monsterLevel*25){
                _exp = 0;
                _monsterLevel++;
            }


            _delay_attack += Time.deltaTime;
            _hitDelay += Time.deltaTime;
            _lifeDelay += Time.deltaTime;
            if(_lifeDelay >= 3.0f){
                _life++;
                _lifeDelay = 0;
            }

            if(_preLife > _life && _hitDelay >= 4.0f){
                anim.SetTrigger("Hit1");
                _hitDelay = 0;
            }

            if(_maxLife < _life){
                _life = _maxLife;
            }

            if(_life <= 0||isDeath){
                Death();
                enemyCount._teamCount--;
                Destroy(this.gameObject);
            }

            _preLife = _life;

            if(isEnemy){
                if(enemy == null){
                    isEnemy = false;
                }
                return;
            }

            MoveToPlayer();
        }

        public void Death(){
            /*
            int _someTeam = PlayerPrefs.GetInt("SomeTeam", 0);
            _someTeam--;
            PlayerPrefs.SetInt("SomeTeam", _someTeam);
*/
            PlayerPrefs.DeleteKey("SaveCode" + count.ToString());

          
        }

        public void MoveToPlayer()
        {
            

            this.transform.LookAt(player.transform);

            Vector3 playerPos = player.transform.position;
            Vector3 thisPos = this.transform.position;
            float _distancce = Vector3.Distance(playerPos, thisPos);
           

            if (_distancce >= 40)
            {
                this.transform.position = player.transform.position + new Vector3(0,2,0);
                return;
            }

            if(_distancce <= 4){
                v = 0;
                anim.SetFloat("speedh", v);
                return;
            }

           
            velocity = new Vector3(h, 0, v * _runSpeed * 3);
            velocity = transform.TransformDirection(velocity);
            transform.localPosition += velocity * Time.fixedDeltaTime;
            v += Time.deltaTime;
            anim.SetFloat("speedh", v);
            if (v >= 3)
            {
                v = 3;
            }
        }

        public void MoveToEnemy()
        {
            if (enemy != null)
            {
                
                this.transform.LookAt(enemy.transform);
                velocity = new Vector3(h, 0, v * _runSpeed /2);
                velocity = transform.TransformDirection(velocity);
                transform.localPosition += velocity * Time.fixedDeltaTime;
                v += Time.deltaTime;
                anim.SetFloat("speedh", v);
                if (v >= 1)
                {
                    v = 1;
                }

                if(enemy.tag == "Death"){
                    enemy = null;
                    MoveToPlayer();
                    return;
                }


            }else{
                MoveToPlayer();
                return;
            }
        }

        public void SetName(){
            
            GetComponentInChildren<ShowLevelAuto>().name = team_name;
        }

        public void OnAttack()
        {


            if (_delay_attack >= 1.5f)
            {
                v = 0;
                boxCollider.enabled = true;
                anim.SetTrigger("Attack1h1");
                _delay_attack = 0;
                Invoke("OffAttack", _animDelay);
            }

        }

        void OffAttack()
        {
            boxCollider.enabled = false;
        }

        public void OnTriggerStay(Collider col)
        {
            if (col.gameObject.tag == "Enemy")
            {
                if(enemy == null){
                    GameObject.FindWithTag("Enemy");

                }
                MoveToEnemy();
                OnAttack();
                isEnemy = true;
                return;
            }

            /*
            if (col.gameObject.tag == "Player")
            {

                MoveToPlayer();
            }*/
        }

        public void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.tag == "Enemy"){
                enemy = col.gameObject;
            }
        }


        public void SaveObject(){
            string saveCode = PlayerPrefs.GetString("SaveCode" + count.ToString(), "null");
            saveCodes = saveCode.Split(new[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);
            saveCode = (saveCodes[0] + "/" + saveCodes[1] + "/" + _monsterLevel.ToString() +"/"+ saveCodes[3]);
            PlayerPrefs.SetString("SaveCode" + count.ToString(), saveCode);
         

           // NKPrefabMan prefabMan = this.gameObject.AddComponent<NKPrefabMan>();

          //  GameObject saveObj = this.gameObject;
           // prefabMan.savePrefab(saveObj, saveObj.name);
        }

        private void OnApplicationPause(bool pauseStatus)
        {

            //一時停止
            if (pauseStatus)
            {
                SaveObject();
            }
            //再開時
            else
            {
                SaveObject();
            }

        }

    }
}