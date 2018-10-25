using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class PhotonControl : Photon.PunBehaviour
    {
        public GameObject unitychan;
        public static GameObject player;
        public static int PlayerCreate = 0;
        public int createroom = 0;
        public int kill = 0;
        public GameObject obj;
        public int playercount;
        public float SpownTime = 5f;
        float timed;
        public static int count;
        public int MaxSpown = 3;
        PhotonView photonView;
        public Room room;
        public GameObject[] house = new GameObject[3];

        [SerializeField]
        public Text informationText;
        public GameObject loginUI;
        public Dropdown roomLists;
        public InputField roomName;
        public GameObject logoutUI;
        public InputField playerName;
        public GameObject mapcamera;
        public GameObject ship;
        public PhotonPlayer p_player;

        void Start()
        {
            //　ログをすべて表示する
            PhotonNetwork.logLevel = PhotonLogLevel.Full;

            //　ロビーに自動で入る
            PhotonNetwork.autoJoinLobby = true;

            //　ゲームのバージョン設定
            PhotonNetwork.ConnectUsingSettings("0.2");
            photonView = GetComponent<PhotonView>();
        }

        void Update()
        {

            //　サーバ接続状態を表示
            informationText.text = PhotonNetwork.connectionStateDetailed.ToString();

            if (Input.GetKeyDown(KeyCode.C))
            {
                PhotonNetwork.LeaveRoom();
            }
        }

        //　ログインボタンを押した時に実行するメソッド
        public void LoginGame()
        {
            //　ルームオプションを設定
            RoomOptions ro = new RoomOptions()
            {
                //　ルームを見えるようにする
                IsVisible = true,
                //　部屋の入室最大人数
                MaxPlayers = 10
            };

            if (roomName.text != "")
            {
                //　部屋がない場合は作って入室
                PhotonNetwork.JoinOrCreateRoom(roomName.text, ro, TypedLobby.Default);
            }
            else
            {
                //　部屋が存在すれば
                if (roomLists.options.Count != 0)
                {
                    Debug.Log(roomLists.options[roomLists.value].text);
                    PhotonNetwork.JoinRoom(roomLists.options[roomLists.value].text);
                    //　部屋が存在しなければDefaultRoomという名前で部屋を作成
                }
                else
                {
                    PhotonNetwork.JoinOrCreateRoom("DefaultRoom", ro, TypedLobby.Default);
                }
            }

            mapcamera.SetActive(false);
        }

        public override void OnReceivedRoomListUpdate()
        {
            Debug.Log("部屋更新");
            //　部屋情報を取得する
            RoomInfo[] rooms = PhotonNetwork.GetRoomList();
            //　ドロップダウンリストに追加する文字列用のリストを作成
            List<string> list = new List<string>();

            //　部屋情報を部屋リストに表示
            foreach (RoomInfo room in rooms)
            {
                //　部屋が満員でなければ追加
                if (room.PlayerCount < room.MaxPlayers)
                {
                    list.Add(room.Name);
                }
            }

            //　ドロップダウンリストをリセット
            roomLists.ClearOptions();

            //　部屋が１つでもあればドロップダウンリストに追加
            if (list.Count != 0)
            {
                roomLists.AddOptions(list);
            }
        }


        public override void OnJoinedLobby()
        {
            Debug.Log("ロビーに入る");
            loginUI.SetActive(true);

        }

        void OnPhotonRandomJoinFailed()
        {

            Debug.Log("入室に失敗");

            //　ルームオプションを設定
            RoomOptions ro = new RoomOptions()
            {
                //　ルームを見えるようにする
                IsVisible = false,
                //　部屋の入室最大人数
                MaxPlayers = 10
            };
            //　入室に失敗したらDefaultRoomを作成し入室
            PhotonNetwork.JoinOrCreateRoom("DefaultRoom", ro, TypedLobby.Default);


        }

        public override void OnCreatedRoom()
        {
            photonView.RPC("HouseSpawn", PhotonTargets.All);



            Debug.Log("CreateRoom");
        }

        public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer){
            
           

        }


        public override void OnJoinedRoom()
        {
            loginUI.SetActive(false);
            logoutUI.SetActive(true);
            Debug.Log("入室");

            //　InputFieldに入力した名前を設定
            PhotonNetwork.playerName = playerName.text;

           

            Invoke("InstantiatePlayerStart", 3.0f);
           


        }

        void InstantiatePlayerStart(){
            player = PhotonNetwork.Instantiate(
                unitychan.name,
                ship.transform.position,
              Quaternion.identity,
              0);

            PlayerCreate++;
           
        }

        public void LeftRoom()
        {
            PhotonNetwork.LeaveRoom();

        }

        public override void OnLeftRoom()
        {
           

            Debug.Log("退室");
            logoutUI.SetActive(false);
            mapcamera.SetActive(true);
        }

        [PunRPC]
        public void PlayerDelete(){
            createroom--;
        }

        public void LogoutGame()
        {
            photonView.RPC("PlayerDelete", PhotonTargets.All);
            PhotonNetwork.LeaveRoom();
        }

        public void InstantiatePlayer()
        {
            player = null;
            player = PhotonNetwork.Instantiate(
               unitychan.name,
                ship.transform.position,
             Quaternion.identity,
             0);


        }

        [PunRPC]
        public void HouseSpawn()
        {
            createroom++;
            PhotonNetwork.Instantiate(
               house[0].name,
                new Vector3(Random.Range(-130, 130), 0, Random.Range(-130, 130)),
            Quaternion.identity,
            0);

            PhotonNetwork.Instantiate(
              house[1].name,
                new Vector3(Random.Range(-130, 130), 0, Random.Range(-130, 130)),
           Quaternion.identity,
           0);

            PhotonNetwork.Instantiate(
              house[2].name,
                new Vector3(Random.Range(-130, 130), 0, Random.Range(-130, 130)),
           Quaternion.identity,
           0);

           
        }

    }
}
