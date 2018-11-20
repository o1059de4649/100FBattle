using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class MyRoomObjectMovement : MonoBehaviour
    {
        private Vector3 velocity;
        private Vector3 h_velocity;

        public float forwardSpeed = 7.0f;
        public float backwardSpeed = 2.0f;
        public float _MoveSpeedRL = 2;

        float r;
        float v;

        public GameObject _spawnPos;
        // Use this for initialization
        void Start()
        {
            _spawnPos = GameObject.Find("PlayerMyRoom/CameraStork/MainCamera/SpawnPos");
        }

        // Update is called once per frame
        void Update()
        {






            //旧式
            /*r = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            v = CrossPlatformInputManager.GetAxisRaw("Vertical");

            if (v >= 1)
            {
                v = 1;
            }

            if (v < -1)
            {
                v = -1;
            }


            if (r >= 1)
            {
                r = 1;
            }

            if (r < -1)
            {
                r = -1;
            }

            // 以下、キャラクターの移動処理
            h_velocity = new Vector3(r, 0, 0);        // 上下のキー入力からZ軸方向の移動量を取得
                                                      // キャラクターのローカル空間での方向に変換
            h_velocity = transform.TransformDirection(h_velocity);
            //以下のvの閾値は、Mecanim側のトランジションと一緒に調整する
            if (r > 0.1)
            {
                h_velocity *= _MoveSpeedRL;       // 移動速度を掛ける
            }
            else if (r < -0.1)
            {
                h_velocity *= _MoveSpeedRL;  // 移動速度を掛ける
            }


            // 以下、キャラクターの移動処理
            velocity = new Vector3(0, 0, v);        // 上下のキー入力からZ軸方向の移動量を取得
                                                    // キャラクターのローカル空間での方向に変換
            velocity = transform.TransformDirection(velocity);
            //以下のvの閾値は、Mecanim側のトランジションと一緒に調整する
            if (v > 0.1)
            {
                velocity *= forwardSpeed;       // 移動速度を掛ける
            }
            else if (v < -0.1)
            {
                velocity *= backwardSpeed;  // 移動速度を掛ける
            }

            transform.localPosition += velocity * Time.fixedDeltaTime;
            transform.localPosition += h_velocity * Time.fixedDeltaTime;
            */

        }

        public void Move()
        {
            transform.position = _spawnPos.transform.position;
        }

        public void RotateMoveRight(){
            transform.eulerAngles += new Vector3(0, 5, 0);
        }

        public void RotateMoveLeft(){
            transform.eulerAngles += new Vector3(0, -5, 0);
        }

        public void ResetPosition()
        {
            transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);
            transform.position += new Vector3(0, 3, 0);
        }


    }
}