using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class FloorClearFrag : MonoBehaviour
    {
        public bool _isClear = false;
        public EnemyCount enemyCount;
        // Use this for initialization
        void Start()
        {
            enemyCount = GameObject.Find("FloorControl").GetComponent<EnemyCount>();
        }

        // Update is called once per frame
        void Update()
        {
            
            if(enemyCount._enemyCount >= 1){
                _isClear = false;
            }

            if(enemyCount._enemyCount == 0){
                _isClear = true;
            }
        }

       

      
    }
}