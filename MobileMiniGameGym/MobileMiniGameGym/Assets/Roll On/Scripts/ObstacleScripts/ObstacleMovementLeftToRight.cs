using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollOn.Scripts.ObstacleScripts{
    
    public class ObstacleMovementLeftToRight : MonoBehaviour
    {
        public float startX = -5f; // starting position of the obstacle (changed to negative value)
        public float moveSpeed = 10f; // speed to move from startX to 0
        public float returnSpeed = 2f; // speed to return from 0 to startX
    
       
    private bool movingToZero = false; // flag to indicate movement direction (changed to false)
        private Vector3 startPosition; // the initial position of the obstacle
    
        void Start()
        {
            startPosition = transform.position;
        }
    
        void Update()
        {
            if (movingToZero)
            {
                // move towards 0 with moveSpeed
                transform.position += Vector3.right * moveSpeed * Time.deltaTime; // changed to right direction
    
                // if the obstacle reaches 0, change direction
                if (transform.position.x >= 0f) // changed to check for positive x value
                {
                    movingToZero = false;
                }
            }
            else
            {
                // move back towards startX with returnSpeed
                transform.position = Vector3.MoveTowards(transform.position, startPosition, returnSpeed * Time.deltaTime);
    
                // if the obstacle reaches startX, change direction
                if (transform.position.x <= startX) // changed to check for negative x value
                {
                    movingToZero = true;
                }
            }
        }
    }
    
}
