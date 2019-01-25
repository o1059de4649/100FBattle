using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FenceStatus : MonoBehaviour {
    
	int _objLife = 50;
    PhotonView photonView;
    public Text item_lifeText;
    GameObject player;
	void Start () {
        photonView = GetComponent<PhotonView>();
     
	}
	
	// Update is called once per frame
	void Update () {

        item_lifeText.text = "耐久値:" + _objLife.ToString();

        if(player){
            item_lifeText.transform.parent.LookAt(player.transform);
        }else{
            player = GameObject.Find("MyPlayer");
        }

        if(PhotonNetwork.isMasterClient && _objLife <= 0){
            photonView.RPC("OnDestroy", PhotonTargets.All);
        }
	}


    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            
            stream.SendNext(_objLife);

        }
        else
        {
           
            _objLife = (int)stream.ReceiveNext();
        }

    }

	[PunRPC]
    public void DamageObject()
    {
        if (PhotonNetwork.isMasterClient)
        {
            _objLife--;
        }

    }

    [PunRPC]
    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
