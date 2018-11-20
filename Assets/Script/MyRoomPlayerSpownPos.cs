using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class MyRoomPlayerSpownPos : MonoBehaviour
    {
        RaycastHit hit;
        Ray ray;
        public GameObject mainCamera;
        public GameObject spawnerPos;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            ray = new Ray(mainCamera.transform.position, transform.forward);
            if(Physics.Raycast(ray,out hit)){
                spawnerPos.transform.position = hit.point;
            }
        }
    }
}