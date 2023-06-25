using UnityEngine;

namespace RollOn.Scripts.ObstacleScripts{
    
    public class HorizontalMovement : MonoBehaviour
    {
        public float speed = 5.0f;
        public float constraintValue;
        public float constraintValueNegative;
        private bool moveRight = true;
    
        void Update()
        {
            if (moveRight)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                if (transform.position.x >= constraintValue)
                {
                    moveRight = false;
                }
            }
            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                if (transform.position.x <= constraintValueNegative)
                {
                    moveRight = true;
                }
            }
        }
    }
    
}
