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

        EnemyCount enemyCount;
        // Use this for initialization
        void Start()
        {
            enemyCount = GameObject.Find("FloorControl").GetComponent<EnemyCount>();
            _howEnemyCount[0] = _howEnemy[0];
            _howEnemyCount[1] = _howEnemy[1];
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

                if (_howEnemyCount[1] >= 1 && enemyCount._FloorLevel >= 5)
                {
                    Instantiate(monster[1], transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
                    _howEnemyCount[1]--;

                    _preStopWall.SetActive(true);

                }


             

            }

           
        }
    }
}
