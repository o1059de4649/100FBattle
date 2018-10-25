using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{


    public class Suicide : MonoBehaviour
    {
        public Text message;

        public GameObject game_startObj;
        public GameObject respawn_Pos;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(game_startObj.GetComponent<GameStart>().game_start == true){
                message.text = ("さあ、出発だ！");
            }else{
                message.text = ("スカイシップには乗れない");
            }
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "MyPlayer" && game_startObj.GetComponent<GameStart>().game_start == true)
            {
                collision.gameObject.transform.position = respawn_Pos.transform.position;
            }
        }
    }
}
