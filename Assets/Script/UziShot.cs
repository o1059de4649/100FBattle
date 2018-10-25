using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class UziShot : Photon.MonoBehaviour
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
        public AudioClip uzifireAudio;
        AudioSource audioSource;
        PhotonView p_photonview;
        PhotonView u_photonview;
        GameObject uzi;
        public GameObject kill_text;
        Text killText;
        int distance = 70;
        public GameObject shotPoint;
        public PhotonControll photonControll;
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
                UziRay();
            }

            if (!photonView.isMine)
            {
                return;
            }
        }




        public void UziShooting()
        {
            if (PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().gun_magazine_bullet[1] <= 0)
            {
                return;
            }
            PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("Uzi_Audio", PhotonTargets.All);
            PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().PistolFire();
            PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().gun_magazine_bullet[1]--;


            hit = new RaycastHit();
            target_hit = new RaycastHit();

          

            if (Physics.Raycast(ray, out hit, distance))
            {
               
                if (hit.collider.gameObject.tag == "Player")
                {
                    hit.collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().protect_calc -= PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().bullet_Power;
                    hit.collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("UziDamage", PhotonTargets.All);
                    if (hit.collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().life <= 0)
                    {
                        Debug.Log("kill");
                        u_photonview = hit.collider.gameObject.GetComponent<PhotonView>();
                        u_photonview.RPC("KillCount", PhotonTargets.All);
                        kill_text.SetActive(true);
                
                        killText.text = ("キルした！");

                        photonControll.score += hit.collider.GetComponent<UnityChanControlScriptWithRgidBody>().player_Level;


                        Invoke("killTextOff", 5.0f);

                    }
                }

                if (hit.collider.gameObject.tag == "Head")
                {
                    hit.collider.transform.parent.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("Head_UziDamage", PhotonTargets.All);
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


        public void UziRay()
        {
            if (uzi == null)
            {
                uzi = gun_player.transform.Find("Character1_Reference/Character1_Hips/Character1_Spine/Character1_Spine1/Character1_Spine2/Character1_RightShoulder/Character1_RightArm/Character1_RightForeArm/Character1_RightHand/Uzi").gameObject;
            }
            Vector3 Center = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            target_ray = new Ray(targetObj.transform.position, cam.transform.forward);

            if (Physics.Raycast(target_ray, out target_hit, distance))
            {

                t_direction = (target_hit.point - shotPoint.transform.position).normalized;
            }


            ray = new Ray(shotPoint.transform.position,t_direction + new Vector3(Random.Range(-0.015f, 0.15f),Random.Range(-0.015f, 0.015f), Random.Range(-0.015f, 0.015f)));

            Debug.DrawRay(target_ray.origin, target_ray.direction * distance, Color.yellow);
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
           

          

        }

        void killTextOff()
        {
            kill_text.SetActive(false);
        }

        [PunRPC]
        public void KillText()
        {

        }
    }
}
