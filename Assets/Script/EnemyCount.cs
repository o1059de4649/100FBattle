using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class EnemyCount : MonoBehaviour
    {
        public int _enemyCount = 0;
        public int _floorLevel = 0;
        public int _MaxFloorLevel = 0;
        public int _teamCount = 0;

        public GameObject teamNameSysytem;
        // Use this for initialization
        void Start()
        {
            _MaxFloorLevel = PlayerPrefs.GetInt("FloorLevel", 0);
        }

        // Update is called once per frame
        void Update()
        {
           /* if(_enemyCount < 0){
                _enemyCount = 0;
            }
*/
            if (_teamCount < 0)
            {
                _teamCount= 0;
            }

            if(_MaxFloorLevel <= _floorLevel){
                _MaxFloorLevel = _floorLevel;  
            }
        }
    }
}