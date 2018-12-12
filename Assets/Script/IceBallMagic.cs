using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class IceBallMagic : MonoBehaviour
    {
        GameObject player;
        private string[] _enemy_OneHalf = {"golem","Shell_Crab"};
        private string[] _enemy_Three = {
            "SkeletonWizard","SkeletonDarkKnight","SkeletonWeak1","SkeletonWeak1","SkeletonWeak2",
            "SkeletonMedium1","SkeletonMedium2","SkeletonStrong","demon","demonBoss",
            "Spider","SpiderBoss","StringSpider","WarriorMachine","FlyMachine",
            "Ghost"};
        private string[] _enemy_Half = {"wizard", "Imomusi","ImomusiBoss","Imomusi2","icedemon","ImomusiDark" };
        private string[] _enemy_One = {"troll", "goblin","Hobgoblin"};
        // Use this for initialization
        void Start()
        {
            player = GameObject.Find("Player");
            Destroy(this.gameObject, 100.0f);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider enemyObj)
        {


            if (enemyObj.tag == "Enemy")
            {
                for (int i = 0; _enemy_OneHalf.Length > i; i++)
                {
                    if (enemyObj.name == _enemy_Three[i])
                    {
                        enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 1.5f * 4;
                        enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;

                    }
                }

                for (int i = 0; _enemy_Three.Length > i; i++)
                {
                    if (enemyObj.name == _enemy_Three[i])
                    {
                        enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 3 * 4;
                        enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                        if(i == 14){
                            enemyObj.GetComponent<MachineAI>().Broken();
                        }
                    }

                }

                for (int i = 0; _enemy_Half.Length > i; i++)
                {
                    if (enemyObj.name == _enemy_Half[i]){
                        enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 0.5f* 4;
                    enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                    }
                }

                for (int i = 0; _enemy_One.Length > i; i++)
                {
                    if (enemyObj.name == _enemy_One[i])
                    {
                        enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 4;
                        enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                    }
                    Destroy(this.gameObject, 10.0f);
                }
            }
        }

       
    }
}