using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class GetFire : MonoBehaviour
    {

        float v;
        float h;
        private Vector3 velocity;
        bool _isGet = false;
        // Use this for initialization
        void Start()
        {
            Destroy(this.gameObject, 100.0f);
        }

        // Update is called once per frame
        void Update()
        {



        }

        void OnTriggerStay(Collider col)
        {
            if (col.gameObject.tag == "Player")
            {
                transform.LookAt(col.gameObject.transform);
                velocity = new Vector3(h, 0, v);
                velocity = transform.TransformDirection(velocity);
                transform.localPosition += velocity * Time.fixedDeltaTime * 10;
                v += Time.deltaTime;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>()._fireEssence += 1;
                Destroy(this.gameObject);
            }
        }
    }
}