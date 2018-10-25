using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class ShotGunShot : Photon.MonoBehaviour
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
        Ray ray_2;
        Ray ray_3;
        Ray ray_4;
        Ray ray_5;
        Ray ray_6;
        Ray ray_7;
        Ray ray_8;
        public AudioClip shotGunfireAudio;
        AudioSource audioSource;
        PhotonView p_photonview;
        PhotonView u_photonview;
        GameObject shotGun;
        public GameObject kill_text;
        Text killText;
        float distance = 30;
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
                ShotGunRay();
            }

            if (!photonView.isMine)
            {
                return;
            }
        }




        public void ShotGunShooting()
        {
            if (PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().gun_magazine_bullet[2] <= 0)
            {
                return;
            }
            PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("ShotGun_Audio", PhotonTargets.All);
            PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().ShotGunFire();
            PhotonControll.player.GetComponent<UnityChanControlScriptWithRgidBody>().gun_magazine_bullet[2]--;


            hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, distance*2))
            {
                if (hit.collider.gameObject.tag == "Player")
                {

                    hit.collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("ShotGunDamage", PhotonTargets.All);
                    if (hit.collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().life <= 0)
                    {
                        Debug.Log("kill");
                        u_photonview = hit.collider.gameObject.GetComponent<PhotonView>();
                        u_photonview.RPC("KillCount", PhotonTargets.All);
                        kill_text.SetActive(true);
                        GameObject player_col = hit.collider.gameObject;
                        player_col.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("SetStatus", PhotonTargets.All);
                       
                        photonControll.score += hit.collider.GetComponent<UnityChanControlScriptWithRgidBody>().player_Level;
                        killText.text = ("キルした！");



                        Invoke("killTextOff", 5.0f);

                    }
                }

    
            }

            if (Physics.Raycast(ray_2, out hit, distance))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    hit.collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("ShotGunDamage", PhotonTargets.All);
                }
            }

            if (Physics.Raycast(ray_3, out hit, distance))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    hit.collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("ShotGunDamage", PhotonTargets.All);
                }
            }

            if (Physics.Raycast(ray_4, out hit, distance))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    hit.collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("ShotGunDamage", PhotonTargets.All);
                }
            }

            if (Physics.Raycast(ray_5, out hit, distance/1.5f))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    hit.collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("ShotGunDamage", PhotonTargets.All);
                }
            }

            if (Physics.Raycast(ray_6, out hit, distance/1.5f))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    hit.collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("ShotGunDamage", PhotonTargets.All);
                }
            }

            if (Physics.Raycast(ray_7, out hit, distance/1.5f))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    hit.collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("ShotGunDamage", PhotonTargets.All);
                }
            }

            if (Physics.Raycast(ray_8, out hit, distance/1.5f))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    hit.collider.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().u_photonView.RPC("ShotGunDamage", PhotonTargets.All);
                }
            }
        }


        public void ShotGunRay()
        {
            if (shotGun == null)
            {
                shotGun = gun_player.transform.Find("Character1_Reference/Character1_Hips/Character1_Spine/Character1_Spine1/Character1_Spine2/Character1_RightShoulder/Character1_RightArm/Character1_RightForeArm/Character1_RightHand/ShotGun").gameObject;
            }
            Vector3 Center = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            target_ray = new Ray(targetObj.transform.position, cam.transform.forward);

            if (Physics.Raycast(target_ray, out target_hit, distance))
            {

                t_direction = (target_hit.point - shotPoint.transform.position).normalized;
            }



            Debug.DrawRay(target_ray.origin, target_ray.direction * distance, Color.yellow);
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
            Debug.Log(t_direction);

            ray = new Ray(shotPoint.transform.position, t_direction);
            ray_2 = new Ray(shotPoint.transform.position, t_direction + new Vector3(Random.Range(-0.075f, 0.075f),Random.Range(-0.075f,0.075f),Random.Range(-0.075f,0.075f)));
            ray_3 = new Ray(shotPoint.transform.position, t_direction + new Vector3(Random.Range(-0.075f, 0.075f), Random.Range(-0.075f, 0.075f), Random.Range(-0.075f, 0.075f)));
            ray_4 = new Ray(shotPoint.transform.position, t_direction + new Vector3(Random.Range(-0.075f, 0.075f), Random.Range(-0.075f, 0.075f), Random.Range(-0.075f, 0.075f)));
            ray_5 = new Ray(shotPoint.transform.position, t_direction + new Vector3(Random.Range(-0.075f, 0.075f), Random.Range(-0.075f, 0.075f), Random.Range(-0.075f, 0.075f)));
            ray_6 = new Ray(shotPoint.transform.position, t_direction + new Vector3(Random.Range(-0.075f, 0.075f), Random.Range(-0.075f, 0.075f), Random.Range(-0.075f, 0.075f)));
            ray_7 = new Ray(shotPoint.transform.position, t_direction + new Vector3(Random.Range(-0.075f, 0.075f), Random.Range(-0.075f, 0.075f), Random.Range(-0.075f, 0.075f)));
            ray_8 = new Ray(shotPoint.transform.position, t_direction + new Vector3(Random.Range(-0.075f, 0.075f), Random.Range(-0.075f, 0.075f), Random.Range(-0.075f, 0.075f)));

            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
            Debug.DrawRay(ray_2.origin, ray_2.direction * distance, Color.red);
            Debug.DrawRay(ray_3.origin, ray_3.direction * distance, Color.red);
            Debug.DrawRay(ray_4.origin, ray_4.direction * distance, Color.red);
            Debug.DrawRay(ray_5.origin, ray_5.direction * distance, Color.red);
            Debug.DrawRay(ray_6.origin, ray_3.direction * distance, Color.red);
            Debug.DrawRay(ray_7.origin, ray_4.direction * distance, Color.red);
            Debug.DrawRay(ray_8.origin, ray_5.direction * distance, Color.red);

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
