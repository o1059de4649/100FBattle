using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    
public class LightSavePoint : MonoBehaviour {


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

        public void OnCollisionStay(Collision col)
        {
            if (col.gameObject.tag == "MyPlayer" && time > 1.0f)
            {
                time = 0;
                touch_count++;
               
                col.gameObject.GetPhotonView().RPC("LifeLightBall", PhotonTargets.All);
            }
        }
    }
}
