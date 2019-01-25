using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableBattleModeObject : MonoBehaviour {
    public bool isFire = false;
    public int _nuts,_bottle;
    public float _fire_time = 0;
    PhotonView photonView;

    public GameObject particle_fire, canvas, player;
    public Canvas create_canvas;
    public float _waitTime = 0;

    public Text item_text,nuts_text;
    // Use this for initialization

    public int _objLife = 15;
    void Start()
    {
        photonView = this.gameObject.GetPhotonView();
        this.gameObject.name = this.gameObject.name.Replace("(Clone)", "");
    }

    // Update is called once per frame
    void Update()
    {

        //破壊処理
        if (_objLife <= 0 && PhotonNetwork.isMasterClient)
        {
            photonView.RPC("OnDestroy", PhotonTargets.AllBufferedViaServer);
        }

        //テキスト更新
        item_text.text = (
                        "作業台"
                         );

        if(player){
            nuts_text.text = ("作業台に入っているナッツ:" +_nuts.ToString() + "個" +"\n" 
                              +"作業台に入っているボトル:" + _bottle.ToString() + "個");
        }

        //マスター処理
        if (!PhotonNetwork.isMasterClient)
        {
            return;
        }







    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "NutsItem")
        {
            _nuts++;
            collision.gameObject.GetPhotonView().RPC("OnDestroy", PhotonTargets.All);
        }

        if (collision.gameObject.name == "BottleItem")
        {
            _bottle++;
            collision.gameObject.GetPhotonView().RPC("OnDestroy", PhotonTargets.All);
        }

       
    }

    public void OnCollisionExit(Collision collision)
    {

    }

    public void OnTriggerStay(Collider col)
    {
        if (player)
        {
            canvas.transform.LookAt(player.transform);
        }
        else
        {
            if (col.gameObject.name == "MyPlayer")
            {
                player = col.gameObject;
            }

        }




    }

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "MyPlayer"){
            create_canvas.enabled = true;
        }
    }

    public void OnTriggerExit(Collider collider_exit)
    {
        if (collider_exit.gameObject.name == "MyPlayer")
        {
            create_canvas.enabled = false;
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(_nuts);
            stream.SendNext(_bottle);
            stream.SendNext(_fire_time);
            stream.SendNext(_objLife);

        }
        else
        {
            _nuts = (int)stream.ReceiveNext();
            _bottle = (int)stream.ReceiveNext();
            _fire_time = (float)stream.ReceiveNext();
            _objLife = (int)stream.ReceiveNext();
        }

    }

   
    public void ShowOffCanvas(){
        create_canvas.enabled = false;
    }

   

  
   
    public void MakeNutsBottle()
    {
        if(_bottle > 0 && _nuts > 2){
            _bottle--;
            _nuts -= 3;
            PhotonNetwork.Instantiate("NutsBottleItem", player.transform.position + new Vector3(0, 2, 0), Quaternion.identity, 0);
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
