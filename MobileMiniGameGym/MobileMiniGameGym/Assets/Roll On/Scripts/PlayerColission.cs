using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollOn.Scripts{
    
    public class PlayerColission : MonoBehaviour
    {
    
        public PlayerMovement movement;
        public SpawnManager spawnManager;
        public GameManager gameManager;
    
        private bool hasCollided = false;
    
        void OnCollisionEnter(Collision colissionInfo)
        {
            if (colissionInfo.collider.tag == "obstacle")
            {
                movement.enabled = false;
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    
        private void OnTriggerEnter(Collider other)
        {
    
            if (other.gameObject.tag == "SpawnTrigger")
            {
                spawnManager.SpawnTriggerEntered();
            }
    
    
            if (other.CompareTag("Gate_CoinsIncrease") && !hasCollided)
            {
                Coin.coins += 25;
                gameManager.GateGreen();
    
                // Set the collision flag to true so that the function is not called again
                hasCollided = true;
            }
    
            if (other.CompareTag("Gate_CoinsDecrease") && !hasCollided)
            {
                Coin.coins -= 25;
                gameManager.GateRed();
    
                // Set the collision flag to true so that the function is not called again
                hasCollided = true;
            }
    
            if (other.CompareTag("Gate_ScoreIncrease") && !hasCollided)
            {
                gameManager.scoreIncrease = true;
                gameManager.GateGreen();
    
                hasCollided = true;
            }
    
            if (other.CompareTag("Gate_ScoreDecrease") && !hasCollided)
            {
                gameManager.scoreDecrease = true;
                gameManager.GateRed();
    
                hasCollided = true;
            }
    
            // Reset the collision flag after a certain amount of time
            StartCoroutine(ResetCollisionFlag(0.3f));
        }
    
        IEnumerator ResetCollisionFlag(float delay)
        {
            yield return new WaitForSeconds(delay);
            hasCollided = false;
        
        }
    }
    
}
