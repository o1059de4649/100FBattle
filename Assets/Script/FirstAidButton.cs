using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class FirstAidButton : MonoBehaviour,IPointerEnterHandler
    {
        public GameObject textbox;
      
        int have_Aid_some;
        Text aid_text;
        public UnityChanControlScriptWithRgidBody p_ucrb;
        // Use this for initialization
        void Start()
        {
            aid_text = textbox.GetComponent<Text>();
           
        }

        // Update is called once per frame
        void Update()
        {
            have_Aid_some = p_ucrb.have_aid;
            aid_text.text = (have_Aid_some.ToString());
           
        }


        public void OnPointerEnter(PointerEventData eventData){
            if(p_ucrb.have_aid > 0 && p_ucrb.life <= p_ucrb.maxLife && p_ucrb.wait_anim == false){
                p_ucrb.u_photonView.RPC("Aid", PhotonTargets.All);
            }
        }


    }
}
