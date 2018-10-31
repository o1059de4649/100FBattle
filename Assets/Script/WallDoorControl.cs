using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class WallDoorControl : MonoBehaviour
    {
        Animator anim;
        public bool _isfloorClear;
        public FloorClearFrag floorClearFrag;
        // Use this for initialization
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            _isfloorClear = floorClearFrag._isClear;

            if(_isfloorClear){
                anim.SetBool("Open",true);
            }else{
                anim.SetBool("Open", false);
            }
        }


       
    }
}