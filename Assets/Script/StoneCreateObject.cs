using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneCreateObject : MonoBehaviour {
    public bool isFire = false;

        public int _wood, _glass;
    public float _fire_time = 0;
    PhotonView photonView;

    public GameObject particle_fire, canvas, player;
    public float _waitTime = 0;

    public Text item_text;
    // Use this for initialization

    public int _objLife = 450;
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
            photonView.RPC("OnDestroy", PhotonTargets.All);
        }

        //テキスト更新
        item_text.text = (
                          "木材:" + _wood.ToString() + "\n"
                         + "ガラス:" + _glass.ToString() + "\n"
                          + "燃焼時間" + Mathf.Floor(_fire_time).ToString()
                         );

        //マスター処理
        if (!PhotonNetwork.isMasterClient)
        {
            return;
        }

       
        if(_glass > 2 && _wood > 2 && !isFire){
            _glass -= 3;
            _wood -= 3 ;
            _fire_time += 15;
            photonView.RPC("FireOn", PhotonTargets.All);
        }

        if(isFire){
            _fire_time -= Time.deltaTime;

            if(_fire_time <= 0){
                PhotonNetwork.Instantiate("BottleItem", this.transform.localPosition + new Vector3(0, 2, 2), Quaternion.identity, 0);
                photonView.RPC("FireOff", PhotonTargets.All);
                isFire = false;
            }
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "WoodItem")
        {
            _wood++;
            collision.gameObject.GetPhotonView().RPC("OnDestroy", PhotonTargets.All);
        }

        if (collision.gameObject.name == "GlassItem")
        {
            _glass++;
            collision.gameObject.GetPhotonView().RPC("OnDestroy", PhotonTargets.All);
        }
       
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

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(_wood);
            stream.SendNext(_glass);
            stream.SendNext(_fire_time);
            stream.SendNext(_objLife);

        }
        else
        {
            _wood = (int)stream.ReceiveNext();
            _glass = (int)stream.ReceiveNext();
            _fire_time = (float)stream.ReceiveNext();
            _objLife = (int)stream.ReceiveNext();
        }

    }

    [PunRPC]
    public void FireOn()
    {
        isFire = true;
        particle_fire.SetActive(true);
    }

    [PunRPC]
    public void FireOff()
    {
        isFire = false;
        _fire_time = 0;
        particle_fire.SetActive(false);
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
