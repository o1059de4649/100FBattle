using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class MonsterSpawn : MonoBehaviour
    {
        public GameObject[] monster;
        public int[] _howEnemy;
       
        public FloorClearFrag floorClearFrag;
        public GameObject _preStopWall;
        public int[] _howEnemyCount;
        // Use this for initialization
        void Start()
        {
            _howEnemyCount[0] = _howEnemy[0];

        }

        // Update is called once per frame
        void Update()
        {
           
        }

        private void OnTriggerStay(Collider col)
        {
            if(col.gameObject.tag == "Player"){
                if (_howEnemyCount[0] >= 1)
                {
                    Instantiate(monster[0], transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
                    _howEnemyCount[0]--;

                    _preStopWall.SetActive(true);
                   
                }


             

            }

           
        }
    }
}
