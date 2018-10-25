using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class WeaponOff : MonoBehaviour
    {
        [SerializeField]
        public GameObject handgun;
        public GameObject uzi;
        public GameObject shotGun;
        public GameObject fire_handgun;
        public GameObject fire_uzi;
        public GameObject fire_shotGun;
        public PhotonView photonView;
        // Use this for initialization
        void Start()
        {
            photonView = GetComponent<PhotonView>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        [PunRPC]
        void WeaPonOffSet(){

            handgun.SetActive(false);
            uzi.SetActive(false);
            shotGun.SetActive(false);

            fire_handgun.SetActive(false);
            fire_uzi.SetActive(false);
            fire_shotGun.SetActive(false);

        }
    }
}
