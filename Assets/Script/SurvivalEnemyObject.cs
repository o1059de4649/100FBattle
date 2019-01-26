using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class SurvivalEnemyObject : MonoBehaviour
    {
        public float _life;
        public float _maxLife;

        float _preLife;
        public int _monster_level;

        [SerializeField]
         GameObject player;

        Animator anim;
        Rigidbody rb;
        public GameObject lifeball;
        public GameObject boneball;
        bool _isDeath = false;
        public GameObject _spawnPosObj;

        public GameObject _damegeText;

        public float _randomPos, player_dist;

        [SerializeField]
        private float h;

        public float v;

        private Vector3 velocity;
        float _delay_attack;
        public BoxCollider boxCollider;

        public bool _isEnemy = true, _isSetUp = false;

     

        public float _runSpeed = 1, _animDelay = 1.0f, _enemyWeak = 1, _bloodEssence, _probability = 8;

        float _timeHitDamage;
        GameObject camera;

        public GameObject team;
        public float _AttackTime = 1.5f, preradius;
        string[] runAwayChara = { "WarriorMachine" };

        PhotonView photonView;

        public Slider slider;

        float random_move_time,random_move_waitTime = 3,random_realtime_rotate,lifeTime;

        DayControl dayControl;
        // Use this for initialization
        void Start()
        {
            if(PhotonNetwork.isMasterClient){
                dayControl = GameObject.Find("Sun").GetComponent<DayControl>();
                this.transform.localScale += new Vector3(dayControl._Day_date, dayControl._Day_date, dayControl._Day_date) * 0.1f;
            }



            this.gameObject.name = this.gameObject.name.Replace("(Clone)", "");
            photonView = gameObject.GetPhotonView();
        

           

            camera = GameObject.Find("MyPlayer").GetComponentInChildren<Camera>().transform.gameObject;

            rb = GetComponent<Rigidbody>();
            anim = GetComponent<Animator>();

            if(PhotonNetwork.isMasterClient){
               // _maxLife *= GameObject.Find("MyPlayer").GetComponent<DayControl>()._Day_date / 2 + 1; 
            }
           
            _life = _maxLife;


            /*
            //当たり判定不具合調整
            _spawnPosObj.AddComponent<SkeletonTrigger>();
            _spawnPosObj.GetComponent<SkeletonTrigger>().user_parent = this.gameObject;
            preradius = this.gameObject.GetComponent<SphereCollider>().radius;
            Destroy(this.gameObject.GetComponent<SphereCollider>());
            */
            _isSetUp = true;



        }

        // Update is called once per frame
        void Update()
        {
            slider.value = _life /_maxLife;

            if(!PhotonNetwork.isMasterClient){
                return;
            }

            lifeTime += Time.deltaTime;
            if (lifeTime >= 100 && PhotonNetwork.isMasterClient)
            {
                photonView.RPC("OnDestroy", PhotonTargets.AllBufferedViaServer);
               // Death();
            }

            if (_life <= 0)
            {
                v = 0;

                if (_isDeath == false)
                {
                    if (PhotonNetwork.isMasterClient)
                    {
                        Death();
                    }
                }
            }

            //RandomMove
            if(player == null){
                random_move_time += Time.deltaTime;

                if(random_move_time > random_move_waitTime){
                    v = 0;
                    random_move_time = 0;
                    random_move_waitTime = Random.Range(1.5f, 3);
                    this.gameObject.transform.Rotate(0, Random.Range(-180, 180), 0);
                    random_realtime_rotate = Random.Range(-2, 2);

                }


                this.gameObject.transform.eulerAngles += new Vector3(0, random_realtime_rotate, 0);

                velocity = new Vector3(h, 0, v * _runSpeed);
                velocity = transform.TransformDirection(velocity);
                transform.localPosition += velocity * Time.fixedDeltaTime;
                v += Time.deltaTime * 1;
                _timeHitDamage += Time.deltaTime;
                anim.SetFloat("speedh", v);
                return;
            }

            player_dist = Vector3.Distance(player.transform.position, transform.position);
            if (player.transform.position.y - 5.0f > this.transform.position.y)
            {
                Death();
            }


            if (_maxLife <= _life)
            {
                _life = _maxLife;
            }




            _delay_attack += Time.deltaTime;





            if (v >= 1)
            {
                v = 1;
            }


            if (_preLife != _life && _isDeath == false)
            {
                _randomPos = Random.Range(-2, 2);
                anim.SetTrigger("Hit1");

                if (_timeHitDamage >= 0.3f)
                {
                    GameObject damegeText = Instantiate(_damegeText, _spawnPosObj.transform.position, Quaternion.identity);
                    damegeText.GetComponentInChildren<Text>().text = ((Mathf.RoundToInt(_preLife) - Mathf.RoundToInt(_life)).ToString());
                    damegeText.transform.LookAt(camera.transform);
                    Destroy(damegeText, 3.0f);
                    _timeHitDamage = 0;

                    if (PhotonNetwork.isMasterClient)
                    {
                       // PhotonNetwork.Instantiate("MeatItem", _spawnPosObj.transform.position + new Vector3(0, 2, 0), Quaternion.identity, 0);
                    }
                }





            }
            _preLife = _life;

            PlayerChase();
           
                OnAttack();


      
            /*
            if (team)
            {
                TeamChase();
                OnAttack();
                return;
            }

            if (!team)
            {
                PlayerChase();
            }
*/

            /*for (int i = 0;runAwayChara.Length > i ;i++)
            {
                if (this.gameObject.name != runAwayChara[i])
                {
                    
                }
            }
*/
        }

        public void PlayerChase()
        {
            if (_isDeath == false)
            {
                transform.LookAt(player.transform);
            }
            velocity = new Vector3(h, 0, v * _runSpeed * 3);
            velocity = transform.TransformDirection(velocity);

            transform.localPosition += velocity * Time.fixedDeltaTime;


            v += Time.deltaTime * 3;
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

        public void OnAttack()
        {
            if (this.gameObject.tag == "Death")
            {
                return;
            }


            if (_delay_attack >= _AttackTime)
            {
                Debug.Log("Attack");
                v = 0;
                photonView.RPC("AttackColliderOn", PhotonTargets.All);
                //boxCollider.enabled = true;
                anim.SetTrigger("Attack1h1");
                _delay_attack = 0;
                Invoke("OffAttack", _animDelay);
            }

        }

        [PunRPC]
        public void AttackColliderOn(){
            boxCollider.enabled = true;
        }

        [PunRPC]
        public void AttackColliderOff()
        {
            boxCollider.enabled = false;
        }

        [PunRPC]
        public void EnemyDamage(float damage)
        {
            _life -= damage;
        }

        void Death()
        {
           
            _delay_attack = -100;
            anim.SetTrigger("Fall1");
            _isDeath = true;
            PhotonNetwork.Instantiate("MeatItem", _spawnPosObj.transform.position, Quaternion.identity,0);


            int count = Random.Range(1, 100);



            photonView.RPC("OnDestroy", PhotonTargets.AllBufferedViaServer);

        }

        void OffAttack()
        {
            photonView.RPC("AttackColliderOff", PhotonTargets.All);
            //boxCollider.enabled = false;
        }

        [PunRPC]
        public void OnDestroy()
        {
            Destroy(this.gameObject);
        }

        void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.isWriting)
            {
                stream.SendNext(v);
            }
            else
            {
                v = (float)stream.ReceiveNext();
            }

        }

        //索敵フラグ
        private void OnTriggerEnter(Collider collider)
        {
            
            if(collider.gameObject.tag == "Player" && PhotonNetwork.isMasterClient){
                player = collider.gameObject;
            }

            if (collider.gameObject.tag == "PlayerObject" && PhotonNetwork.isMasterClient)
            {
                player = collider.gameObject;
            }
        }
    }
}
