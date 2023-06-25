using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollOn.Scripts.ObstacleScripts{
    
    public class ObstacleMovement : MonoBehaviour
    {
        public float startX = 5f; // starting position of the obstacle
        public float moveSpeed = 10f; // speed to move from startX to 0
        public float returnSpeed = 2f; // speed to return from 0 to startX
    
        private bool movingToZero = true; // flag to indicate movement direction
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
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    
                // if the obstacle reaches 0, change direction
                if (transform.position.x <= 0f)
                {
                    movingToZero = false;
                }
            }
            else
            {
                // move back towards startX with returnSpeed
                transform.position = Vector3.MoveTowards(transform.position, startPosition, returnSpeed * Time.deltaTime);
    
                // if the obstacle reaches startX, change direction
                if (transform.position.x >= startX)
                {
                    movingToZero = true;
                }
            }
        }
    }
    
}
