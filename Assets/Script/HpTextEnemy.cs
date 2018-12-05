using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
public class HpTextEnemy : MonoBehaviour {
        Slider slider;
        public GameObject skeleton;
        public SkeletonStatus skeleton_Status;
	// Use this for initialization
	void Start () {
            slider = GetComponent<Slider>();

            skeleton_Status = skeleton.GetComponent<SkeletonStatus>();
	}
	
	// Update is called once per frame
	void Update () {

            if(skeleton_Status == null){
                slider.value = skeleton.GetComponent<PlayerTeamAI>()._life;
                slider.maxValue = skeleton.GetComponent<PlayerTeamAI>()._maxLife;
            }

            if (this.gameObject.name == "Skeleton_hpbar" && skeleton_Status != null)
            {
                slider.maxValue = skeleton_Status._maxLife;
                slider.value = skeleton_Status._life;
            }
	}
}

}
