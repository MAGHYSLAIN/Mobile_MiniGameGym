using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollOn.Scripts{
    
    public class SpawnManager : MonoBehaviour
    {
        GroundSpawner groundSpawner;
        ObstacleSpawner obstacleSpawner;
        // Start is called before the first frame update
        void Start()
        {
            groundSpawner = GetComponent<GroundSpawner>();
            obstacleSpawner = GetComponent<ObstacleSpawner>();
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }
    
        public void SpawnTriggerEntered()
        {
            groundSpawner.MoveGround();
            if (obstacleSpawner != null)
            {
                obstacleSpawner.ObstaclesSpawn();
            }
        }
    }
    
}
