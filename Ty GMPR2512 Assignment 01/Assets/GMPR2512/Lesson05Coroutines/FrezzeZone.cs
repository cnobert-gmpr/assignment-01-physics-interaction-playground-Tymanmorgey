using System.Collections;
using UnityEngine;

namespace GMPR2512Lesson05Coroutines
{
    public class FrezzeZone : MonoBehaviour
    {
        [SerializeField] private float _frezzeTime = 1, _rotateSpeed = 1;

        private GameObject _ball, _frezzer;

        private Vector3 _ballSaveVelocaty;

        private float _ballSaveAngulerVelocaty, _ballSaveGravity, _ballHitSpeed;

    

        void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject ball = collision.gameObject;
            Debug.Log($"i will frezze {ball}");

            _ball = collision.gameObject;

            _frezzer = this.GetComponent<Collider2D>().gameObject;

            Rigidbody2D Ballrb = _ball.GetComponent<Rigidbody2D>();

            _ballSaveVelocaty = Ballrb.linearVelocity;
            _ballSaveAngulerVelocaty = Ballrb.angularVelocity;

            _ballSaveGravity = Ballrb.gravityScale;

            Ballrb.gravityScale = 0f;

            Ballrb.linearVelocity = Vector2.zero;

            _ball.transform.parent = _frezzer.transform;


            StartCoroutine(SpinFrezzer(_frezzeTime));

            Debug.Log("spin done");


        }

        IEnumerator SpinFrezzer(float time)
        {
            float timer = 0.0f;

            while (timer <= time)
            {
                timer += Time.deltaTime;

                SpinFrezzer();
                

                yield return null;
            }
            Unfrezzes();

        }

        void SpinFrezzer()
        {
            transform.Rotate(new Vector3(0,0,_rotateSpeed));
            
        }

        void Unfrezzes()
        {
            _ball.transform.parent = null;
            _ball.GetComponent<Rigidbody2D>().gravityScale = _ballSaveGravity;
            _ball.GetComponent<Rigidbody2D>().linearVelocity = _ballSaveVelocaty;
            _ball.GetComponent<Rigidbody2D>().angularVelocity = _ballSaveAngulerVelocaty;
        }

    }
}
