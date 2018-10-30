using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class MonsterSpawn : MonoBehaviour
    {
        public GameObject[] monster;
        public float[] _howEnemy;
        // Use this for initialization
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            if(_howEnemy[0] >= 1){
                Instantiate(monster[0],transform.position + new Vector3(Random.Range(-10,10),0,Random.Range(-10,10)),Quaternion.identity);
                _howEnemy[0]--;
            }
        }
    }
}
