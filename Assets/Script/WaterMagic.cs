using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
public class WaterMagic : MonoBehaviour {

	public GameObject player;
        private string[] _enemyname_normal = {"ImomusiDark", "Imomusi", "ImomusiBoss", "Imomusi2", "Spider", "SpiderBoss", "StringSpider","SkeletonDarkKnight","icedemon","Skeleton","SkeletonWeak1","SkeletonWeak2",
            "SkeletonMedium1","SkeletonMedium2","SkeletonStrong",
            "SkeletonWizard","wizard","troll","goblin","Hobgoblin","WarriorMachine","RhinoObject","CubeMachine","DarkDragon","whale","demonTree","Knight"};

        private string[] _enemyname_weak = { "demonBoss","demon","FireElemental","FlyMachine"};
    // Use this for initialization
    void Start()
    {
            player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject enemyObj)
    {
        if (enemyObj.tag == "Enemy")
        {

            for (int i = 0; _enemyname_normal.Length > i; i++)
            {

                if (enemyObj.name == _enemyname_normal[i])
                {

                    enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower;
                    enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                }

            }


            for (int i = 0; _enemyname_weak.Length > i; i++)
            {
                if (enemyObj.name == _enemyname_weak[i])
                {

                    enemyObj.GetComponent<SkeletonStatus>()._life -= player.GetComponent<UnityChanControlScriptWithRgidBody>()._magicPower * 3;
                    enemyObj.GetComponent<SkeletonStatus>()._isMagic = true;
                        if(enemyObj.name == _enemyname_weak[3]){
                            enemyObj.GetComponent<MachineAI>().Broken();
                        }
                }
            }
        }
    }

}
}
