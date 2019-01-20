using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonController : MonoBehaviour {
    public GameObject player;
    public GameObject myplayer;

    void Start(){
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    void OnJoinedLobby(){
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed(){
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom(){
        myplayer = PhotonNetwork.Instantiate(
            player.name,
            new Vector3(0f, 2f, 0f),
            Quaternion.identity, 
            0
         );

        GameObject.Find("StartPlane").GetComponent<SpawnPlane>().isSpawned = false;
       // myplayer.GetComponentInChildren<Camera>().enabled = true;

    }
}
