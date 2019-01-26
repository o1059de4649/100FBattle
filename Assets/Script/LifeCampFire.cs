using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCampFire : MonoBehaviour {
    public bool isFire = false,isStoneFire = false;

    public int _wood,_stone,_meal;
    public float _fire_time = 0,_glass_wait_time = 0;
    PhotonView photonView;

    public GameObject particle_fire,canvas,player;
    public float _waitTime = 0,_wait_stoneTime;

    public Text item_text;
    // Use this for initialization

    public int _objLife = 15;
	void Start () {
        photonView = this.gameObject.GetPhotonView();
        this.gameObject.name = this.gameObject.name.Replace("(Clone)", "");
	}
	
	// Update is called once per frame
	void Update () {

        //破壊処理
        if(_objLife <= 0 && PhotonNetwork.isMasterClient){
            photonView.RPC("OnDestroy",PhotonTargets.AllBufferedViaServer);
        }

        //テキスト更新
        item_text.text = ("お肉:" + _meal.ToString() + "\n"
                          + "木材:" + _wood.ToString() + "\n"
                         + "石材:" + _stone.ToString() + "\n"
                          +"お肉燃焼時間" + Mathf.Floor(_waitTime).ToString()+ "\n"
                          + "ガラス作成時間" + Mathf.Floor(_glass_wait_time).ToString()
                         );

        //マスター処理
        if(!PhotonNetwork.isMasterClient){
            return;
        }

      
        if(_wood > 0 && _meal > 0){
            _wood--;
            _meal--;
            _fire_time += 10;
        }

        if (_wood > 0 && _stone > 0)
        {
            _wood--;
            _stone--;
            _glass_wait_time += 10;
        }

        //お肉を焼く
        if(_fire_time > 0){
            photonView.RPC("FireOn", PhotonTargets.All);
            _fire_time -= Time.deltaTime;
            _waitTime += Time.deltaTime;
            if(_waitTime >= 10){
                PhotonNetwork.Instantiate("MeatBakedItem", this.transform.position + new Vector3(0, 2, 0), Quaternion.identity, 0);
                _waitTime = 0;
            }
        }

        //
        if (_glass_wait_time > 0)
        {
            photonView.RPC("FireOn", PhotonTargets.All);
            _glass_wait_time -= Time.deltaTime;
            _wait_stoneTime += Time.deltaTime;
            if(_wait_stoneTime >= 10){
                PhotonNetwork.Instantiate("GlassItem",this.transform.position + new Vector3(0,2,0),Quaternion.identity, 0);
                _wait_stoneTime = 0;
            }

        }



        if(_glass_wait_time <= 0 && _fire_time <= 0){
            photonView.RPC("FireOff", PhotonTargets.All);
        }
      


	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "WoodItem"){
            _wood++;
            collision.gameObject.GetPhotonView().RPC("OnDestroy", PhotonTargets.All);
        }

        if (collision.gameObject.name == "StoneItem")
        {
            _stone++;
            collision.gameObject.GetPhotonView().RPC("OnDestroy", PhotonTargets.All);
        }

        if (collision.gameObject.name == "MeatItem")
        {
            _meal++;
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
            if(col.gameObject.name == "MyPlayer"){
                player = col.gameObject;
            }
           
        }



       
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(_wood);
            stream.SendNext(_stone);
            stream.SendNext(_meal);
            stream.SendNext(_objLife);
            stream.SendNext(_waitTime);
            stream.SendNext(_glass_wait_time);
        }
        else
        {
            _wood = (int)stream.ReceiveNext();
            _stone = (int)stream.ReceiveNext();
            _meal = (int)stream.ReceiveNext();
            _objLife = (int)stream.ReceiveNext();
            _waitTime =(float)stream.ReceiveNext();
            _glass_wait_time = (float)stream.ReceiveNext();
        }

    }

    [PunRPC]
    public void FireOn(){
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
    public void DamageObject(){
        if(PhotonNetwork.isMasterClient){
            _objLife--;
        }

    }

    [PunRPC]
    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }

}
