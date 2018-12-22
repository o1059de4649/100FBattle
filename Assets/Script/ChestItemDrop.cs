using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class ChestItemDrop : MonoBehaviour
    {
        Animation animation;
        bool spawn = false;
        public GameObject[] spawnObj;
        public GameObject spawnPos;
        public GameObject[] particle;
        public GameObject[] eleven_sword;
        public GameObject[] eleven_sirld;
        [SerializeField]
        int probabilitiy,shirld_probability;
        // Use this for initialization
        void Start()
        {
            animation = GetComponent<Animation>();
            probabilitiy = Random.Range(0, 100);
            shirld_probability = Random.Range(0, 100);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.tag == "Player" && spawn == false){
                Invoke("SpawnItem", 3.0f);
                Invoke("ParticleOff", 3.0f);
                animation.Play();
                spawn = true;
            }
        }

        public void SpawnItem(){
            //エッセンスボール
            for (int i = 0; i < spawnObj.Length; i++)
            {
                int n = Random.Range(1, 3);
                for (int t = 0;t < n ;t++){
                    GameObject obj = Instantiate(spawnObj[i], spawnPos.transform.position, Quaternion.identity);
                    obj.GetComponent<Rigidbody>().AddForce(obj.transform.up * 100);
                }


            }

            //シールド
            if (0 <= probabilitiy && probabilitiy <= 30)
            {
                GameObject obj = Instantiate(eleven_sirld[0], spawnPos.transform.position, Quaternion.identity);
                obj.GetComponent<Rigidbody>().AddForce(obj.transform.up * 100);
            }

           //ソード
            if(50 <= probabilitiy && probabilitiy <= 100){
                GameObject obj = Instantiate(eleven_sword[0], spawnPos.transform.position, Quaternion.identity);
                obj.GetComponent<Rigidbody>().AddForce(obj.transform.up * 100);
            }

            if (21 <= probabilitiy && probabilitiy <= 49)
            {
                GameObject obj = Instantiate(eleven_sword[1], spawnPos.transform.position, Quaternion.identity);
                obj.GetComponent<Rigidbody>().AddForce(obj.transform.up * 100);
            }

            if (0 <= probabilitiy && probabilitiy <= 20)
            {
                GameObject obj = Instantiate(eleven_sword[2], spawnPos.transform.position, Quaternion.identity);
                obj.GetComponent<Rigidbody>().AddForce(obj.transform.up * 100);
            }

        }

        public void ParticleOff(){
            for (int i = 0; i < particle.Length;i++){
                particle[i].SetActive(false);
            }
        }
    }
}