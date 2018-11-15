using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class FloorSpawn : MonoBehaviour
    {
        public int[] _howFloor;
        public GameObject[] floor;
        public GameObject _wall;

        public GameObject _floorSpawnPos;

        public EnemyCount enemyCount;
        // Use this for initialization
        void Start()
        {
            enemyCount = GameObject.Find("FloorControl").GetComponent<EnemyCount>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerStay(Collider col)
        {
            if (col.gameObject.tag == "Player")
            {
                
              
                if (_howFloor[0] >= 1)
                {
                    floor[0] = (GameObject)Resources.Load("Floor");
                    Instantiate(floor[0], _floorSpawnPos.transform.position, Quaternion.identity);
                    _howFloor[0]--;

                    enemyCount._floorLevel++;
                   
                }



            }
        }
    }
}
