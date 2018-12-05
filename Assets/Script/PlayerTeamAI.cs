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
        public bool isTeam = true,isEnemy = false;
        BoxCollider boxCollider;
        EnemyCount enemyCount;
        // Use this for initialization
        void Start()
        {
            
            this.gameObject.GetComponent<Rigidbody>().mass = 0.01f;
            this.gameObject.GetComponent<SphereCollider>().radius += 25;
            _animDelay = this.gameObject.GetComponent<SkeletonStatus>()._animDelay;
            boxCollider = this.gameObject.GetComponent<SkeletonStatus>().boxCollider;
            anim = GetComponent<Animator>();
            anim.SetTrigger("Hit1");
            enemyCount = GameObject.Find("FloorControl").GetComponent<EnemyCount>();

            enemyCount._teamCount++;

            _maxLife = this.gameObject.GetComponent<SkeletonStatus>()._maxLife + this.gameObject.GetComponent<SkeletonStatus>()._monster_level * 2;
            _life = _maxLife;

            Destroy(this.gameObject.GetComponent<SkeletonStatus>());
            this.gameObject.tag = "Team";

            NKPrefabMan prefabMan = this.gameObject.AddComponent<NKPrefabMan>();

            GameObject saveObj = this.gameObject;
            prefabMan.savePrefab(saveObj, saveObj.name);

            player = GameObject.Find("Player");



        }

        // Update is called once per frame
        void Update()
        {

            _delay_attack += Time.deltaTime;
            _hitDelay += Time.deltaTime;
            _lifeDelay += Time.deltaTime;
            if(_lifeDelay >= 3.0f){
                _life++;
                _lifeDelay = 0;
            }

            if(_preLife < _life && _hitDelay >= 4.0f){
                anim.SetTrigger("Hit1");
                _hitDelay = 0;
            }

            if(_maxLife < _life){
                _life = _maxLife;
            }

            if(_life <= 0){
                Death(this.gameObject.name);
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

        public void Death(string name){
            string prefabDirPath = Application.dataPath + "/Resources/" + "Prefab/";
            name = this.gameObject.name;
            string prefabPath = prefabDirPath + name + ".prefab";
            File.Delete(prefabPath);
           
        }

        public void MoveToPlayer()
        {
            this.transform.LookAt(player.transform);

            Vector3 playerPos = player.transform.position;
            Vector3 thisPos = this.transform.position;
            float _distancce = Vector3.Distance(playerPos, thisPos);
           
            if(_distancce <= 4){
                v = 0;
                anim.SetFloat("speedh", v);
                return;
            }

           
            velocity = new Vector3(h, 0, v * _runSpeed * 1.5f);
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

            this.transform.LookAt(enemy.transform);
            velocity = new Vector3(h, 0, v * _runSpeed);
            velocity = transform.TransformDirection(velocity);
            transform.localPosition += velocity * Time.fixedDeltaTime;
            v += Time.deltaTime;
            anim.SetFloat("speedh", v);
            if (v >= 1)
            {
                v = 1;
            }
        }

        public void SetName(){
            
            GetComponentInChildren<ShowLevelAuto>().name = team_name;
        }

        void OnAttack()
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




    }
}