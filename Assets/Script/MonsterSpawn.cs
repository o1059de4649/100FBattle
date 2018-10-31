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
            _howEnemyCount[2] = _howEnemy[2];
            _howEnemyCount[3] = _howEnemy[3];
            _howEnemyCount[4] = _howEnemy[4];
            _howEnemyCount[5] = _howEnemy[5];
        }

        // Update is called once per frame
        void Update()
        {
           
        }

        private void OnTriggerStay(Collider col)
        {
            if(col.gameObject.tag == "Player"){
                if (_howEnemyCount[0] >= 1 && 5 > enemyCount._FloorLevel)
                {
                    Instantiate(monster[0], transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
                    _howEnemyCount[0]--;

                    _preStopWall.SetActive(true);
                   
                }

                if (_howEnemyCount[1] >= 1 && 8 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 3)
                {
                    Instantiate(monster[1], transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
                    _howEnemyCount[1]--;

                    _preStopWall.SetActive(true);

                }

                if (_howEnemyCount[2] >= 1 && 12 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 6)
                {
                    Instantiate(monster[2], transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
                    _howEnemyCount[2]--;

                    _preStopWall.SetActive(true);

                }

                if (_howEnemyCount[3] >= 1 && 15 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 10)
                {
                    Instantiate(monster[3], transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
                    _howEnemyCount[3]--;

                    _preStopWall.SetActive(true);

                }

                if (_howEnemyCount[4] >= 1 && 17 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 12)
                {
                    Instantiate(monster[4], transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
                    _howEnemyCount[4]--;

                    _preStopWall.SetActive(true);

                }

                if (_howEnemyCount[5] >= 1 && 19 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 14)
                {
                    Instantiate(monster[5], transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
                    _howEnemyCount[5]--;

                    _preStopWall.SetActive(true);

                }


            }

           
        }
    }
}
