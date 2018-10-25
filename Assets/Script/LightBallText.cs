using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{

    public class LightBallText : MonoBehaviour
    {
        public TextMesh textMesh;
        int touch_count;
        float time;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            time += Time.deltaTime;
        }

        public void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "MyPlayer" && time > 1.0f) {
                time = 0;
                touch_count++;
                textMesh.text = (touch_count.ToString());
                col.gameObject.GetPhotonView().RPC("LifeLightBall",PhotonTargets.All);
            }
        }
    }
}
