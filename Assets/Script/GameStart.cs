using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    
    public class GameStart : Photon.MonoBehaviour
    {
        public PhotonControll photonControll;
        public PhotonView photonView;
        public Text message;
        public Text timer;
        public float play_time = 600;
        public bool game_start = false;
        GameObject p_player;
        // Use this for initialization
        void Start()
        {
            photonView = GetComponent<PhotonView>();
            game_start = false;
        }

        // Update is called once per frame
        void Update()
        {


            if(game_start == true){
                play_time -= Time.deltaTime;
                if(play_time < 0){
                    game_start = false;
                    PhotonControll.player.GetPhotonView().RPC("GameFinish", PhotonTargets.AllBuffered);
                    play_time = 600;

                }

            }

         

            if(game_start == false){
                message.text = ("戦争は終わった！");
            }

            if(game_start == true){
                timer.text = (play_time.ToString());
            }

            if(game_start == true){
                message.text = ("戦いは始まっている！");
            }
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "MyPlayer")
            {
                collision.gameObject.GetPhotonView().RPC("GameStarter", PhotonTargets.All);
            }

        }

        public void GameFinish()
        {
            game_start = false;
            play_time = 600;
        }

      
      

      


    }
}