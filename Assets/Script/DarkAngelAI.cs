using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class DarkAngelAI : MonoBehaviour
    {
        public Animator anim;
        public SkeletonStatus skeletonStatus;
        public GameObject _prefab;
        bool isSpawn = false;
        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(this.gameObject.GetComponentInParent<PlayerTeamAI>() != null){
                Destroy(this);
            }

            if(skeletonStatus._life < skeletonStatus._maxLife / 2 && isSpawn == false){
                skeletonStatus.v = 0;
                anim.SetTrigger("Up");
                Instantiate(_prefab,this.transform.position + new Vector3(3,0,0), Quaternion.identity);
                Instantiate(_prefab, this.transform.position + new Vector3(-3, 0, 0), Quaternion.identity);
                isSpawn = true;
            }
        }
    }
}