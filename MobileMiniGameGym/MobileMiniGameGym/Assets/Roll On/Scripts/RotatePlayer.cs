using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollOn.Scripts{
    
    public class RotatePlayer : MonoBehaviour
    {
    
        private float rotationSpeed = 650f;
    
        void FixedUpdate()
        {
    
            // Rotate the ball forward constantly
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
    }
    
}
