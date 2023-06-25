using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RollOn.Scripts{
    
    public class PlayerMovement : MonoBehaviour
    {
        public Rigidbody rb;
        public float forwardForce = 3500f;
        public float sidewaysForce = 100f;
    
        public void DisablePlayerMovement()
        {
            forwardForce = 0f;
        }
    
        void FixedUpdate()
        {
    
            // Add force to move the ball forward
            rb.AddForce(0f, 0f, forwardForce * Time.deltaTime);
    
            if (Input.GetKey("d"))
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
            }
    
            if (Input.GetKey("a"))
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
            }
    
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
            }
    
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
            }
    
    
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
    
                if (touch.phase == TouchPhase.Moved)
                {
                    // Check if the touch is over a UI element
                    if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                    {
                        // If the touch is not over a UI element, move the object smoothly
                        Vector2 touchDeltaPosition = touch.deltaPosition;
                        transform.Translate(touchDeltaPosition.x * 0.0085f, 0, 0);   //0.0085f
                    }
                }
            }
        }
    }
    
}
