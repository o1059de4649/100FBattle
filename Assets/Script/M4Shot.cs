using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class M4Shot : Photon.MonoBehaviour
    {
        public RaycastHit hit;
        public RaycastHit target_hit;

        GameObject maincamera;
        GameObject gun_player;
        Camera cam;

        Ray target_ray;
        Vector3 t_direction;
        public GameObject targetObj;

        Ray ray;
        public AudioClip m4fireAudio;
        AudioSource audioSource;
        PhotonView p_photonview;
        PhotonView u_photonview;
        GameObject m4;
        public GameObject kill_text;
        Text killText;
        int distance = 550;
        public PhotonControll photonControll;
        public GameObject shotPoint;
        // Use this for initialization
        void Start()
        {
            photonControll = GameObject.Find("PhotonController").GetComponent<PhotonControll>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {



            if (cam == null)
            {
                gun_player = PhotonControll.player;
                maincamera = gun_player.transform.Find("CameraStork/MainCamera").gameObject;

                killText = kill_text.GetComponent<Text>();
                cam = maincamera.GetComponent<Camera>();
                p_photonview = GetComponent<PhotonView>();
            }

            if (cam)
            {
                M4Ray();
            }

            if (!photonView.isMine)
            {
                return;
            }
        }




        public void M4Shooting()
        {
            if (PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().gun_magazine_bullet[3] <= 0)
            {
                return;
            }
            PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("M4_Audio", PhotonTargets.All);
            PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().ShotGunFire();
            PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().gun_magazine_bullet[3]--;


            hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    hit.collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().protect_calc -= PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().bullet_Power;
                    hit.collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("M4Damage", PhotonTargets.All);
                    if (hit.collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().life <= 0)
                    {
                        Debug.Log("kill");
                        u_photonview = hit.collider.gameObject.GetComponent<PhotonView>();
                        u_photonview.RPC("KillCount", PhotonTargets.All);
                        kill_text.SetActive(true);
                       
                        killText.text = ( "キルした！");

                      
                        photonControll.score += hit.collider.GetComponent<UnityChanControlScriptWithRgidBody>().player_Level;

                        Invoke("killTextOff", 5.0f);

                    }
                }

                if (hit.collider.gameObject.tag == "Head")
                {
                    hit.collider.transform.parent.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("Head_M4Damage", PhotonTargets.All);
                    if (hit.collider.transform.parent.GetComponent<UnityChanControlScriptWithRgidBody>().life <= 0)
                    {
                        Debug.Log("kill");
                        u_photonview = hit.collider.transform.parent.GetComponent<PhotonView>();
                        u_photonview.RPC("KillCount", PhotonTargets.All);
                        kill_text.SetActive(true);
                        killText.text = ("キルした！");

                        photonControll.score += hit.collider.GetComponent<UnityChanControlScriptWithRgidBody>().player_Level;

                        Invoke("killTextOff", 5.0f);

                    }
                }


            }
        }


        public void M4Ray()
        {
            if (m4 == null)
            {
                m4 = gun_player.transform.Find("Character1_Reference/Character1_Hips/Character1_Spine/Character1_Spine1/Character1_Spine2/Character1_RightShoulder/Character1_RightArm/Character1_RightForeArm/Character1_RightHand/M4").gameObject;
            }
            Vector3 Center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            target_ray = new Ray(targetObj.transform.position, cam.transform.forward);

            if (Physics.Raycast(target_ray, out target_hit, distance))
            {

                t_direction = (target_hit.point - shotPoint.transform.position).normalized;
            }


            ray = new Ray(shotPoint.transform.position, t_direction);

            Debug.DrawRay(target_ray.origin, target_ray.direction * distance, Color.yellow);
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
           

        }

        public void killTextOff()
        {
            kill_text.SetActive(false);
        }

        [PunRPC]
        public void KillText()
        {

        }
    }
}
