//USE THIS FOR PC

//using UnityEngine;

//namespace RollOn.Scripts
//{
//    public class RestrictMovement : MonoBehaviour
//    {
//        public Rigidbody rb;
//        public float minX = -4.5f;
//        public float maxX = 4.5f;
//        public float bounceForce = 1.0f;

//        private void FixedUpdate()
//        {
//            Vector3 clampedPosition = transform.position;
//            clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
//            rb.MovePosition(clampedPosition);

//            if (clampedPosition.x == minX && rb.velocity.x < 0)
//            {
//                rb.AddForce(Vector3.right * bounceForce, ForceMode.Impulse);
//            }
//            else if (clampedPosition.x == maxX && rb.velocity.x > 0)
//            {
//                rb.AddForce(Vector3.left * bounceForce, ForceMode.Impulse);
//            }
//        }
//    }
//}






//USE FOR MOBILE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollOn.Scripts
{

    public class RestrictMovement : MonoBehaviour
    {
        public Rigidbody rb;



        void FixedUpdate()
        {
            if (transform.position.x > 4.5f)
            {
                transform.position = new Vector3(4.5f, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -4.5f)
            {
                transform.position = new Vector3(-4.5f, transform.position.y, transform.position.z);
            }
        }
    }

}
