using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeChapterNumber : MonoBehaviour {

    public GameObject[] _image;
    public int _number;
    public bool isReverse;

    public GameObject otherButton;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(_number < 0){
            _number = 0;
        }

        if(_number > _image.Length){
            _number = _image.Length;
        }
	}

    public void NumberChange()
    {
        
        if(isReverse){
            _number--;

            if(_number >= 0){
                OffImage();

                _image[_number].SetActive(true);

                otherButton.GetComponent<ChangeChapterNumber>()._number = _number;
            }

           
        }else{
            _number++;

            if(_number < _image.Length){
                OffImage();

                _image[_number].SetActive(true);
                otherButton.GetComponent<ChangeChapterNumber>()._number = _number;
            }
           
        }
       
    }

    void OffImage(){
        for (int i = 0;i < _image.Length ;i++){
            _image[i].SetActive(false);
        }
    }
}
