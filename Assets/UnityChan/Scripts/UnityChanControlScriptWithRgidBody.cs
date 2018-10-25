//
// Mecanimのアニメーションデータが、原点で移動しない場合の Rigidbody付きコントローラ
// サンプル
// 2014/03/13 N.Kobyasahi
//
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{

    // 必要なコンポーネントの列記
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]

    public class UnityChanControlScriptWithRgidBody : Photon.MonoBehaviour
    {
        public GameObject drop_item;
        GameObject drop_item_obj;
        DethDropItem dethDropItem;

        public GameObject player_camera;
        public GameObject p_camera_Stork;

        public GameObject duo_Panel;
        public Canvas canvas;
        public float lifePlus = 0;
        public float maxLife = 100;
        public float life = 100;
        public float bullet_Power = 0;
        public int smallbullet = 0;
        public int shotGunBullet = 0;
        public int middleBullet = 0;
        public int bigBullet = 0;
        public float exp_point = 0;
        public float Max_exp_point = 100;
        public int player_Level;
        public string player_Name = "DefaultName";
        public Text player_text;

        public int have_handgun = 0;
        public int have_Uzi = 0;
        public int have_ShotGun = 0;
        public int have_M4 = 0;
        public int have_M107 = 0;

        public int[] gun_magazine_bullet;

        public float protectPlus = 0;
        public int protect = 0;
        public float protect_calc = 1;

        public int have_aid = 0;
        int t;
        public GameObject aidbutton;

        public float animSpeed = 1.5f;              // アニメーション再生速度設定
        public float lookSmoother = 3.0f;           // a smoothing setting for camera motion
        public bool useCurves = true;               // Mecanimでカーブ調整を使うか設定する
                                                    // このスイッチが入っていないとカーブは使われない
        public float useCurvesHeight = 0.5f;        // カーブ補正の有効高さ（地面をすり抜けやすい時には大きくする）

        // 以下キャラクターコントローラ用パラメタ
        // 前進速度
        public float forwardSpeed = 7.0f;
        // 後退速度
        public float backwardSpeed = 2.0f;
        // 旋回速度
        public float rotateSpeed = 2.0f;
        // ジャンプ威力
        public float jumpPower = 3.0f;
        // キャラクターコントローラ（カプセルコライダ）の参照
        private CapsuleCollider col;
        private Rigidbody rb;
        // キャラクターコントローラ（カプセルコライダ）の移動量
        private Vector3 velocity;
        private Vector3 h_velocity;
        // CapsuleColliderで設定されているコライダのHeiht、Centerの初期値を収める変数
        private float orgColHight;
        private Vector3 orgVectColCenter;

        private Animator anim;                          // キャラにアタッチされるアニメーターへの参照
        private AnimatorStateInfo currentBaseState;         // base layerで使われる、アニメーターの現在の状態の参照

        private GameObject cameraObject;    // メインカメラへの参照
        public PhotonView u_photonView;
        public float v;
        public float h;
        public float r;
        public bool forwardstart = false;
        public bool backstart = false;
        public bool left = false;
        public bool right = false;
        GameObject mapCamera;
        GameObject photonControll;

        public GameObject shirld1;

        public GameObject handGun_Obj;
        public GameObject shotGun_Obj;
        public GameObject uzi_Obj;
        public GameObject m4_Obj;
        public GameObject m107_Obj;

        public GameObject handGun_Obj_Panel;
        public GameObject shotGun_Obj_Panel;
        public GameObject uzi_Obj_Panel;
        public GameObject m4_Obj_Panel;
        public GameObject m107_Obj_Panel;


        public PhotonPlayer photonPlayer;
        public GameObject handGun_Panel;
        public GameObject Uzi_Panel;
        public GameObject ShotGun_Panel;
        public GameObject m4_Panel;
        public GameObject m107_Panel;

        public GameObject[] reload_Panel;

        public JumpButton jump_component;
        public GameStart game_startControl;

        public GameObject blood;
        public bool wait_anim = false;
        public GameObject head;
        public float head_rate = 2;

       
        public AudioSource gun_audio;
        public AudioClip handgun_clip,shotgun_clip,uzi_clip,m4_clip,m107_clip,cube_get;
        public AudioListener u_audioListener;

        public int blue_Cube = 0;
        public int green_Cube = 0;
        public int red_Cube = 0;

        public bool reload_on = false;

        public Text level_text;
        public CameraRotate cameraRotate;

        // アニメーター各ステートへの参照
        static int idleState = Animator.StringToHash("Base Layer.Idle");
        static int locoState = Animator.StringToHash("Base Layer.Locomotion");
        static int jumpState = Animator.StringToHash("Base Layer.Jump");
        static int restState = Animator.StringToHash("Base Layer.Rest");

        private PhotonTransformView photonTransformView;

        // 初期化
        void Start()
        {
            photonTransformView = GetComponent<PhotonTransformView>();
          


            u_photonView = GetComponent<PhotonView>();
            if (u_photonView.isMine)
            {
                photonControll = GameObject.Find("PhotonController");

               
                u_photonView.RPC("StartSetUp",PhotonTargets.All);


               
                exp_point = PlayerPrefs.GetFloat("Exp",0);
                player_Name = PlayerPrefs.GetString("playername");
                player_Level = PlayerPrefs.GetInt("Level", 0);
                lifePlus = PlayerPrefs.GetFloat("LifePuls",0);
                protectPlus = PlayerPrefs.GetFloat("ProtectPuls", 0);
                bullet_Power = PlayerPrefs.GetFloat("BulletPower", 0);
                red_Cube = PlayerPrefs.GetInt("RedCube",0);
                blue_Cube = PlayerPrefs.GetInt("BlueCube", 0);
                green_Cube = PlayerPrefs.GetInt("GreenCube", 0);


                u_audioListener.enabled = true;
                GetComponent<AudioSource>().enabled = true;
                GetComponentInChildren<Camera>().enabled = true;
                GetComponentInChildren<CameraControll>().enabled = true;
                GetComponentInChildren<TPSControll_y>().enabled = true;
                canvas.enabled = true;
                duo_Panel = GameObject.Find("DualTouchControls");
                duo_Panel.GetComponent<Canvas>().enabled = true;

                maxLife = life + lifePlus;
                life = maxLife;



                player_text.enabled = false;
                level_text.enabled = false;
                this.gameObject.tag = "MyPlayer";
                head.gameObject.tag = "MyHead";
               
               
            }


            // Animatorコンポーネントを取得する
            anim = GetComponent<Animator>();
            // CapsuleColliderコンポーネントを取得する（カプセル型コリジョン）
            col = GetComponent<CapsuleCollider>();
            rb = GetComponent<Rigidbody>();
            //メインカメラを取得する
            cameraObject = GameObject.FindWithTag("MainCamera");
            // CapsuleColliderコンポーネントのHeight、Centerの初期値を保存する
            orgColHight = col.height;
            orgVectColCenter = col.center;
        }


        // 以下、メイン処理.リジッドボディと絡めるので、FixedUpdate内で処理を行う.
        void FixedUpdate()
        {



            if (!u_photonView.isMine)
            {
                return;
            }
           
         

            protect_calc = protect * 0.3f + 1 + protectPlus;
          
           

            r = CrossPlatformInputManager.GetAxisRaw("Hori");
            v = CrossPlatformInputManager.GetAxisRaw("Vert");

               
          


            if(Max_exp_point <= exp_point){
                exp_point -= 100;
                player_Level++;
            }

            if(life > maxLife){
                life = maxLife;
            }
       

            if (life <= 0 && u_photonView.isMine)
            {

                photonControll.GetComponent<SaveData>().Save();
                photonControll.GetComponent<PhotonControll>().InstantiatePlayer();
                u_photonView.RPC("OnPlayerDestroy", PhotonTargets.All);
            }


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

          


            // 入力デバイスの水平軸をhで定義
            // 入力デバイスの垂直軸をvで定義
            anim.SetFloat("Speed", v);                          // Animator側で設定している"Speed"パラメタにvを渡す
            anim.SetFloat("Direction", h);                      // Animator側で設定している"Direction"パラメタにhを渡す
            anim.speed = animSpeed;                             // Animatorのモーション再生速度に animSpeedを設定する
            currentBaseState = anim.GetCurrentAnimatorStateInfo(0); // 参照用のステート変数にBase Layer (0)の現在のステートを設定する
            rb.useGravity = true;//ジャンプ中に重力を切るので、それ以外は重力の影響を受けるようにする


            // 以下、キャラクターの移動処理
            h_velocity = new Vector3(r, 0, 0);        // 上下のキー入力からZ軸方向の移動量を取得
                                                      // キャラクターのローカル空間での方向に変換
            h_velocity = transform.TransformDirection(h_velocity);
            //以下のvの閾値は、Mecanim側のトランジションと一緒に調整する
            if (r > 0.1)
            {
                h_velocity *= 2;       // 移動速度を掛ける
            }
            else if (r < -0.1)
            {
                h_velocity *= 2;  // 移動速度を掛ける
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

            if (jump_component.jump == true)
            {  
                rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
                anim.SetBool("Jump", true); 
                // スペースキーを入力したら
                   // Animatorにジャンプに切り替えるフラグを送る

                //アニメーションのステートがLocomotionの最中のみジャンプできる
                if (currentBaseState.nameHash == locoState)
                {
                    //ステート遷移中でなかったらジャンプできる
                    if (!anim.IsInTransition(0))
                    {
                       
                    }
                }
            }


            // 上下のキー入力でキャラクターを移動させる
            transform.localPosition += velocity * Time.fixedDeltaTime;
            transform.localPosition += h_velocity * Time.fixedDeltaTime;

            // 左右のキー入力でキャラクタをY軸で旋回させる
            transform.Rotate(0, h * rotateSpeed, 0);


            // 以下、Animatorの各ステート中での処理
            // Locomotion中
            // 現在のベースレイヤーがlocoStateの時
            if (currentBaseState.nameHash == locoState)
            {
                //カーブでコライダ調整をしている時は、念のためにリセットする
                if (useCurves)
                {
                    resetCollider();
                }
            }
            // JUMP中の処理
            // 現在のベースレイヤーがjumpStateの時
            else if (currentBaseState.nameHash == jumpState)
            {
                 // ジャンプ中のカメラに変更
                                                                        // ステートがトランジション中でない場合
                if (!anim.IsInTransition(0))
                {

                    // 以下、カーブ調整をする場合の処理
                    if (useCurves)
                    {
                        // 以下JUMP00アニメーションについているカーブJumpHeightとGravityControl
                        // JumpHeight:JUMP00でのジャンプの高さ（0〜1）
                        // GravityControl:1⇒ジャンプ中（重力無効）、0⇒重力有効
                        float jumpHeight = anim.GetFloat("JumpHeight");
                        float gravityControl = anim.GetFloat("GravityControl");
                        if (gravityControl > 0)
                            rb.useGravity = false;  //ジャンプ中の重力の影響を切る

                        // レイキャストをキャラクターのセンターから落とす
                        Ray ray = new Ray(transform.position + Vector3.up, -Vector3.up);
                        RaycastHit hitInfo = new RaycastHit();
                        // 高さが useCurvesHeight 以上ある時のみ、コライダーの高さと中心をJUMP00アニメーションについているカーブで調整する
                        if (Physics.Raycast(ray, out hitInfo))
                        {
                            if (hitInfo.distance > useCurvesHeight)
                            {
                                col.height = orgColHight - jumpHeight;          // 調整されたコライダーの高さ
                                float adjCenterY = orgVectColCenter.y + jumpHeight;
                                col.center = new Vector3(0, adjCenterY, 0); // 調整されたコライダーのセンター
                            }
                            else
                            {
                                // 閾値よりも低い時には初期値に戻す（念のため）					
                                resetCollider();
                            }
                        }
                    }
                    // Jump bool値をリセットする（ループしないようにする）				
                    anim.SetBool("Jump", false);
                }
            }
            // IDLE中の処理
            // 現在のベースレイヤーがidleStateの時
            else if (currentBaseState.nameHash == idleState)
            {
                //カーブでコライダ調整をしている時は、念のためにリセットする
                if (useCurves)
                {
                    resetCollider();
                }
                // スペースキーを入力したらRest状態になる
                if (jump_component.jump == true)
                {
                    

                }

            }
            // REST中の処理
            // 現在のベースレイヤーがrestStateの時
            else if (currentBaseState.nameHash == restState)
            {
                //cameraObject.SendMessage("setCameraPositionFrontView");		// カメラを正面に切り替える
                // ステートが遷移中でない場合、Rest bool値をリセットする（ループしないようにする）
                if (!anim.IsInTransition(0))
                {
                    anim.SetBool("Rest", false);
                }
            }

            if(have_handgun == 1){
                handGun_Panel.SetActive(true);
            }

            if (have_Uzi == 1)
            {
                Uzi_Panel.SetActive(true);
            }

            if (have_ShotGun == 1)
            {
                ShotGun_Panel.SetActive(true);
            }

            if (have_M4 == 1)
            {
               m4_Panel.SetActive(true);
            }

            if (have_M107 == 1)
            {
                m107_Panel.SetActive(true);
            }





        }//Update

    
        public void PlayerSave(){
            photonControll.GetComponent<SaveData>().Save();
        }


        // キャラクターのコライダーサイズのリセット関数
        void resetCollider()
        {
            // コンポーネントのHeight、Centerの初期値を戻す
            col.height = orgColHight;
            col.center = orgVectColCenter;
        }


        public void ForwardStart()
        {

            forwardstart = true;



        }

        public void ForwardStop()
        {
            forwardstart = false;
        }

        public void BackStart()
        {
            backstart = true;
        }

        public void BackStop()
        {
            backstart = false;
        }

        public void RightOn()
        {
            right = true;
        }

        public void RightOff()
        {
            right = false;
        }

        public void LeftOn()
        {
            left = true;
        }

        public void LeftOff()
        {
            left = false;
        }

        public void ADSOnAnim(){
            anim.SetBool("AssualtADS",true);
        }

        public void ADSOffAnim()
        {
            anim.SetBool("AssualtADS",false);
        }


        public void PistolFire()
        {
            anim.SetBool("pistolADS", true);
            Invoke("PistolFireOff", 3.0f);

        }

        public void ShotGunFire()
        {
            anim.SetBool("AssualtADS", true);
            Invoke("AssualtFireOff", 3.0f);

        }

        void PistolFireOff()
        {
            anim.SetBool("pistolADS", false);
        }

        void AssualtFireOff()
        {
            anim.SetBool("AssualtADS", false);
        }


        [PunRPC]
        public void OnPlayerDestroy()
        {
            
            DropItem();
            Destroy(this.gameObject);
        }

        [PunRPC]
        public void DropItem(){
            if (photonView.isMine)
            {


                drop_item_obj = PhotonNetwork.Instantiate(drop_item.name, this.transform.position, Quaternion.identity, 0);
                dethDropItem = drop_item_obj.GetComponent<DethDropItem>();
                dethDropItem.guns[0] = have_handgun;
                dethDropItem.guns[1] = have_Uzi;
                dethDropItem.guns[2] = have_ShotGun;
                dethDropItem.guns[3] = have_M4;
                dethDropItem.guns[4] = have_M107;

                dethDropItem.items[0] = smallbullet;
                dethDropItem.items[1] = middleBullet;
                dethDropItem.items[2] = bigBullet;
                dethDropItem.items[3] = shotGunBullet;
                dethDropItem.items[4] = have_aid;
            }
           
        }


       
        [PunRPC]
        public void GameStarter()
        {
            game_startControl = GameObject.Find("RestPlane/GameStartPanel").gameObject.GetComponent<GameStart>();
            game_startControl.game_start = true;
        }

        [PunRPC]
        public void GameFinish()
        {
            game_startControl = GameObject.Find("RestPlane/GameStartPanel").gameObject.GetComponent<GameStart>();
            game_startControl.play_time = 600;
            this.transform.position = GameObject.Find("RestPlane/RestReturn").transform.position;
        }

      

        [PunRPC]
        public void SetName(string p_name){
            player_text.text = p_name;
        }

        [PunRPC]
        public void SetLevel(int playerlevel)
        {
            player_Level = playerlevel;
            level_text.text = (playerlevel.ToString());
        }


        [PunRPC]
        public void SetStatus(){

            if(u_photonView.isMine){
                return;
            }

           
        }

        [PunRPC]
        public void ItemSpawnReturn(){
            
        }

        [PunRPC]
        public void HandGunOn(){
            if (!u_photonView)
            {
                return;
            }
            handGun_Obj.SetActive(true);
        }

        [PunRPC]
        public void ShotGunOn()
        {
            if (!u_photonView)
            {
                return;
            }
            shotGun_Obj.SetActive(true);
        }

        [PunRPC]
        public void UziOn()
        {
            if (!u_photonView)
            {
                return;
            }
            uzi_Obj.SetActive(true);
        }

        [PunRPC]
        public void M4On()
        {
            if (!u_photonView)
            {
                return;
            }
            m4_Obj.SetActive(true);
        }

        [PunRPC]
        public void M107On()
        {
            if (!u_photonView)
            {
                return;
            }
            m107_Obj.SetActive(true);
        }


        [PunRPC]
        public void AllGunOff()
        {
            if (!u_photonView)
            {
                return;
            }
            uzi_Obj.SetActive(false);
            shotGun_Obj.SetActive(false);
            handGun_Obj.SetActive(false);
            m4_Obj.SetActive(false);
            m107_Obj.SetActive(false);

            uzi_Obj_Panel.SetActive(false);
            shotGun_Obj_Panel.SetActive(false);
            handGun_Obj_Panel.SetActive(false);
            m4_Obj_Panel.SetActive(false);
            m107_Obj_Panel.SetActive(false);

            reload_Panel[0].SetActive(false);
            reload_Panel[1].SetActive(false);
            reload_Panel[2].SetActive(false);
            reload_Panel[3].SetActive(false);
           

        }


        [PunRPC]
        public void Aid(){
            wait_anim = true;
            anim.SetBool("medhic",true);
            Invoke("Aid_anim", 5.0f);
               

        }

        public void Aid_anim(){

            wait_anim = false;
                life += 10;
                have_aid--;
                anim.SetBool("medhic", false);

        }

        [PunRPC]
        public void GetAid(){
            have_aid++;
            exp_point += 10;
        }

        [PunRPC]
        public void LifeLightBall()
        {
            if(life < maxLife){
                maxLife++;
                life++;
                exp_point += 1;
            }

        }


        [PunRPC]
        public void StartSetUp(){
            shirld1.SetActive(false);
        }

        [PunRPC]
        public void Shirld()
        {
            protect = 1;
            shirld1.SetActive(true);
        }

       
        [PunRPC]
        public void HandGunDamage()
        {
            BloodOn();
            life -= 20 / protect_calc;
            Invoke("BloodOff", 0.5f);

        }

        [PunRPC]
        public void UziDamage()
        {
            BloodOn();
            float uzi_damege = 16 + Random.Range(1,4);
            life -= uzi_damege / protect_calc;
            Invoke("BloodOff", 0.5f);
        }

        [PunRPC]
        public void M4Damage()
        {
            BloodOn();
            float m4_damege = 23 + Random.Range(2, 4);
            life -= m4_damege / protect_calc;
            Invoke("BloodOff", 0.5f);
        }

        [PunRPC]
        public void M107Damage()
        {
            BloodOn();
            float m107_damege = 75 + Random.Range(10, 15);
            life -= m107_damege / protect_calc;
            Invoke("BloodOff", 0.5f);
        }

        [PunRPC]
        public void ShotGunDamage()
        {
            BloodOn();
            float shotgun_damege = 13 + Random.Range(2, 4);
            life -= shotgun_damege / protect_calc;
            Invoke("BloodOff", 0.5f);
        }

        [PunRPC]
        public void Head_HandGunDamage()
        {
            BloodOn();
            life -= 20*head_rate / protect_calc;
            Invoke("BloodOff", 0.5f);

        }

        [PunRPC]
        public void Head_UziDamage()
        {
            BloodOn();
            float uzi_damege = 16*head_rate + Random.Range(1, 4);
            life -= uzi_damege / protect_calc;
            Invoke("BloodOff", 0.5f);
        }

        [PunRPC]
        public void Head_M4Damage()
        {
            BloodOn();
            float m4_damege = 23*head_rate + Random.Range(2, 4);
            life -= m4_damege / protect_calc;
            Invoke("BloodOff", 0.5f);
        }

        [PunRPC]
        public void Head_M107Damage()
        {
            BloodOn();
            float m107_damege = 100*head_rate + Random.Range(10, 15);
            life -= m107_damege / protect_calc;
            Invoke("BloodOff", 0.5f);
        }


        [PunRPC]
        public void SmallBulletGet()
        {
            if(!u_photonView){
                return;
            }
            smallbullet += 15;
        }

        [PunRPC]
        public void MiddleBulletGet()
        {
            if (!u_photonView)
            {
                return;
            }
           middleBullet += 10;
        }

        [PunRPC]
        public void ShotGunBulletGet()
        {
            if (!u_photonView)
            {
                return;
            }
            shotGunBullet += 5;
        }

        [PunRPC]
        public void BigBulletGet()
        {
            if (!u_photonView)
            {
                return;
            }
            bigBullet += 5;
        }

        [PunRPC]
        public void KillCount(){
            GameObject.Find("PhotonController").GetComponent<PhotonControll>().kill++;
            exp_point += 100;
            }

        [PunRPC]
        public void BloodOn(){
            blood.SetActive(true);
        }

        [PunRPC]
        public void BloodOff()
        {
            blood.SetActive(false);
        }

        [PunRPC]
        public void Handgun_Audio(){
            gun_audio.PlayOneShot(handgun_clip);
        }

        [PunRPC]
        public void Uzi_Audio()
        {
            gun_audio.PlayOneShot(uzi_clip);
        }

        [PunRPC]
        public void ShotGun_Audio()
        {
            gun_audio.PlayOneShot(shotgun_clip);
        }

        [PunRPC]
        public void M4_Audio()
        {
            gun_audio.PlayOneShot(m4_clip);
        }

        [PunRPC]
        public void M107_Audio()
        {
            gun_audio.PlayOneShot(m107_clip);
        }

        [PunRPC]
        public void Cube_Get()
        {
            gun_audio.PlayOneShot(cube_get);
        }


    }
}