using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterObjectStatus : MonoBehaviour {
    int _objLife = 5;
    float _lifeTime = 100;
    PhotonView photonView;
	// Use this for initialization
	void Start () {
        photonView = GetComponent<PhotonView>();
	}
	
	// Update is called once per frame
	void Update () {
        if(PhotonNetwork.isMasterClient){
            _lifeTime -= Time.deltaTime;
            if(_lifeTime <= 0){
                photonView.RPC("OnDestroy", PhotonTargets.AllBufferedViaServer);
            }
        }

        if(_objLife <= 0 && PhotonNetwork.isMasterClient){
            photonView.RPC("OnDestroy", PhotonTargets.AllBufferedViaServer);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "BottleItem" && PhotonNetwork.isMasterClient){
            collision.gameObject.GetPhotonView().RPC("OnDestroy", PhotonTargets.All);
            PhotonNetwork.Instantiate("WaterBottleItem", this.transform.position + new Vector3(0, 3, 0), Quaternion.identity, 0);
            photonView.RPC("RemoveWater", PhotonTargets.AllBufferedViaServer);
        }
    }


    [PunRPC]
    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }

    [PunRPC]
    public void RemoveWater()
    {
        _objLife--;
    }


}
