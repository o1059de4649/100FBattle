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
        public float _spawnerRange = 15,_probablity;
        EnemyCount enemyCount;
        // Use this for initialization
        void Start()
        {
            _probablity = Random.Range(0, 100);
            enemyCount = GameObject.Find("FloorControl").GetComponent<EnemyCount>();

            for (int i = 0;_howEnemyCount.Length > i;i++){
                _howEnemyCount[i] = _howEnemy[i];
            }

           
        }

        // Update is called once per frame
        void Update()
        {
           
        }

        private void OnTriggerStay(Collider col)
        {
            if(col.gameObject.tag == "Player"){
                if(_howEnemyCount[23] >= 1 && 100 > enemyCount._floorLevel &&_probablity < 5){
                    Instantiate(monster[23], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[23]--;
                    _probablity = Random.Range(0, 100);

                }

                if (_howEnemyCount[24] >= 1 && 100 > enemyCount._floorLevel && _probablity < 10 && 5 < _probablity)
                {
                    Instantiate(monster[24], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[24]--;
                    _probablity = Random.Range(0, 100);

                }

                //SkeletonWeak1
                if (_howEnemyCount[0] >= 1 && 5 > enemyCount._floorLevel)
                {
                    Instantiate(monster[0], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[0]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);
                   
                }

                //SkeletonWeak2
                if (_howEnemyCount[1] >= 1 && 8 > enemyCount._floorLevel && enemyCount._floorLevel >= 3)
                {
                    Instantiate(monster[1], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[1]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //imomusi
                if (_howEnemyCount[2] >= 1 && 15 > enemyCount._floorLevel && enemyCount._floorLevel >= 6)
                {
                    Instantiate(monster[2], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[2]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //Skeleton
                if (_howEnemyCount[3] >= 1 && 15 > enemyCount._floorLevel && enemyCount._floorLevel>= 10)
                {
                    Instantiate(monster[3], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[3]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //SkeletonMedium1
                if (_howEnemyCount[4] >= 1 && 17 > enemyCount._floorLevel && enemyCount._floorLevel >= 12)
                {
                    Instantiate(monster[4], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[4]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //SkeletonMedium2
                if (_howEnemyCount[5] >= 1 && 19 > enemyCount._floorLevel && enemyCount._floorLevel >= 14)
                {
                    Instantiate(monster[5], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[5]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //demon
                if (_howEnemyCount[6] >= 1 && 23 > enemyCount._floorLevel && enemyCount._floorLevel >= 17)
                {
                    Instantiate(monster[6], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[6]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //gorem
                if (_howEnemyCount[7] >= 1 && 30 > enemyCount._floorLevel && enemyCount._floorLevel >= 20)
                {
                    Instantiate(monster[7], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[7]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //SkeletonStong
                if (_howEnemyCount[8] >= 1 && enemyCount._floorLevel == 10)
                {
                    Instantiate(monster[8], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[8]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

               
                //imomusi2
                if (_howEnemyCount[9] >= 1 && 30 > enemyCount._floorLevel && enemyCount._floorLevel >= 24)
                {
                    Instantiate(monster[9], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[9]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //imomusiBoss
                if (_howEnemyCount[10] >= 1 && enemyCount._floorLevel == 20)
                {
                    Instantiate(monster[10], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[10]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //demonboss
                if (_howEnemyCount[11] >= 1 && enemyCount._floorLevel == 30)
                {
                    Instantiate(monster[11], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[11]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //icedemon
                if (_howEnemyCount[13] >= 1 && 35 > enemyCount._floorLevel && enemyCount._floorLevel >= 30)
                {
                    Instantiate(monster[13], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[13]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //SkeletonDarkKnight
                if (_howEnemyCount[12] >= 1 && 35 > enemyCount._floorLevel && enemyCount._floorLevel >= 30)
                {
                    Instantiate(monster[12], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[12]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //imomusiDark
                if (_howEnemyCount[14] >= 1 && 38 > enemyCount._floorLevel && enemyCount._floorLevel >= 33)
                {
                    Instantiate(monster[14], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[14]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //Shell_Crab
                if (_howEnemyCount[15] >= 1 && 40 > enemyCount._floorLevel && enemyCount._floorLevel >= 36)
                {
                    Instantiate(monster[15], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[15]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //SkeletonWizard
                if (_howEnemyCount[16] >= 1 && 33 > enemyCount._floorLevel && enemyCount._floorLevel >= 27)
                {
                    Instantiate(monster[16], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[16]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //wizard
                if (_howEnemyCount[17] >= 1 && 45 > enemyCount._floorLevel && enemyCount._floorLevel >= 38)
                {
                    Instantiate(monster[17], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[17]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //goblin
                if (_howEnemyCount[18] >= 1 && 47 > enemyCount._floorLevel && enemyCount._floorLevel >= 41)
                {
                    Instantiate(monster[18], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[18]--;

                    _preStopWall.SetActive(true);

                }

                //Hobgoblin
                if (_howEnemyCount[19] >= 1 && 49 > enemyCount._floorLevel && enemyCount._floorLevel >= 45)
                {
                    Instantiate(monster[19], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[19]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //Troll
                if (_howEnemyCount[20] >= 1 && 50 > enemyCount._floorLevel && enemyCount._floorLevel >= 46 )
                {
                    Instantiate(monster[20], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[20]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //Trollboss
                if (_howEnemyCount[20] >= 1 && enemyCount._floorLevel == 40)
                {
                    Instantiate(monster[20], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[20]--;

                    _preStopWall.SetActive(true);

                }

                //GolemBoss
                if (_howEnemyCount[21] >= 1 && enemyCount._floorLevel == 50)
                {
                    Instantiate(monster[21], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[21]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //imomusiBoss
                if (_howEnemyCount[10] >= 1 && 60 > enemyCount._floorLevel && enemyCount._floorLevel >= 55)
                {
                    Instantiate(monster[10], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[10]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //demonboss
                if (_howEnemyCount[11] >= 0 && 55 > enemyCount._floorLevel && enemyCount._floorLevel >= 51)
                {
                    Instantiate(monster[11], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[11]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //Troll
                if (_howEnemyCount[20] >= 1 && 60 > enemyCount._floorLevel && enemyCount._floorLevel >= 51)
                {
                    Instantiate(monster[20], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[20]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //DarkAngel
                if (_howEnemyCount[22] >= 1 && 80 > enemyCount._floorLevel && enemyCount._floorLevel >= 71)
                {
                    Instantiate(monster[22], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[22]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //Spider
                if (_howEnemyCount[25] >= 1 && 55 > enemyCount._floorLevel && enemyCount._floorLevel >= 51)
                {
                    Instantiate(monster[25], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[25]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //StringSpider
                if (_howEnemyCount[29] >= 1 && 60 > enemyCount._floorLevel && enemyCount._floorLevel >= 55)
                {
                    Instantiate(monster[29], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[29]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //SpiderBoss
                if (_howEnemyCount[26] >= 1 && enemyCount._floorLevel == 60)
                {
                    Instantiate(monster[26], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[26]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //WarriorMachine
                if (_howEnemyCount[27] >= 1 && 70 > enemyCount._floorLevel && enemyCount._floorLevel >= 61)
                {
                    Instantiate(monster[27], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[27]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //FlyMachine
                if (_howEnemyCount[28] >= 1 && 70 > enemyCount._floorLevel && enemyCount._floorLevel >= 61)
                {
                    Instantiate(monster[28], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[28]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }

                //Ghost
                if (_howEnemyCount[30] >= 1 && 80 > enemyCount._floorLevel && enemyCount._floorLevel >= 73)
                {
                    Instantiate(monster[30], transform.position + new Vector3(Random.Range(-_spawnerRange, _spawnerRange), 0, Random.Range(-_spawnerRange, _spawnerRange)), Quaternion.identity);
                    _howEnemyCount[30]--;
                    _probablity = Random.Range(0, 100);
                    _preStopWall.SetActive(true);

                }


            }

           
        }
    }
}
