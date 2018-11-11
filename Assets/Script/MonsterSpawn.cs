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
        public float _spawnerRange = 15;
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
            _howEnemyCount[6] = _howEnemy[6];
            _howEnemyCount[7] = _howEnemy[7];
            _howEnemyCount[8] = _howEnemy[8];
            _howEnemyCount[9] = _howEnemy[9];
            _howEnemyCount[10] = _howEnemy[10];
            _howEnemyCount[11] = _howEnemy[11];
            _howEnemyCount[12] = _howEnemy[12];
            _howEnemyCount[13] = _howEnemy[13];
            _howEnemyCount[14] = _howEnemy[14];
            _howEnemyCount[15] = _howEnemy[15];
            _howEnemyCount[16] = _howEnemy[16];
            _howEnemyCount[17] = _howEnemy[17];
            _howEnemyCount[18] = _howEnemy[18];
            _howEnemyCount[19] = _howEnemy[19];
            _howEnemyCount[20] = _howEnemy[20];

        }

        // Update is called once per frame
        void Update()
        {
           
        }

        private void OnTriggerStay(Collider col)
        {
            if(col.gameObject.tag == "Player"){
                //SkeletonWeak1
                if (_howEnemyCount[0] >= 1 && 5 > enemyCount._FloorLevel)
                {
                    Instantiate(monster[0], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[0]--;

                    _preStopWall.SetActive(true);
                   
                }

                //SkeletonWeak2
                if (_howEnemyCount[1] >= 1 && 8 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 3)
                {
                    Instantiate(monster[1], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[1]--;

                    _preStopWall.SetActive(true);

                }

                //imomusi
                if (_howEnemyCount[2] >= 1 && 15 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 6)
                {
                    Instantiate(monster[2], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[2]--;

                    _preStopWall.SetActive(true);

                }

                //Skeleton
                if (_howEnemyCount[3] >= 1 && 15 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 10)
                {
                    Instantiate(monster[3], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[3]--;

                    _preStopWall.SetActive(true);

                }

                //SkeletonMedium1
                if (_howEnemyCount[4] >= 1 && 17 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 12)
                {
                    Instantiate(monster[4], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[4]--;

                    _preStopWall.SetActive(true);

                }

                //SkeletonMedium2
                if (_howEnemyCount[5] >= 1 && 19 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 14)
                {
                    Instantiate(monster[5], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[5]--;

                    _preStopWall.SetActive(true);

                }

                //demon
                if (_howEnemyCount[6] >= 1 && 23 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 17)
                {
                    Instantiate(monster[6], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[6]--;

                    _preStopWall.SetActive(true);

                }

                //gorem
                if (_howEnemyCount[7] >= 1 && 30 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 20)
                {
                    Instantiate(monster[7], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[7]--;

                    _preStopWall.SetActive(true);

                }

                //SkeletonStong
                if (_howEnemyCount[8] >= 1 && enemyCount._FloorLevel == 10)
                {
                    Instantiate(monster[8], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[8]--;

                    _preStopWall.SetActive(true);

                }

               
                //imomusi2
                if (_howEnemyCount[9] >= 1 && 30 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 24)
                {
                    Instantiate(monster[9], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[9]--;

                    _preStopWall.SetActive(true);

                }

                //imomusiBoss
                if (_howEnemyCount[10] >= 1 && enemyCount._FloorLevel == 20)
                {
                    Instantiate(monster[10], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[10]--;

                    _preStopWall.SetActive(true);

                }

                //demonboss
                if (_howEnemyCount[11] >= 1 && enemyCount._FloorLevel == 30)
                {
                    Instantiate(monster[11], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[11]--;

                    _preStopWall.SetActive(true);

                }

                //icedemon
                if (_howEnemyCount[13] >= 1 && 35 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 30)
                {
                    Instantiate(monster[13], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[13]--;

                    _preStopWall.SetActive(true);

                }

                //SkeletonDarkKnight
                if (_howEnemyCount[12] >= 1 && 35 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 30)
                {
                    Instantiate(monster[12], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[12]--;

                    _preStopWall.SetActive(true);

                }

                //imomusiDark
                if (_howEnemyCount[14] >= 1 && 38 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 33)
                {
                    Instantiate(monster[14], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[14]--;

                    _preStopWall.SetActive(true);

                }

                //Shell_Crab
                if (_howEnemyCount[15] >= 1 && 40 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 36)
                {
                    Instantiate(monster[15], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[15]--;

                    _preStopWall.SetActive(true);

                }

                //SkeletonWizard
                if (_howEnemyCount[16] >= 1 && 33 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 27)
                {
                    Instantiate(monster[16], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[16]--;

                    _preStopWall.SetActive(true);

                }

                //wizard
                if (_howEnemyCount[17] >= 1 && 44 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 38)
                {
                    Instantiate(monster[17], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[17]--;

                    _preStopWall.SetActive(true);

                }

                //goblin
                if (_howEnemyCount[18] >= 1 && 47 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 41)
                {
                    Instantiate(monster[18], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[18]--;

                    _preStopWall.SetActive(true);

                }

                //Hobgoblin
                if (_howEnemyCount[19] >= 1 && 49 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 45)
                {
                    Instantiate(monster[19], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[19]--;

                    _preStopWall.SetActive(true);

                }

                //Troll
                if (_howEnemyCount[20] >= 1 && 49 > enemyCount._FloorLevel && enemyCount._FloorLevel >= 46)
                {
                    Instantiate(monster[20], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[20]--;

                    _preStopWall.SetActive(true);

                }



            }

           
        }
    }
}
