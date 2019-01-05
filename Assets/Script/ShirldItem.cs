using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
public class ShirldItem : MonoBehaviour {

        public float _shirld_have_power;
        public int _rare;
        EnemyCount enemyCount;
        public GameObject particle;
        public int _type = 1;
        GameObject player;

        Rigidbody rb;
        // Use this for initialization
        void Start()
        {
            player = GameObject.Find("Player");
            enemyCount = GameObject.Find("FloorControl").GetComponent<EnemyCount>();
            _rare = Random.Range(1, 6);
            _shirld_have_power = Random.Range(1, 1 + enemyCount._floorLevel) * _type * _rare + 1;


            SetUpColor();

            GetComponentInChildren<ShirdCanvasRotate>().SetUp();
            rb = GetComponent<Rigidbody>();
            Destroy(this.gameObject, 30.0f);
        }

        // Update is called once per frame
        void Update()
        {
          //  this.transform.LookAt(player.transform);
           // rb.velocity += new Vector3(0, 0, -2);
        }

        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Player")
            {


                if (player.GetComponent<UnityChanControlScriptWithRgidBody>()._shirdPower < _shirld_have_power
                  //&& player.GetComponent<UnityChanControlScriptWithRgidBody>()._swordType <= _type 
                  )
                {
                    PlayerPrefs.SetInt("ShirldType", _type);
                    PlayerPrefs.SetInt("ShirldRare", _rare);
                    PlayerPrefs.SetFloat("Shirld", _shirld_have_power);
                    player.GetComponent<UnityChanControlScriptWithRgidBody>().GetEssence();//効果音再生
                    player.GetComponent<UnityChanControlScriptWithRgidBody>().Save();
                    player.GetComponent<UnityChanControlScriptWithRgidBody>().SetUp();
                    Destroy(this.gameObject);
                }


            }
        }

        public void SetUpColor()
        {
            if (_rare == 1)
            {
                particle.GetComponent<ParticleSystem>().startColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }

            if (_rare == 2)
            {
                particle.GetComponent<ParticleSystem>().startColor = new Color(0.0f, 0.0f, 1.0f, 1.0f);
            }

            if (_rare == 3)
            {
                particle.GetComponent<ParticleSystem>().startColor = new Color(0.0f, 1.0f, 0.0f, 1.0f);
            }

            if (_rare == 4)
            {
                particle.GetComponent<ParticleSystem>().startColor = new Color(1.0f, 1.0f, 0.0f, 1.0f);
            }

            if (_rare == 5)
            {
                particle.GetComponent<ParticleSystem>().startColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
            if (_rare == 6)
            {
                particle.GetComponent<ParticleSystem>().startColor = new Color(1.0f, 0.0f, 1.0f, 1.0f);
            }
        }
    }
}