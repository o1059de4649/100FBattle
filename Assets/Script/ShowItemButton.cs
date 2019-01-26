using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class ShowItemButton : MonoBehaviour
    {

        public GameObject[] buttons;
        public PhotonView photonView;
        public UnityChanControlScriptWithRgidBody unityChanControlScriptWithRgid;
        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {


            if (photonView.isMine)
            {

                if(unityChanControlScriptWithRgid.nutsItem > 0){
                    buttons[0].SetActive(true);
                }else{
                    buttons[0].SetActive(false);
                }

                if (unityChanControlScriptWithRgid.meat_baked_item > 0)
                {
                    buttons[1].SetActive(true);
                }
                else
                {
                    buttons[1].SetActive(false);
                }

                if (unityChanControlScriptWithRgid.water_bottleItem > 0)
                {
                    buttons[2].SetActive(true);
                }
                else
                {
                    buttons[2].SetActive(false);
                }

                if (unityChanControlScriptWithRgid.nuts_bottleItem > 0)
                {
                    buttons[3].SetActive(true);
                }
                else
                {
                    buttons[3].SetActive(false);
                }

            }

        }
    }
}