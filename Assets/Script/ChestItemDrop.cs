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
        // Use this for initialization
        void Start()
        {
            animation = GetComponent<Animation>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.tag == "Player" && spawn == false){
                Invoke("SpawnItem", 3.0f);
                animation.Play();
                spawn = true;
            }
        }

        public void SpawnItem(){
            
            for (int i = 0; i < spawnObj.Length; i++)
            {
                int n = Random.Range(0, 3);
                for (int t = 0;t < n ;t++){
                    GameObject obj = Instantiate(spawnObj[i], spawnPos.transform.position, Quaternion.identity);
                    obj.GetComponent<Rigidbody>().AddForce(obj.transform.up * 100);
                }


            }



        }
    }
}