using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class ShowFloorText : MonoBehaviour
    {
        public EnemyCount enemyCount;
        public Text _FloorText;
        // Use this for initialization
        void Start()
        {
            enemyCount = GameObject.Find("FloorControl").GetComponent<EnemyCount>();
        }

        // Update is called once per frame
        void Update()
        {
            _FloorText.text = (enemyCount._FloorLevel.ToString() + "F" + "/" + enemyCount._MaxFloorLevel.ToString() + "F");
        }


    }
}