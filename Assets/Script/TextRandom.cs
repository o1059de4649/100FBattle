using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextRandom : MonoBehaviour {
    Text chapter_text;
    int _randam;
    string[] chapter = {"スケルトンは骨が脆い","イモムシは骨魔法が効きやすい","エレメンタルに魔法は効かない","ゴーストに剣は当たらない","ヘルプにはたくさんの情報が書いてある","仲間にしたモンスターは忠実な部下となる",
        "アイスの魔法は防御がアップし、傷が癒える","剣をモンスターに当てるとエッセンスが手に入る","死んだ仲間は戻ってこない","宝箱からは武具が手に入ることがある","モンスターにはそれぞれ弱点がある"};
	// Use this for initialization
	void Start () {
        chapter_text = GetComponent<Text>();
        _randam = Random.Range(0,chapter.Length);
        chapter_text.text = chapter[_randam];

       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
