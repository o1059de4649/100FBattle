using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
public class ShirdCanvasRotate : MonoBehaviour {

        GameObject camera;
        public ShirldItem shirldItem;
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

        public void SetUp()
        {
            this.transform.gameObject.GetComponent<Text>().text = ("防御力" + shirldItem._shirld_have_power.ToString());
        }
    }
}