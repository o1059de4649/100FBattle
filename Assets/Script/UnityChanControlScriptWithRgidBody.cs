//
// Mecanimのアニメーションデータが、原点で移動しない場合の Rigidbody付きコントローラ
// サンプル
// 2014/03/13 N.Kobyasahi
//
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{

    // 必要なコンポーネントの列記
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]

    public class UnityChanControlScriptWithRgidBody : MonoBehaviour
    {
        public GameObject drop_item;
        GameObject drop_item_obj;


        public GameObject player_camera;
        public GameObject p_camera_Stork;

        public GameObject duo_Panel;
        public Canvas canvas;
        public float lifePlus = 0;
        public float maxLife = 100;
        public float life = 100;
       
        public float exp_point = 0;
        public float Max_exp_point = 100;
        public int player_Level;
        public string player_Name = "DefaultName";
        public Text player_text;

        public float protectPlus = 0;
        public int protect = 0;
        public float protect_calc = 1;


        int t;

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
       



       

       

        public JumpButton jump_component;
       

        public GameObject blood;
        public bool wait_anim = false;
        public GameObject head;
       
       
      
        public AudioListener u_audioListener;


        public Text level_text;
        public CameraRotate cameraRotate;

        // アニメーター各ステートへの参照
        static int idleState = Animator.StringToHash("Base Layer.Idle");
        static int locoState = Animator.StringToHash("Base Layer.Locomotion");
        static int jumpState = Animator.StringToHash("Base Layer.Jump");
        static int restState = Animator.StringToHash("Base Layer.Rest");



        public float _boneEssence = 0,_stringEssence = 0,_fireEssence = 0,_CrystalEssence,_iceEssence = 0;
      
        public float _bloodEssence,_wallSpace,_maxEssencePlus,_maxEssence = 0,_equip_sword_power;


        public float _magicPower = 1,_SwordPower = 1,_MoveSpeedRL = 2,_money,_magicPowerPlus = 0, _attackPower = 0,_crystalTime,_crystalBoolMax;

        public bool _isCrystal = false, _isStringed = false,isLockOn = false;


        public GameObject _crystalParticle,enemyObject;
        public GameObject[] enemyObjects;

        public List<int> itemList = new List<int>();

        public GameObject crystalsliderObject;
        Slider crystalSlider;

        public BoxCollider[] boxCollider;

        AudioSource audioSource;
        public AudioClip[] audio_clip;

        bool isStrong = false;
        public Text playerDataText;
        public int _swordType,_shirldType,shirldRare;
        public float _shirdPower;
        public GameObject[] shirldObject;
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            duo_Panel = GameObject.Find("DualTouchControls");
            duo_Panel.GetComponent<Canvas>().enabled = true;
            SetUp();

          


            u_photonView = GetComponent<PhotonView>();
         


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

            crystalSlider = crystalsliderObject.GetComponent<Slider>();

           

        }

        public void SetUp(){
            

            exp_point = PlayerPrefs.GetFloat("Exp", 0);
            player_Level = PlayerPrefs.GetInt("Level", 0);
            _attackPower = PlayerPrefs.GetFloat("PowerPlus", 0);
            _SwordPower = _attackPower + player_Level * 0.5f;
            lifePlus = PlayerPrefs.GetFloat("LifePlus", 0);
            _money = PlayerPrefs.GetFloat("Money", 0);
            _magicPowerPlus = PlayerPrefs.GetFloat("MagicPowerPlus", 0);
            _magicPower = _magicPowerPlus + player_Level * 0.2f;

            _boneEssence = PlayerPrefs.GetFloat("BoneEssence", 0);
            _stringEssence = PlayerPrefs.GetFloat("StringEssence", 0);
            _fireEssence = PlayerPrefs.GetFloat("FireEssence", 0);
            _CrystalEssence = PlayerPrefs.GetFloat("CrystalEssence", 0);
            _iceEssence = PlayerPrefs.GetFloat("IceEssence", 0);
            _maxEssencePlus = PlayerPrefs.GetFloat("EssencePlus", 0);
            _maxEssence = _maxEssencePlus + 30;
           
            _bloodEssence = PlayerPrefs.GetFloat("Blood", 0);

            _wallSpace = PlayerPrefs.GetFloat("WallSpace", 0);

           

            maxLife = 100 + lifePlus + player_Level;
            life = maxLife;
            Max_exp_point = player_Level * 50 + 100;

            _crystalBoolMax = 30 + _magicPower;

            isStrong = PlayerPrefs.HasKey("Sword");//剣の情報取得
            _swordType = PlayerPrefs.GetInt("SwordType",0);

            _shirdPower = PlayerPrefs.GetFloat("Shirld",0);
            _shirldType = PlayerPrefs.GetInt("ShirldType", 0);
            shirldRare = PlayerPrefs.GetInt("ShirldRare", 0);


            for (int t = 0; t < boxCollider.Length; t++)
            {//剣を全て非表示
                boxCollider[t].gameObject.SetActive(false);
            }

            for (int i = 0;i < boxCollider.Length ;i++){
                if(_swordType == i){
                    boxCollider[i].gameObject.SetActive(true);//Typeのソード有効
                    boxCollider[i].gameObject.GetComponent<KukuriPower>()._swordPower = PlayerPrefs.GetFloat("Sword", 0);
                    boxCollider[i].gameObject.GetComponent<KukuriPower>().SetUpColor();
                    _equip_sword_power = boxCollider[i].gameObject.GetComponent<KukuriPower>()._swordPower;
                }
            }

            if(_swordType == 0){
                boxCollider[0].gameObject.GetComponent<KukuriPower>()._swordPower = 12;
            }
        

            for (int p = 0; p < shirldObject.Length; p++)
            {//盾を全て非表示
                shirldObject[p].gameObject.SetActive(false);
            }

            for (int s = 0; s < shirldObject.Length; s++)
            {
                if (_shirldType == s)
                {
                    shirldObject[s].gameObject.SetActive(true);//Typeの盾有効

                    if(_shirldType >= 1){//Type0の時の初期化エラー回避
                        ShirldSetUp(shirldObject[s]);
                    }

                }
            }

            //シールドがない
            if(_shirldType == 0){
                for (int p = 0; p < shirldObject.Length; p++)
                {//盾を全て非表示
                    shirldObject[p].gameObject.SetActive(false);
                }
            }



        }

        public void Save(){
            PlayerPrefs.SetFloat("Exp", exp_point);
            PlayerPrefs.SetInt("Level", player_Level);
            PlayerPrefs.SetString("playername", player_Name);

            PlayerPrefs.SetFloat("LifePlus", lifePlus);
            PlayerPrefs.SetFloat("ProtectPlus", protect);
            PlayerPrefs.SetFloat("PowerPlus", _attackPower);

            PlayerPrefs.SetFloat("MagicPowerPlus", _magicPowerPlus);
            PlayerPrefs.SetFloat("Money", _money);

            int _maxFloorLevel = GameObject.Find("FloorControl").GetComponent<EnemyCount>()._MaxFloorLevel;
            PlayerPrefs.SetInt("FloorLevel", _maxFloorLevel);

            PlayerPrefs.SetFloat("BoneEssence", _boneEssence);
            PlayerPrefs.SetFloat("StringEssence", _stringEssence);
            PlayerPrefs.SetFloat("FireEssence", _fireEssence);
            PlayerPrefs.SetFloat("IceEssence", _iceEssence);
            PlayerPrefs.SetFloat("CrystalEssence", _CrystalEssence);

            PlayerPrefs.SetFloat("EssencePlus", _maxEssencePlus);
            PlayerPrefs.SetFloat("Blood", _bloodEssence);

            PlayerPrefs.SetFloat("WallSpace", _wallSpace);




            PlayerPrefs.Save();
        }
        // 以下、メイン処理.リジッドボディと絡めるので、FixedUpdate内で処理を行う.
        void FixedUpdate()
        {

            playerDataText.text = ("最大HP" + maxLife.ToString() + "\n" 
                                   + "肉体物理攻撃力" + _SwordPower.ToString() + "\n" 
                                   + "装備攻撃力" + _equip_sword_power.ToString()+ "\n" 
                                   + "防御力" + _shirdPower.ToString() + "\n" 
                                   + "魔法攻撃力" + _magicPower.ToString() + "\n" 
                                   + "最大EP" + _maxEssence.ToString() + "\n" 
                                   + "お金" + _money.ToString());

            //クリスタル処理
            if(_crystalTime > 0){
                crystalsliderObject.SetActive(true);
                _isCrystal = true;
                _crystalTime -= Time.deltaTime;
                crystalSlider.maxValue = _crystalBoolMax;
                crystalSlider.value = _crystalTime;

            }else{
                _isCrystal = false;
                crystalsliderObject.SetActive(false);

            }

            if(_crystalTime > _crystalBoolMax){
                _crystalTime = _crystalBoolMax;
            }

            if (this.transform.rotation.eulerAngles.x > 3 || this.transform.rotation.eulerAngles.x < -3)
            {
                Quaternion player_qua = Quaternion.Euler(0, this.transform.rotation.eulerAngles.y, 0);
                this.transform.rotation = player_qua;

            }

           

            //ロックオン処理
            if(isLockOn){

                for (int i = 0; enemyObjects.Length > i; i++)
                {
                    if (enemyObjects[i] != null && enemyObjects[i].GetComponent<SkeletonStatus>()._life > 0)
                    {
                        

                            enemyObject = enemyObjects[i];

                    }
                }

                if (!enemyObject)
                {
                    isLockOn = false;
                    return;
                }

                /*
                if(enemyObject.name == "FlyMachine"){
                    isLockOn = false;
                    return;
                }
*/







                /*
                Vector3 target = enemyObject.transform.position;
                target.y = this.transform.position.y;
                this.transform.LookAt(target);
*/

                Vector3 targetDir = enemyObject.transform.position - transform.position;
                float step = 2 * Time.deltaTime;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
                this.transform.localRotation = Quaternion.LookRotation(newDir,Vector3.up);


               
                //this.transform.LookAt(enemyObject.transform);
               
            }
            /*if (!u_photonView.isMine)
            {
                return;
            }*/




          
           
            //移動スティック処理
            r = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            v = CrossPlatformInputManager.GetAxisRaw("Vertical");

          //エッセンス管理
            if(_maxEssence < _boneEssence){
                _boneEssence = _maxEssence;
            }

            if (_maxEssence < _stringEssence)
            {
                _stringEssence = _maxEssence;
            }

            if (_maxEssence < _fireEssence)
            {
                _fireEssence = _maxEssence;
            }

            if (_maxEssence < _iceEssence)
            {
                _iceEssence = _maxEssence;
            }

            if (_maxEssence < _CrystalEssence)
            {
                _CrystalEssence = _maxEssence;
            }
            //エッセンス管理終了

            //レベル管理
            if(Max_exp_point <= exp_point){
                exp_point -= Max_exp_point;
                Max_exp_point += player_Level * 50;
                player_Level++;
            }

            //ライフ管理
            if(life > maxLife){
                life = maxLife;
            }
       

            if (life <= 0)
            {
                SceneManager.LoadScene("Main");
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

           




        }//Update

    
     


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



        public void EnemyLockOn()
        {
           
           
            if(isLockOn){
                isLockOn = false;
                return;
            }else{
                isLockOn = true;
                enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
            }
        }
       

        public void OnWormString(){
            forwardSpeed *= 0.5f;
            backwardSpeed *= 0.5f;
            _MoveSpeedRL *= 0.5f;
            _isStringed = true;
            Invoke("OffWormString", 2.0f);
        }

        public void OffWormString(){
            forwardSpeed = 7;
            backwardSpeed = 2;
            _MoveSpeedRL = 2;
            _isStringed = false;

        }

        public void OnCrystal(){


            _crystalTime += Time.deltaTime * _magicPowerPlus * 0.5f;
            life += Time.deltaTime * _magicPowerPlus * 0.1f;
        }

        public void OffCrystal(){
            _isCrystal = false;
           
        }

        public void GoMyRoom(){
            SceneManager.LoadScene("MyRoom");
        }

        public void AttackAudio(){

            audioSource.PlayOneShot(audio_clip[0]);
        }

        public void GetEssence(){
            audioSource.PlayOneShot(audio_clip[1]);
        }

        public void WalkingAudio()
        {
            int i = Random.Range(3, 6);
            audioSource.PlayOneShot(audio_clip[i]);
        }

        public void RunningAudio()
        {
            int i = Random.Range(3, 6);
            audioSource.PlayOneShot(audio_clip[i]);
        }

        public void AudioOff(){
            audioSource.Stop();
        }


        public void AttackSwordOn(){


            boxCollider[_swordType].enabled = true;

        }

        public void AttackSwordOff()
        {
            boxCollider[_swordType].enabled = false;

        }

        public void DeleteSaveData(){
            PlayerPrefs.DeleteAll();
        }

        public void ShirldSetUp(GameObject shirld){

            if (shirldRare == 1)
            {
                shirld.GetComponentInChildren<ParticleSystem>().startColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

            }

            if (shirldRare == 2)
            {
                shirld.GetComponentInChildren<ParticleSystem>().startColor = new Color(0.0f, 0.0f, 1.0f, 1.0f);
            }

            if (shirldRare == 3)
            {
                shirld.GetComponentInChildren<ParticleSystem>().startColor = new Color(0.0f, 1.0f, 0.0f, 1.0f);


            }

            if (shirldRare == 4)
            {
                shirld.GetComponentInChildren<ParticleSystem>().startColor = new Color(1.0f, 1.0f, 0.0f, 1.0f);
            }

            if (shirldRare == 5)
            {
                shirld.GetComponentInChildren<ParticleSystem>().startColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
            if (shirldRare == 6)
            {
                shirld.GetComponentInChildren<ParticleSystem>().startColor = new Color(1.0f, 0.0f, 1.0f, 1.0f);
            } 
           
        }

    }
}