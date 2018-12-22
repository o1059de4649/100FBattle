using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class AudioControl : MonoBehaviour
    {
        public EnemyCount enemyCount;

        public GameObject[] bgm;

        public Material[] _material;
        public GameObject plane;
        public GameObject walls;
        public GameObject[] door;
        Transform wall_transform;
        // Use this for initialization
        void Start()
        {
            enemyCount = GameObject.Find("FloorControl").GetComponent<EnemyCount>();
            wall_transform = walls.transform;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnTriggerEnter(Collider col)
        {
            for (int i = 0;i < bgm.Length;i++){

                if (col.gameObject.tag == "Player" && i * 10 <= enemyCount._floorLevel && enemyCount._floorLevel <= i * 10 + 9)
                {
                    bgm[i].SetActive(true);
                    plane.GetComponent<Renderer>().material = _material[i];
                    door[0].GetComponent<Renderer>().material = _material[i];
                    door[1].GetComponent<Renderer>().material = _material[i];
                    door[2].GetComponent<Renderer>().material = _material[i];
                    foreach (Transform wall in wall_transform.transform)
                    {
                        wall.GetComponent<Renderer>().material = _material[i];

                    }
                }
            }
            /*
            if (col.gameObject.tag == "Player" && 0 <= enemyCount._floorLevel && enemyCount._floorLevel <= 10)
            {
                bgm[0].SetActive(true);
                plane.GetComponent<Renderer>().material = _material[0];
                door[0].GetComponent<Renderer>().material = _material[0];
                door[1].GetComponent<Renderer>().material = _material[0];
                door[2].GetComponent<Renderer>().material = _material[0];
                foreach (Transform wall in wall_transform.transform)
                {
                    wall.GetComponent<Renderer>().material = _material[0];

                }
            }

            if (col.gameObject.tag == "Player" && 11 <= enemyCount._floorLevel && enemyCount._floorLevel <= 20)
            {
                bgm[1].SetActive(true);
                plane.GetComponent<Renderer>().material = _material[1];
                door[0].GetComponent<Renderer>().material = _material[1];
                door[1].GetComponent<Renderer>().material = _material[1];
                door[2].GetComponent<Renderer>().material = _material[1];
                foreach (Transform wall in wall_transform.transform)
                {
                    wall.GetComponent<Renderer>().material = _material[1];
                }
            }

            if (col.gameObject.tag == "Player" && 21 <= enemyCount._floorLevel && enemyCount._floorLevel <= 30)
            {
                bgm[2].SetActive(true);
                plane.GetComponent<Renderer>().material = _material[2];
                door[0].GetComponent<Renderer>().material = _material[2];
                door[1].GetComponent<Renderer>().material = _material[2];
                door[2].GetComponent<Renderer>().material = _material[2];
                foreach (Transform wall in wall_transform.transform)
                {
                    wall.GetComponent<Renderer>().material = _material[2];
                }
            }

            if (col.gameObject.tag == "Player" && 31 <= enemyCount._floorLevel && enemyCount._floorLevel <= 40)
            {
                bgm[3].SetActive(true);
                plane.GetComponent<Renderer>().material = _material[3];
                door[0].GetComponent<Renderer>().material = _material[3];
                door[1].GetComponent<Renderer>().material = _material[3];
                door[2].GetComponent<Renderer>().material = _material[3];
                foreach (Transform wall in wall_transform.transform)
                {
                    wall.GetComponent<Renderer>().material = _material[3];
                }
            }

            if (col.gameObject.tag == "Player" && 41 <= enemyCount._floorLevel && enemyCount._floorLevel <= 49)
            {
                bgm[4].SetActive(true);
                plane.GetComponent<Renderer>().material = _material[4];
                door[0].GetComponent<Renderer>().material = _material[4];
                door[1].GetComponent<Renderer>().material = _material[4];
                door[2].GetComponent<Renderer>().material = _material[4];
                foreach (Transform wall in wall_transform.transform)
                {
                    wall.GetComponent<Renderer>().material = _material[4];
                }
            }
            */
        }

        public void OnTriggerExit(Collider col)
        { /*
            if (col.gameObject.tag == "Player" && 0 <= enemyCount._floorLevel && enemyCount._floorLevel <= 10)
            {
                bgm[0].SetActive(false);
            }

            if (col.gameObject.tag == "Player" && 11 <= enemyCount._floorLevel && enemyCount._floorLevel <= 20)
            {
                bgm[1].SetActive(false);
            }

            if (col.gameObject.tag == "Player" && 21 <= enemyCount._floorLevel && enemyCount._floorLevel <= 30)
            {
                bgm[2].SetActive(false);
            }

            if (col.gameObject.tag == "Player" && 31 <= enemyCount._floorLevel && enemyCount._floorLevel <= 40)
            {
                bgm[3].SetActive(false);
            }

            if (col.gameObject.tag == "Player" && 41 <= enemyCount._floorLevel && enemyCount._floorLevel <= 50)
            {
                bgm[4].SetActive(false);
            }

            if (col.gameObject.tag == "Player" && 51 <= enemyCount._floorLevel && enemyCount._floorLevel <= 60)
            {
                bgm[0].SetActive(false);
            }

            if (col.gameObject.tag == "Player" && 61 <= enemyCount._floorLevel && enemyCount._floorLevel <= 70)
            {
                bgm[1].SetActive(false);
            }

            if (col.gameObject.tag == "Player" && 71 <= enemyCount._floorLevel && enemyCount._floorLevel <= 80)
            {
                bgm[2].SetActive(false);
            }

            if (col.gameObject.tag == "Player" && 81 <= enemyCount._floorLevel && enemyCount._floorLevel <= 90)
            {
                bgm[3].SetActive(false);
            }

            if (col.gameObject.tag == "Player" && 91 <= enemyCount._floorLevel && enemyCount._floorLevel <= 100)
            {
                bgm[4].SetActive(false);
            }
            */
            if(col.gameObject.tag == "Player"){
                for (int i = 0; i < bgm.Length; i++)
                {
                    bgm[i].SetActive(false);
                }
            }
         }
           
    }
}