using System.Collections.Generic;
using UnityEngine;
using System.Collections;
namespace UnityStandardAssets.CrossPlatformInput
{

    [RequireComponent(typeof(PhotonView))]
    public class InRoomChat : Photon.MonoBehaviour
    {
        #region 変数宣言
        //範囲チャット実装のためのオブジェクト、変数定義
        GameObject[] players;   //全てのプレイヤーキャラ取得用
        GameObject sender;      //送信キャラ取得用
        GameObject myPlayer;    //自分のキャラ取得用
        GUIStyle ChatStyle = new GUIStyle();    //範囲チャットStyle
        GUIStyleState ChatStyleState = new GUIStyleState();
        GUIStyle AllChatStyle = new GUIStyle(); //全体チャットStyle
        GUIStyleState AllChatStyleState = new GUIStyleState();
        public Rect GuiRect = new Rect(0, 0, 300, 200); //チャットUIの大きさ設定用
        public bool IsVisible = true;   //チャットUI表示非表示フラグ
        public bool AlignBottom = true;
        public List<string> messages = new List<string>();  //チャットログ格納用List
        public List<bool> chatKind = new List<bool>(); //チャットログの種類格納用(範囲チャor全チャ)
        public string inputLine = "";//入力文章格納用String
        private Vector2 scrollPos = Vector2.zero;   //スクロールバー位置
        #endregion
        #region Start関数 Updata関

