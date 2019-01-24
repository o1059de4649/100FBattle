using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectStatus : Photon.MonoBehaviour {
    public float _objLife = 5,_preLife;
    public float _maxObjLife = 5;
    PhotonView obj_photonView;
    int random;
    public GameObject[] itemobj;

    public GameObject canvasObj,sliderObj,spawnObj;
    Slider slider;
    public GameObject myplayer_camera;

    float _lifeTime,random_scale;

	// Use this for initialization
	void Start () {
        this.gameObject.GetPhotonView().TransferOwnership(0);

        obj_photonView = GetComponent<PhotonView>();
       
        slider = sliderObj.GetComponent<Slider>();
        random_scale = Random.Range(0, 0.3f);
        this.transform.localScale += new Vector3(random_scale,random_scale,random_scale);

        _preLife = _objLife;
	}
	
	// Update is called once per frame
	void Update () {

        _lifeTime += Time.deltaTime;
        if(_lifeTime >= 100){
            _objLife = 0;
        }

        random = Random.Range(0,itemobj.Length);
        if(_objLife <= 0){
            
            obj_photonView.RPC("OnDestroy", PhotonTargets.AllBufferedViaServer);
            

            //photonView.RPC("OnDestroy", PhotonTargets.All);
        }

        if(!myplayer_camera){
            myplayer_camera = GameObject.Find("MyPlayer").GetComponentInChildren<Camera>().transform.gameObject;
        }

        if(!myplayer_camera){
            return;
        }

        if(_preLife != _objLife){
            if (_objLife > 0)
            {


                if (PhotonNetwork.isMasterClient)
                {
                    SpawnItem();
                }
            }
        }

        canvasObj.transform.LookAt(myplayer_camera.transform);
        slider.value = _objLife / _maxObjLife;

        _preLife = _objLife;
	}

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.isWriting)
        {
           
        }
        else
        {

        }
    }


    public void SpawnItem()
    {
      
        
            PhotonNetwork.Instantiate(itemobj[random].name, spawnObj.transform.position, Quaternion.identity, 0);
       
    }

    [PunRPC]
    public void Damage(){
        _objLife--;
    }


    [PunRPC]
    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }

}
