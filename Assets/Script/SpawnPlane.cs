using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlane : MonoBehaviour {
    public int _xPlane, _yPlane;

    public GameObject planeobj;
    public GameObject[] spawnerobj;
    public GameObject player;
    public bool isSpawned= false,isNewPlane = true;

    public float _tIme;
    public PhotonView photonView;

    SpawnPlane spawnPlane;
	// Use this for initialization
	void Start () {
        photonView = this.gameObject.GetPhotonView();
        this.gameObject.name = this.gameObject.name.Replace("(Clone)", "");
       
	}
	
	// Update is called once per frame
	void Update () {
        if(player == null){
            player = GameObject.Find("PhotonController").GetComponent<PhotonController>().myplayer;
        }

        if(photonView == null){
            photonView = this.gameObject.GetPhotonView();
        }

        _tIme += Time.deltaTime;

        if(_tIme > 0.1f){
            isNewPlane = false;
        }

       
	}

    //PlaneSpawn
    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player" && col.gameObject.name == "MyPlayer"){
            if (!isSpawned)
            {
                if(isNewPlane){
                    photonView.RPC("OnDestroy", PhotonTargets.All);
                    return;
                }

                isSpawned = true;
                SpawnPlanes();

            }
        }

        if(col.gameObject.tag == "Plane"&& isNewPlane){
            photonView.RPC("OnDestroy", PhotonTargets.All);
        } 
       
    }

    public void SpawnPlanes()
    {
        for (int i = 0; i < spawnerobj.Length; i++)
        {
            GameObject plane = PhotonNetwork.Instantiate(planeobj.name, spawnerobj[i].transform.position, Quaternion.identity, 0);

            plane.GetComponent<SpawnPlane>().isSpawned = false;
            plane.GetComponent<SpawnPlane>().isNewPlane= true;
            plane.GetComponent<SpawnPlane>()._tIme = 0;
           // plane.GetComponent<SpawnPlane>().planeobj = this.gameObject;
        }



    }

   
    public void IsSpawned(){
       
    }


    //PlaneDestroy
    public void OnCollisionStay(Collision col)
    {
       
    }

    [PunRPC]
    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.isWriting)
        {
            stream.SendNext(isSpawned);
            stream.SendNext(_tIme);
        }else{
            isSpawned = (bool)stream.ReceiveNext();
            _tIme = (float)stream.ReceiveNext();

        }
    }

}
