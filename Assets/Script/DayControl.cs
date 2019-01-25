﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayControl : MonoBehaviour {
    public float _Day_time = 6;
    public int _Day_date = 0;

    public Text _Day_time_text;

    public GameObject sun_Light;
	// Use this for initialization
	void Start () {
        sun_Light = GameObject.Find("Sun");
	}
	
	// Update is called once per frame
	void Update () {
        _Day_time_text.text = (_Day_date.ToString() + "日" + Mathf.Floor(_Day_time).ToString() + "時");



        if(PhotonNetwork.isMasterClient){
            _Day_time += Time.deltaTime * 0.2f;

            sun_Light.transform.eulerAngles = new Vector3(15 * _Day_time -90, 0, 0);
          


            if(_Day_time >= 24){
                _Day_date++;
                _Day_time = 0;
            }
        }


	}

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(_Day_time);
            stream.SendNext(_Day_date);


        }
        else
        {
            _Day_time = (float)stream.ReceiveNext();
            _Day_date = (int)stream.ReceiveNext();


        }

    }


}