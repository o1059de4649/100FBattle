using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class moveparent : MonoBehaviour
    {
        static public bool movedparent = false;
        // Use this for initialization
        void Start()
        {


        }

        // Update is called once per frame
        void Update()
        {
            if (!PhotonControll.player)
            {
                return;
            }
            else
            {
                transform.parent = PhotonControll.player.transform;
                movedparent = true;
            }
        }

        public void RemoveParent()
        {
            this.gameObject.transform.parent = null;
        }
    }
}