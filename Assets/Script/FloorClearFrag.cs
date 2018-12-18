using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class FloorClearFrag : MonoBehaviour
    {
        public bool _isClear = false;
        public EnemyCount enemyCount;
        public GameObject chest;
        int t;
        // Use this for initialization
        void Start()
        {
            enemyCount = GameObject.Find("FloorControl").GetComponent<EnemyCount>();
            t = Random.Range(0, 100);
        }

        // Update is called once per frame
        void Update()
        {
            
            if(enemyCount._enemyCount >= 1){
                _isClear = false;
                ChestSpawnOff();
            }

            if(enemyCount._enemyCount == 0){
                _isClear = true;
                ChestSpawnOn();
            }
        }

        void ChestSpawnOn(){
            
            if(t < 50){
                chest.SetActive(true);
            }
        }

        void ChestSpawnOff(){
            chest.SetActive(false);
        }

       

      
    }
}