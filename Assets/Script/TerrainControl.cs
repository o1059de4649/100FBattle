using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TerrainControl : MonoBehaviour {
    PhotonView photonView;
	// Use this for initialization
	void Start () {
        photonView = GetComponent<PhotonView>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "House"){
            photonView.RPC("OnDestroy", PhotonTargets.All);
        }
    }

    [PunRPC]
    private void OnDestroy()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
