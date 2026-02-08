using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace GMPR2512Lesson05Coroutines
{
    public class Portals : MonoBehaviour
    {
        [SerializeField] private Transform _exitPortal;
        
        void OnCollisionEnter2D(Collision2D collision)
        {

            GameObject ball = collision.gameObject;
            Rigidbody2D ballrb = collision.gameObject.GetComponent<Rigidbody2D>();

            Vector2 saveBallVelocaty = ballrb.linearVelocity;
            float saveBallAngulerVelocity = ballrb.angularVelocity;

            saveBallAngulerVelocity -= -saveBallAngulerVelocity;

            ball.transform.position = _exitPortal.position;
            ballrb.linearVelocity = saveBallVelocaty;
            ballrb.angularVelocity = saveBallAngulerVelocity;

        }

    }
}
