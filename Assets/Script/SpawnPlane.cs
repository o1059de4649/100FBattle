using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlane :MonoBehaviour {
    public int _xPlane, _yPlane;

    public GameObject planeobj;
    public GameObject[] spawnerobj;
    public GameObject[] spawn_Object;
    public GameObject[] spawn_monster;
    public GameObject[] spawnEnemy;

    public GameObject player;
    public GameObject[] photon_spawnedObject;
    public bool isSpawned= false,isNewPlane = true;

    public float _tIme = 0;
    PhotonView plane_photonView;

    SpawnPlane spawnPlane;

    int random_some,random_kind,random_some_monster,random_kind_monster;

    public bool isSpawned_Object = false;
    float _lifetime;
    DayControl dayControl;
    public GameObject col_Plane;
	// Use this for initialization
	void Start () {
        dayControl = GameObject.Find("Sun").GetComponent<DayControl>();
       
        plane_photonView = this.gameObject.GetComponent<PhotonView>();
        this.gameObject.name = this.gameObject.name.Replace("(Clone)", "");

        if(this.gameObject.name == "OldPlane"){
            return;
        }
        Invoke("afterStart", 0.2f);

	}

    void afterStart(){
        if (this.gameObject.name != "StartPlane")
        {

            // plane_photonView.RPC("SpawnObject", PhotonTargets.AllBuffered);
            SpawnObject();
        }
    }
	// Update is called once per frame
	void Update () {

        _lifetime += Time.deltaTime;
        if(_lifetime >= 100){
            isSpawned_Object = false;
           
            SpawnObject();
           // plane_photonView.RPC("SpawnObject", PhotonTargets.AllBuffered);
            _lifetime = 0;
        }

        if(player == null){
            player = GameObject.Find("PhotonController").GetComponent<PhotonController>().myplayer;
        }





        _tIme += Time.deltaTime;

        if(_tIme > 0.1f){
            isNewPlane = false;

            if(this.gameObject.name =="StartPlane"){
                return;
            }
            SetUpPlane();
        }

       
	}

    //PlaneSpawn
    public void OnTriggerEnter(Collider col)
    {
        if(!PhotonNetwork.isMasterClient){
            return;
        }

     

        if(col.gameObject.tag == "Player" && col.gameObject.name == "MyPlayer"){



            if (!isSpawned)
            {
                isSpawned = true;

                //plane_photonView.RPC("SpawnPlanes", PhotonTargets.AllBuffered);
                SpawnPlanes();

                if(this.gameObject.name == "BattlePlane"){
                    col_Plane = col.gameObject;

               
                    plane_photonView.RPC("OnDestroy", PhotonTargets.MasterClient);
                    return;
                }

               

            }
        }

        if(col.gameObject.name == "BattlePlane"){
            Debug.Log("Enter");
            col_Plane = col.gameObject;


            plane_photonView.RPC("OnDestroy", PhotonTargets.MasterClient);
        } 


       
    }

   



   
    public void SpawnPlanes()
    {
        for (int i = 0; i < spawnerobj.Length; i++)
        {
          //  GameObject plane = Instantiate((GameObject)Resources.Load("BattlePlane"), spawnerobj[i].transform.position, Quaternion.identity);
            GameObject plane = PhotonNetwork.Instantiate(Resources.Load("BattlePlane").name, spawnerobj[i].transform.position, Quaternion.identity,0) as GameObject;
            //plane.GetComponent<PhotonView>().viewID = i + plane_photonView.viewID + 1;

            plane.GetComponent<SpawnPlane>().isSpawned = false;
            plane.GetComponent<SpawnPlane>().isNewPlane= true;

            plane.GetComponent<SpawnPlane>()._tIme = 0;
            plane.name = "BattlePlane";
           // plane.GetComponent<SpawnPlane>().planeobj = this.gameObject;
        }



    }


    [PunRPC]
    public void SetUpPlane()
    {
        this.gameObject.name = "OldPlane";
    }



    public void SpawnObject()
    {

        if (!PhotonNetwork.isMasterClient || this.gameObject.name == "StartPlane")
        {
            return;
        }
       

        //オブジェクトのランダム処理
        random_some = Random.Range(1, 3);
        random_kind = Random.Range(0, spawn_Object.Length);

        //モンスターのランダム処理
        random_some_monster = Random.Range(-1, 2);
        random_kind_monster = Random.Range(0, dayControl._Day_date);

        //配列管理エラー回避
        if(spawn_monster.Length < dayControl._Day_date ){
            random_kind_monster = spawn_monster.Length - 1;
        }

        if (isSpawned_Object)
        {
            return;
        }

        //オブジェクト生成
        for (int i = 0; i < random_some; i++)
        {
            PhotonNetwork.Instantiate(spawn_Object[random_kind].name, this.transform.position + new Vector3(Random.Range(-10, 10), 0f, Random.Range(-10, 10)), Quaternion.EulerAngles(new Vector3(0, Random.Range(-90, 90),0)),0);
            random_kind = Random.Range(0, spawn_Object.Length);
        }

        //モンスター生成
        for (int p = 0; p < random_some_monster; p++)
        {
            Debug.Log(random_kind_monster);
            PhotonNetwork.Instantiate(spawn_monster[random_kind_monster].name, this.transform.position + new Vector3(Random.Range(-10, 10), 0f, Random.Range(-10, 10)), Quaternion.EulerAngles(new Vector3(0, Random.Range(-90, 90), 0)), 0);
           
        }

        isSpawned_Object = true;


    }

   
  


    //PlaneDestroy
    public void OnCollisionStay(Collision col)
    {
       
    }

    [PunRPC]
    public void OnDestroy()
    {
        /* for (int i;i < photon_spawnedObject.Length;i++){
             Destroy(photon_spawnedObject[i]);
         }
        */
        if(!PhotonNetwork.isMasterClient){
            return;
        }
       
        Destroy(col_Plane.gameObject);

    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.isWriting)
        {
            
          
            stream.SendNext(isSpawned);
            stream.SendNext(_tIme);
            stream.SendNext(isSpawned_Object);
            stream.SendNext(_lifetime);
         
        }else{
            isSpawned = (bool)stream.ReceiveNext();
            _tIme = (float)stream.ReceiveNext();
            isSpawned_Object = (bool)stream.ReceiveNext();
            _lifetime = (float)stream.ReceiveNext();

        }
    }

}
