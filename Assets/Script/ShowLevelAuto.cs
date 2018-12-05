using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
public class ShowLevelAuto : MonoBehaviour
{
        public Text _text;
        public SkeletonStatus user_skeletonStatus;

        public Text _name;
        bool _isUpdate = false;
    // Use this for initialization
    void Start()
    {
            _text.text = ("Lv." + user_skeletonStatus._monster_level.ToString());
            NameUpdate();
    }

    // Update is called once per frame
    void Update()
    {
            if(user_skeletonStatus == null){
                _name.text = this.transform.parent.parent.name;
            }

    }

        public void NameUpdate(){

            if(user_skeletonStatus.gameObject.name == "Skeleton(Clone)" && user_skeletonStatus._monster_level >= 30 && _isUpdate == false){
                _name.text = ("強健なスケルトンナイト");
                user_skeletonStatus.gameObject.transform.localScale += new Vector3(0.2f,0.2f,0.2f);
                user_skeletonStatus._maxLife += 40;
                user_skeletonStatus._life += 40;
                user_skeletonStatus._exp += 30;
                user_skeletonStatus._enemyMoney += 30;
                user_skeletonStatus._bloodEssence += 1;
                _isUpdate = true;
            }

            if (user_skeletonStatus.gameObject.name == "SkeletonWeak1(Clone)" && user_skeletonStatus._monster_level >= 30 && _isUpdate == false)
            {
                _name.text = ("グラグラなスケルトン");
                user_skeletonStatus.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                user_skeletonStatus._maxLife += 40;
                user_skeletonStatus._life += 40;
                user_skeletonStatus._exp += 30;
                user_skeletonStatus._enemyMoney += 30;
                user_skeletonStatus._bloodEssence += 1;
                _isUpdate = true;
            }

            if (user_skeletonStatus.gameObject.name == "SkeletonWeak2(Clone)" && user_skeletonStatus._monster_level >= 30 && _isUpdate == false)
            {
                _name.text = ("錆びたスケルトンソード");
                user_skeletonStatus.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                user_skeletonStatus._maxLife += 40;
                user_skeletonStatus._life += 40;
                user_skeletonStatus._exp += 30;
                user_skeletonStatus._enemyMoney += 30;
                user_skeletonStatus._bloodEssence += 1;
                _isUpdate = true;
            }

            if (user_skeletonStatus.gameObject.name == "SkeletonMedium1(Clone)" && user_skeletonStatus._monster_level >= 40 && _isUpdate == false)
            {
                _name.text = ("悲しみのスケルトン");
                user_skeletonStatus.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                user_skeletonStatus._maxLife += 40;
                user_skeletonStatus._life += 40;
                user_skeletonStatus._exp += 30;
                user_skeletonStatus._enemyMoney += 30;
                user_skeletonStatus._bloodEssence += 1;
                _isUpdate = true;
            }

            if (user_skeletonStatus.gameObject.name == "SkeletonMedium2(Clone)" && user_skeletonStatus._monster_level >= 45 && _isUpdate == false)
            {
                _name.text = ("剣豪の骸");
                user_skeletonStatus.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                user_skeletonStatus._maxLife += 80;
                user_skeletonStatus._life += 80;
                user_skeletonStatus._exp += 60;
                user_skeletonStatus._enemyMoney += 60;
                user_skeletonStatus._bloodEssence += 1;
                _isUpdate = true;
            }

            if (user_skeletonStatus.gameObject.name == "Imomusi(Clone)" && user_skeletonStatus._monster_level >= 40 && _isUpdate == false)
            {
                _name.text = ("終齢イモムシ");
                user_skeletonStatus.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                user_skeletonStatus._maxLife += 80;
                user_skeletonStatus._life += 80;
                user_skeletonStatus._exp += 60;
                user_skeletonStatus._enemyMoney += 60;
                user_skeletonStatus._bloodEssence += 1;
                _isUpdate = true;
            }

            if (user_skeletonStatus.gameObject.name == "Imomusi2(Clone)" && user_skeletonStatus._monster_level >= 60 && _isUpdate == false)
            {
                _name.text = ("肉食イモムシ");
                user_skeletonStatus.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                user_skeletonStatus._maxLife += 80;
                user_skeletonStatus._life += 80;
                user_skeletonStatus._exp += 60;
                user_skeletonStatus._enemyMoney += 60;
                user_skeletonStatus._bloodEssence += 1;
                _isUpdate = true;
            }

            if (user_skeletonStatus.gameObject.name == "demon(Clone)" && user_skeletonStatus._monster_level >= 50 && _isUpdate == false)
            {
                _name.text = ("獄炎デーモン");
                user_skeletonStatus.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                user_skeletonStatus._maxLife += 80;
                user_skeletonStatus._life += 80;
                user_skeletonStatus._exp += 60;
                user_skeletonStatus._enemyMoney += 60;
                user_skeletonStatus._bloodEssence += 1;
                _isUpdate = true;
            }

            if (user_skeletonStatus.gameObject.name == "golem(Clone)" && user_skeletonStatus._monster_level >= 60 && _isUpdate == false)
            {
                _name.text = ("硬質ゴーレム");
                user_skeletonStatus.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                user_skeletonStatus._maxLife += 80;
                user_skeletonStatus._life += 80;
                user_skeletonStatus._exp += 60;
                user_skeletonStatus._enemyMoney += 60;
                user_skeletonStatus._bloodEssence += 1;
                _isUpdate = true;
            }

            if (user_skeletonStatus.gameObject.name == "icedemon(Clone)" && user_skeletonStatus._monster_level >= 60 && _isUpdate == false)
            {
                _name.text = ("凍土のアイスデーモン");
                user_skeletonStatus.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                user_skeletonStatus._maxLife += 80;
                user_skeletonStatus._life += 80;
                user_skeletonStatus._exp += 60;
                user_skeletonStatus._enemyMoney += 60;
                user_skeletonStatus._bloodEssence += 1;
                _isUpdate = true;
            }

            if (user_skeletonStatus.gameObject.name == "SkeletonDarkKnight(Clone)" && user_skeletonStatus._monster_level >= 60 && _isUpdate == false)
            {
                _name.text = ("暗黒騎士ダークナイト");
                user_skeletonStatus.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                user_skeletonStatus._maxLife += 80;
                user_skeletonStatus._life += 80;
                user_skeletonStatus._exp += 60;
                user_skeletonStatus._enemyMoney += 60;
                user_skeletonStatus._bloodEssence += 1;
                _isUpdate = true;
            }

            if (user_skeletonStatus.gameObject.name == "ImomusiDark(Clone)" && user_skeletonStatus._monster_level >= 60 && _isUpdate == false)
            {
                _name.text = ("闇に包まれし幼虫");
                user_skeletonStatus.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                user_skeletonStatus._maxLife += 100;
                user_skeletonStatus._life += 100;
                user_skeletonStatus._exp += 80;
                user_skeletonStatus._enemyMoney += 80;
                user_skeletonStatus._bloodEssence += 1;
                _isUpdate = true;
            }

            if (user_skeletonStatus.gameObject.name == "Shell_Crab(Clone)" && user_skeletonStatus._monster_level >= 65 && _isUpdate == false)
            {
                _name.text = ("結晶大蟹");
                user_skeletonStatus.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                user_skeletonStatus._maxLife += 100;
                user_skeletonStatus._life += 100;
                user_skeletonStatus._exp += 80;
                user_skeletonStatus._enemyMoney += 80;
                user_skeletonStatus._bloodEssence += 1;
                _isUpdate = true;
            }

            if (user_skeletonStatus.gameObject.name == "goblin(Clone)" && user_skeletonStatus._monster_level >= 70 && _isUpdate == false)
            {
                _name.text = ("狡猾なゴブリン");
                user_skeletonStatus.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                user_skeletonStatus._maxLife += 100;
                user_skeletonStatus._life += 100;
                user_skeletonStatus._exp += 80;
                user_skeletonStatus._enemyMoney += 80;
                user_skeletonStatus._bloodEssence += 1;
                _isUpdate = true;
            }

            if (user_skeletonStatus.gameObject.name == "Hobgoblin(Clone)" && user_skeletonStatus._monster_level >= 73 && _isUpdate == false)
            {
                _name.text = ("大型ホブゴブリン");
                user_skeletonStatus.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                user_skeletonStatus._maxLife += 200;
                user_skeletonStatus._life += 200;
                user_skeletonStatus._exp += 160;
                user_skeletonStatus._enemyMoney += 160;
                user_skeletonStatus._bloodEssence += 1;
                _isUpdate = true;
            }

            if (user_skeletonStatus.gameObject.name == "troll(Clone)" && user_skeletonStatus._monster_level >= 75 && _isUpdate == false)
            {
                _name.text = ("絶壁のトロール");
                user_skeletonStatus.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                user_skeletonStatus._maxLife += 200;
                user_skeletonStatus._life += 200;
                user_skeletonStatus._exp += 160;
                user_skeletonStatus._enemyMoney += 160;
                user_skeletonStatus._bloodEssence += 1;
                _isUpdate = true;
            }



        }

}
}