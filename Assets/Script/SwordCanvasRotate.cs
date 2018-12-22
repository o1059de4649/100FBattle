using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class SwordCanvasRotate : MonoBehaviour
    {
        GameObject camera;
        public SwordItem swordItem;
        // Use this for initialization
        void Start()
        {
            camera = GameObject.Find("Player/CameraStork/MainCamera");
            SetUp();
        }

        // Update is called once per frame
        void Update()
        {
            this.transform.parent.gameObject.transform.LookAt(camera.transform);
        }

        public void SetUp(){
            this.transform.gameObject.GetComponent<Text>().text = ("攻撃力"+ swordItem._sword_have_power.ToString());
                     }
    }
}