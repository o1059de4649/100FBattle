using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class MyRoomWallControl : MonoBehaviour
    {
        public GameObject forwardWall;
        public GameObject backWall;
        public GameObject rightWall;
        public GameObject leftWall;
        public GameObject upWall;

        public float _wallSpace;
        // Use this for initialization
        void Start()
        {

            _wallSpace = PlayerPrefs.GetFloat("WallSpace");

            forwardWall.transform.position += new Vector3(0, 0, -_wallSpace);
            backWall.transform.position += new Vector3(0, 0, _wallSpace);
            rightWall.transform.position += new Vector3(_wallSpace, 0, 0);
            leftWall.transform.position += new Vector3(-_wallSpace, 0, 0);
            upWall.transform.position += new Vector3(0, _wallSpace, 0);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}