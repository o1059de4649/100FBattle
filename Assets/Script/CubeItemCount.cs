using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class CubeItemCount : MonoBehaviour
    {
        bool get = false;
        PhotonView photonView;
        // Use this for initialization
        void Start()
        {
            photonView = GetComponent<PhotonView>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnCollisionEnter(Collision collision)
        {
           
            if (collision.gameObject.tag == "MyPlayer" && this.gameObject.name == "SnowCube(Clone)")
            {
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().blue_Cube++;
                get = true;
                photonView.RPC("OnDestroyer", PhotonTargets.All);
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("Cube_Get", PhotonTargets.All);
            }

            if (collision.gameObject.tag == "MyPlayer" && this.gameObject.name == "LightCubeBlue(Clone)")
            {
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().blue_Cube++;
                get = true;
                photonView.RPC("OnDestroyer", PhotonTargets.All);
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("Cube_Get", PhotonTargets.All);
            }

            if (collision.gameObject.tag == "MyPlayer" && this.gameObject.name == "SnowCubeBench(Clone)")
            {
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().green_Cube++;
                get = true;
                photonView.RPC("OnDestroyer", PhotonTargets.All);
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("Cube_Get", PhotonTargets.All);
            }

            if (collision.gameObject.tag == "MyPlayer" && this.gameObject.name == "LightCubeGreen(Clone)")
            {
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().green_Cube++;
                get = true;
                photonView.RPC("OnDestroyer", PhotonTargets.All);
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("Cube_Get", PhotonTargets.All);
            }

            if (collision.gameObject.tag == "MyPlayer" && this.gameObject.name == "SnowCubeRed(Clone)")
            {
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().red_Cube++;
                get = true;
                photonView.RPC("OnDestroyer", PhotonTargets.All);
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("Cube_Get", PhotonTargets.All);
            }

            if (collision.gameObject.tag == "MyPlayer" && this.gameObject.name == "LightCubeRed(Clone)")
            {
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().red_Cube++;
                get = true;
                photonView.RPC("OnDestroyer", PhotonTargets.All);
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("Cube_Get", PhotonTargets.All);
            }

            if (collision.gameObject.tag == "MyPlayer" && this.gameObject.name == "CityLightCube(Clone)")
            {
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().red_Cube++;
                get = true;
                photonView.RPC("OnDestroyer", PhotonTargets.All);
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("Cube_Get", PhotonTargets.All);

            }


           
           

               
            }
           

        [PunRPC]

        public void OnDestroyer()
        {
            Destroy(this.gameObject);
        }





    }
}
