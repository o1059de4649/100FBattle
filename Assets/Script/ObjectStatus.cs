using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectStatus : MonoBehaviour {
    public float _objLife = 5;
    public float _maxObjLife = 5;
    PhotonView photonView;
    int random;
    public GameObject[] itemobj;

    public GameObject canvasObj,sliderObj,spawnObj;
    Slider slider;
    GameObject myplayer_camera;
	// Use this for initialization
	void Start () {
        photonView = GetComponent<PhotonView>();
       
        slider = sliderObj.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        random = Random.Range(0,itemobj.Length);
        if(_objLife <= 0){
            photonView.RPC("OnDestroy", PhotonTargets.All);
        }

        if(!myplayer_camera){
            myplayer_camera = GameObject.Find("MyPlayer").GetComponentInChildren<Camera>().transform.gameObject;
        }

        canvasObj.transform.LookAt(myplayer_camera.transform);
        slider.value = _objLife / _maxObjLife;
	}

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.isWriting)
        {
            stream.SendNext(_objLife);
        }
        else
        {
            _objLife = (float)stream.ReceiveNext();
        }
    }

    public void SpawnItem(){
        PhotonNetwork.Instantiate(itemobj[random].name, spawnObj.transform.position, Quaternion.identity, 0);
    }

    [PunRPC]
    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
