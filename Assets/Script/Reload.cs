using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class Reload : MonoBehaviour, IPointerEnterHandler
    {
        public UnityChanControlScriptWithRgidBody p_ucrb;
        public int[] max_Magazine;

        // Use this for initialization
        void Start()
        {
            max_Magazine[0] = 16;
            max_Magazine[1] = 26;
            max_Magazine[2] = 5;
            max_Magazine[3] = 31;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (this.gameObject.name == "handgunReload")
            {
                if (p_ucrb.reload_on == false)
                {

                    p_ucrb.reload_on = true;
                    Invoke("Reloadoff", 1.5f);
                    Invoke("ReloadnowHandGun", 1.5f);
                }

            }

            if (this.gameObject.name == "UziReload")
            {
                if (p_ucrb.reload_on == false)
                {

                    p_ucrb.reload_on = true;
                    Invoke("Reloadoff", 1.5f);
                    Invoke("ReloadnowUzi", 3.0f);
                }

            }

            if (this.gameObject.name == "ShotGunReload")
            {
                if (p_ucrb.reload_on == false)
                {

                    p_ucrb.reload_on = true;
                    Invoke("Reloadoff", 1.5f);
                    Invoke("ReloadnowShotGun", 3.0f);
                }

            }


            if (this.gameObject.name == "M4Reload")
            {
                if (p_ucrb.reload_on == false)
                {

                    p_ucrb.reload_on = true;
                    Invoke("Reloadoff", 1.5f);
                    Invoke("ReloadnowM4", 3.5f);
                }

            }






        }

        public void Reloadoff()
        {
            p_ucrb.reload_on = false;
        }

        public void ReloadnowHandGun()
        {
            if (p_ucrb.smallbullet >= max_Magazine[0])
            {

                int bullet_Reload = max_Magazine[0] - p_ucrb.gun_magazine_bullet[0];//補填数算出

                p_ucrb.smallbullet -= bullet_Reload;//たま消費
                p_ucrb.gun_magazine_bullet[0] += bullet_Reload;//補填完了
            }

            if (p_ucrb.smallbullet > 0 && p_ucrb.smallbullet < max_Magazine[0])//端数管理
            {

                p_ucrb.gun_magazine_bullet[0] += p_ucrb.smallbullet;
                p_ucrb.smallbullet = 0;

            }


        }

        public void ReloadnowUzi()
        {
            if (p_ucrb.smallbullet >= max_Magazine[1])
            {

                int bullet_Reload = max_Magazine[1] - p_ucrb.gun_magazine_bullet[1];//補填数算出

                p_ucrb.smallbullet -= bullet_Reload;//たま消費
                p_ucrb.gun_magazine_bullet[1] += bullet_Reload;//補填完了
            }

            if (p_ucrb.smallbullet > 0 && p_ucrb.smallbullet < max_Magazine[1])//端数管理
            {

                p_ucrb.gun_magazine_bullet[1] += p_ucrb.smallbullet;
                p_ucrb.smallbullet = 0;

            }


        }

        public void ReloadnowShotGun()
        {
            if (p_ucrb.shotGunBullet >= max_Magazine[2])
            {

                int bullet_Reload = max_Magazine[2] - p_ucrb.gun_magazine_bullet[2];//補填数算出

                p_ucrb.shotGunBullet -= bullet_Reload;//たま消費
                p_ucrb.gun_magazine_bullet[2] += bullet_Reload;//補填完了
            }

            if (p_ucrb.shotGunBullet > 0 && p_ucrb.shotGunBullet < max_Magazine[2])//端数管理
            {

                p_ucrb.gun_magazine_bullet[2] += p_ucrb.shotGunBullet;
                p_ucrb.shotGunBullet = 0;

            }
        }

        public void ReloadnowM4()
        {
            if (p_ucrb.middleBullet >= max_Magazine[3])
            {
                
                int bullet_Reload = max_Magazine[3] - p_ucrb.gun_magazine_bullet[3];//補填数算出

                p_ucrb.middleBullet -= bullet_Reload;//たま消費
                p_ucrb.gun_magazine_bullet[3] += bullet_Reload;//補填完了
            }

            if (p_ucrb.middleBullet > 0 && p_ucrb.middleBullet < max_Magazine[3])//端数管理
            {

                p_ucrb.gun_magazine_bullet[3] += p_ucrb.middleBullet;
                p_ucrb.middleBullet = 0;

            }


        }

    }
}
