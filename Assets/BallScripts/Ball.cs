using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

namespace BallScripts
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float jumpForce = 300f;
        public float maxHeight = -5;
        /*private bool _calculated = false;*/
        public float worldSpaceHeight;
        private void Update()
        {
            worldSpaceHeight = gameObject.transform.position.y;
            if (Input.GetKeyDown(KeyCode.Space))Jump();
            MaxHeight();
        }
        public void Jump()
        {
            if (_rigidbody.velocity.y > 0 || gameObject.transform.position.y > 0.5f) return;
            /*_maxHeight = gameObject.transform.position.y;*/
            /*print("is jumped");*/
            _rigidbody.AddForce(0f,jumpForce,0f);
            /*_calculated = true;*/
        }
        private void MaxHeight()
        {
            if (gameObject.transform.position.y >= maxHeight)
            {
                maxHeight = gameObject.transform.position.y;
            }
            /*
            if(_maxHeight > gameObject.transform.position.y && _calculated)
            {
                print(_maxHeight);
                _calculated = false;
            }*/
        }
    }
}
