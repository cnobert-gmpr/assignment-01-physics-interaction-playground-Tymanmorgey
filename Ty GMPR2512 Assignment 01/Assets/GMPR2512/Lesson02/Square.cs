using UnityEngine;

namespace GMPR2512.Lesson02
{
    public class Square : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(0.01f, 0, 0);   
            // transform.Rotate(0, 0, 0.1f);
        }
    }
}
