using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
public class CubeCount : MonoBehaviour {
        public Text red_cube_text;
        public Text blue_cube_text;
        public Text green_cube_text;
        public UnityChanControlScriptWithRgidBody playerData;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            red_cube_text.text = ("RedCube" + playerData.red_Cube.ToString());
            blue_cube_text.text = ("BlueCube" + playerData.blue_Cube.ToString());
            green_cube_text.text = ("GreenCube" + playerData.green_Cube.ToString());

	}
}

}
