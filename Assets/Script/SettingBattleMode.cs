using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingBattleMode : MonoBehaviour {
    public Text _bestDays;
    public Text name_inputField_text;
	// Use this for initialization
	void Start () {
        _bestDays.text =  "生き延びた最長記録:"+ PlayerPrefs.GetInt("BestDay", 0).ToString() + "日";

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveName(){
        string name = name_inputField_text.text;
        PlayerPrefs.SetString("MyPlayerName", name);
    }
}
