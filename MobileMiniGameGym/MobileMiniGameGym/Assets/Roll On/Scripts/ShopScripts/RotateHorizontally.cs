using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollOn.Scripts.ShopScripts{
    
    public class RotateHorizontally : MonoBehaviour
    {
        public float rotationSpeed = 70f; // The rotation speed in degrees per second, adjustable in the Inspector
    
        // Update is called once per frame
        void Update()
        {
            // Rotate the object around the Y axis at the given speed
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
    
}
