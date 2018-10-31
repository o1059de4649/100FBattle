using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class LifeGet : MonoBehaviour
    {
        float v;
        float h;
        private Vector3 velocity;
        bool _isGet = false;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
           


        }

        void OnTriggerStay(Collider col)
        {
            if(col.gameObject.tag == "Player"){
                transform.LookAt(col.gameObject.transform);
                velocity = new Vector3(h, 0, v);
                velocity = transform.TransformDirection(velocity);
                transform.localPosition += velocity * Time.fixedDeltaTime;
                v += Time.deltaTime;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Player"){
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().life += collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().maxLife * 0.07f;
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().maxLife++;
                Destroy(this.gameObject);
            }
        }
    }
}