        public void Start()
        {
            //myPlayerオブジェクト取得(範囲チャット発言時にpositionとmyPM使う)
            GetmyPlayer();
            //範囲チャットの場合は白文字にし、文字がＵＩからあふれた場合は折り返す設定
            ChatStyleState.textColor = Color.white;
            ChatStyle.normal = ChatStyleState;
            ChatStyle.wordWrap = true;
            ChatStyle.fontSize = 36;
            //全体チャットの場合は赤文字にし、文字がＵＩからあふれた場合は折り返す設定
            AllChatStyleState.textColor = Color.red;
            AllChatStyle.normal = AllChatStyleState;
            AllChatStyle.wordWrap = true;
            AllChatStyle.fontSize = 36;



        }
        public void Update()
        {
            //ChatUIの位置を調整
            this.GuiRect.y = Screen.height - this.GuiRect.height;
            //ChatUIの大きさ調整
            GuiRect.width = Screen.width / 2;
            GuiRect.height = Screen.height / 2;
        }
        #endregion
        #region OnGUI関数
        public void OnGUI()
        {
            if (!this.IsVisible || !PhotonNetwork.inRoom)   //表示フラグがOFFまたはphotonにつながっていないとき
            {
                //UI非表示
                return;
            }
            //ChatUIの作成開始
            //チャットUI生成　Begin&EndAreaでチャットUIの位置と大きさを設定 
            GUILayout.Window(0, GuiRect, ChatUIWindow, "");   //チャットUIウインドウを作成
                                                              //Enterを押すと
            if (Event.current.type == EventType.KeyDown && (Event.current.keyCode == KeyCode.KeypadEnter || Event.current.keyCode == KeyCode.Return))
            {
                //チャット入力待ち状態にする
                GUI.FocusControl("ChatInput");
            }
        }
        #endregion
        #region チャットUI生成
        void ChatUIWindow(int windowID)
        {
            //FocusがチャットUIに乗ってるときにEnterを押すとチャット発言が実行される
            if (Event.current.type == EventType.KeyDown && (Event.current.keyCode == KeyCode.KeypadEnter || Event.current.keyCode == KeyCode.Return))
            {
                if (!string.IsNullOrEmpty(this.inputLine))  //チャット入力欄がNullやEmptyでない場合
                {
                    //範囲チャット送信関数実行
                    SendChat(false);
                    return;
                }
            }
            //垂直のコントロールグループ開始
            GUILayout.BeginVertical();
            //スクロールビュー開始位置
            scrollPos = GUILayout.BeginScrollView(scrollPos);
            //チャットログ表示用フレキシブルスペース生成
            GUILayout.FlexibleSpace();
            //フレキシブルスペースにチャットログを表示
            for (int i = 0; i <= messages.Count - 1; i++)
            {
                if (chatKind[i] != true)    //範囲チャットであれば
                {
                    GUILayout.Label(messages[i], ChatStyle);
                }
                else                        //全チャットであれば
                {
                    GUILayout.Label(messages[i], AllChatStyle);
                }
            }
            //スクロールビュー終了
            GUILayout.EndScrollView();
            //水平のコントロールグループ開始
            GUILayout.BeginHorizontal();
            //入力テキストフィールド生成、Focusが乗った状態をChatInputと命名
            GUI.SetNextControlName("ChatInput");


            inputLine = GUILayout.TextField(inputLine,200,GUILayout.Height(50));



            //「Send」ボタンを生成かつ押したときには範囲チャット送信
            if (GUILayout.Button("Send",GUILayout.ExpandWidth(false),GUILayout.Width(80),GUILayout.Height(50)))
            {
                //範囲チャット送信関数実行
                SendChat(false);
            }
            //Allボタンを生成かつ押したときには全体チャット送信
            if (GUILayout.Button("All", GUILayout.ExpandWidth(false), GUILayout.Width(80), GUILayout.Height(50)))
            {
                //全体チャット送信関数実行
                SendChat(true);
            }
            //水平のコントロールグループ終了
            GUILayout.EndHorizontal();
            //垂直のコントロールグループ終了
            GUILayout.EndVertical();
        }
        #endregion
        #region GetmyPlayer 自キャラのオブジェクトをmyPlayerに登録
        void GetmyPlayer()
        {
            //自キャラのID取得
            int myPlayerID = PhotonNetwork.player.ID;
            //全てのプレイヤーオブジェクトを取得
            players = GameObject.FindGameObjectsWithTag("Player");
            //全てのプレイヤーオブジェクトから自キャラをIDで検索し、取り出す
            foreach (GameObject player in players)
            {
                int playerLoopId = player.GetComponent<PhotonView>().owner.ID;
                if (playerLoopId == myPlayerID)
                {
                    //自プレイヤーオブジェクトを取得
                    myPlayer = player;
                }
            }
            return;
        }
        #endregion
        #region チャット送信関数
        void SendChat(bool isAll)
        {
            if (myPlayer == null)
            {
                myPlayer = PhotonControll.player;
            }
            //chatRPC
            this.photonView.RPC("Chat", PhotonTargets.All, myPlayer.transform.position, this.inputLine, isAll);
            //送信後、入力欄を空にし、スクロール最下位置に移動
            this.inputLine = "";
            scrollPos.y = Mathf.Infinity;
        }
        #endregion
        #region ChatRPC RPC呼出側：送信者　RPC受信側：受信者
        [PunRPC]
        public void Chat(Vector3 senderposition, string newLine, bool isAll, PhotonMessageInfo mi)
        {
            if (messages.Count >= 100)          //チャットログが多くなって来たらログを削除してから受信
            {
                messages.Clear();               //全てのチャットログを削除
                chatKind.Clear();               //全てのチャットの種類情報削除
            }
            if (!isAll) //範囲チャとして受信
            {
                //myPlayerとsenderの距離から受信するか判断
                if (Vector3.Distance(myPlayer.transform.position, senderposition) < 10)
                {
                    //chat受信
                    ReceiveChat(newLine, isAll, mi);
                }
            }
            else if (isAll) //全チャとして受信
            {
                //chat受信
                ReceiveChat(newLine, isAll, mi);
            }
            //受信したときはスクロール最下位置
            scrollPos.y = Mathf.Infinity;
        }
        #endregion
        #region チャット受信関数
        void ReceiveChat(string _newLine, bool isAll, PhotonMessageInfo _mi)
        {
            //送信者の名前用変数
            string senderName = "anonymous";
            if (_mi.sender != null)
            {
                //送信者の名前があれば
                if (!string.IsNullOrEmpty(_mi.sender.NickName))
                {
                    senderName = _mi.sender.NickName;
                }
                else
                {
                    senderName = "player " + _mi.sender.ID;
                }
            }
            //受信したチャットをログに追加
            this.messages.Add(senderName + ": " + _newLine);
            this.chatKind.Add(isAll);
            return;
        }
        #endregion

        public void AddLine(string newLine)
        {
            this.messages.Add(newLine);
        }
    }
}