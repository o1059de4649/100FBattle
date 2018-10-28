using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
public class HpTextEnemy : MonoBehaviour {
        Slider slider;
        public GameObject skeleton;
	// Use this for initialization
	void Start () {
            slider = GetComponent<Slider>();

          
	}
	
	// Update is called once per frame
	void Update () {
            
            if (this.gameObject.name == "Skeleton_hpbar")
            {
                slider.maxValue = skeleton.GetComponent<SkeletonStatus>()._maxLife;
                slider.value = skeleton.GetComponent<SkeletonStatus>().life;
            }
	}
}

}
