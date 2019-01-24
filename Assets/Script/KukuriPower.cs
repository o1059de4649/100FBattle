using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class KukuriPower : Photon.MonoBehaviour
    {
        BoxCollider boxCollider;
        public float _swordPower;
        float _waitTime;
        public GameObject _kukuri_effect,particle;
        public UnityChanControlScriptWithRgidBody _uniyuchanControl;
        GameObject player;
        string ghost = "Ghost";

        int _rare;

        GameObject myPlayer_battleMode;
        // Use this for initialization
        void Start()
        {
            
            boxCollider = GetComponent<BoxCollider>();
            _rare = PlayerPrefs.GetInt("SwordRare", 0);
            player = GameObject.Find("Player");
            myPlayer_battleMode = this.transform.gameObject.GetComponentInParent<UnityChanControlScriptWithRgidBody>().transform.gameObject;
            if(this.gameObject.name != "left_kukuri"){
                SetUpColor();
            }
           
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
                if(col.gameObject.name == "Ghost"){
                    return;
                }

                if(_waitTime >= 0.5f){
                    col.gameObject.GetComponent<SkeletonStatus>()._life -= _swordPower;
                    col.gameObject.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._SwordPower;
                    col.gameObject.GetComponent<SkeletonStatus>()._isMagic = false;
                    _waitTime = 0;
                }

            }

            if(col.gameObject.tag == "Tree" && myPlayer_battleMode.name == "MyPlayer"){
                col.gameObject.GetComponent<PhotonView>().RPC("Damage",PhotonTargets.All);
               
            }

            if (col.gameObject.tag == "BattleModeEnemy" && myPlayer_battleMode.name == "MyPlayer")
            {
                float damages = myPlayer_battleMode.GetComponent<UnityChanControlScriptWithRgidBody>()._SwordPower + _swordPower;
                col.gameObject.GetComponent<PhotonView>().RPC("EnemyDamage", PhotonTargets.All,damages);

            }
        }

        void OffEffect()
        {
            _kukuri_effect.SetActive(false);  
        }

        public void SetUpColor(){
            _rare = PlayerPrefs.GetInt("SwordRare", 0);
            if (_rare == 1)
            {
                _kukuri_effect.GetComponent<ParticleSystem>().startColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                particle.GetComponent<ParticleSystem>().startColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }

            if (_rare == 2)
            {
                _kukuri_effect.GetComponent<ParticleSystem>().startColor =new Color(0.0f, 0.0f, 1.0f, 1.0f);
                particle.GetComponent<ParticleSystem>().startColor = new Color(0.0f, 0.0f, 1.0f, 1.0f);
            }

            if (_rare == 3)
            {
                _kukuri_effect.GetComponent<ParticleSystem>().startColor = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                particle.GetComponent<ParticleSystem>().startColor = new Color(0.0f, 1.0f, 0.0f, 1.0f);


            }

            if (_rare == 4)
            {
                _kukuri_effect.GetComponent<ParticleSystem>().startColor = new Color(1.0f, 1.0f, 0.0f, 1.0f);
                particle.GetComponent<ParticleSystem>().startColor = new Color(1.0f, 1.0f, 0.0f, 1.0f);
            }

            if (_rare == 5)
            {
                _kukuri_effect.GetComponent<ParticleSystem>().startColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                particle.GetComponent<ParticleSystem>().startColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
            if (_rare == 6)
            {
                _kukuri_effect.GetComponent<ParticleSystem>().startColor = new Color(1.0f, 0.0f, 1.0f, 1.0f);
                particle.GetComponent<ParticleSystem>().startColor = new Color(1.0f, 0.0f, 1.0f, 1.0f);
            } 
        }

        void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {

            if (stream.isWriting)
            {
                stream.SendNext(_rare);
            }
            else
            {
                _rare = (int)stream.ReceiveNext();
            }
        }
    }
}