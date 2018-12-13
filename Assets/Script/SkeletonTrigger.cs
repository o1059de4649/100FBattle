using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class SkeletonTrigger : MonoBehaviour
    {
        public GameObject user_parent;
        GameObject team;
        float player_dist;

        GameObject enemy;
        PlayerTeamAI aI;
        // Use this for initialization
        void Start()
        {
            this.gameObject.AddComponent<SphereCollider>();
            this.gameObject.GetComponent<SphereCollider>().isTrigger = true;


            if(user_parent.tag == "Enemy"){
                player_dist = user_parent.GetComponent<SkeletonStatus>().player_dist;
                this.gameObject.GetComponent<SphereCollider>().radius = user_parent.GetComponent<SkeletonStatus>().preradius;
            }

            if(user_parent.tag == "Team"){
                enemy = user_parent.GetComponent<PlayerTeamAI>().enemy;
                aI = user_parent.GetComponent<PlayerTeamAI>();
                this.gameObject.GetComponent<SphereCollider>().radius = user_parent.GetComponent<SkeletonStatus>().preradius * 1.5f;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnTriggerStay(Collider col)
        {
            //user敵の時
            if (user_parent.tag == "Enemy")
            {
                if (col.gameObject.tag == "Player")
                {
                    user_parent.GetComponentInParent<SkeletonStatus>().OnAttack();
                    return;
                }

                if (col.gameObject.tag == "Team" && player_dist > 15)
                {

                    if (team == null)
                    {
                        team = GameObject.FindWithTag("Team");
                    }

                    user_parent.transform.LookAt(team.transform);
                    user_parent.GetComponentInParent<SkeletonStatus>().OnAttack();
                    return;
                }

            }

            //user仲間の時
            if(user_parent.tag == "Team"){
                if (col.gameObject.tag == "Enemy")
                {
                    if (enemy == null)
                    {
                        GameObject.FindWithTag("Enemy");
                    }
                    aI.MoveToEnemy();
                    aI.OnAttack();
                    aI.isEnemy = true;
                    return;
                }
            }
        }

        public void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Enemy")
            {
                enemy = col.gameObject;
            }
        }
    }
}
