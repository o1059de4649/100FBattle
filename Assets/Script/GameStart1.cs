using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class GameStart1 : MonoBehaviour
    {
        public GameObject floor;
        public GameObject floorPos;
        // Use this for initialization
        void Start()
        {
            Instantiate(floor, floorPos.transform.position, Quaternion.identity);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}