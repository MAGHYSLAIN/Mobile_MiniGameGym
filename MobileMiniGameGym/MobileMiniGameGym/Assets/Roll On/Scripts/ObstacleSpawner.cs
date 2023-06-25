using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollOn.Scripts{
    
    public class ObstacleSpawner : MonoBehaviour
    {
        public GameObject[] obstaclePrefabs;
        public int numberOfObstacles = 39;
        public float startZ = 30f;
        public float offset = 25f;
        public float startZCoins = 15f;
        public GameObject obstacleContainer;
    
        public float startZRespawn = 750f;
    
        public GameObject coinPrefab;
    
        public GameObject powerUpPrefab;
        public float powerUpChance = 0.2f;
        public int minCoinsPerPowerUp = 70;
        public int maxCoinsPerPowerUp = 150;
    
        public GameObject gateCoin;
        public GameObject gateScore;
    
    
        public void ObstaclesInitialize()
        {
            int gateCount = 0;  // Counter for gate obstacles
    
            for (int i = 0; i < numberOfObstacles; i++)
            {
                //OBSTACLE SPAWNING
                GameObject randomObstacle;
    
                // Spawn a gate obstacle every 15 obstacles when initialized
                if (gateCount == 15)
                {
                    int randomGateIndex = Random.Range(0, 2);
                    randomObstacle = randomGateIndex == 0 ? gateCoin : gateScore;
                    gateCount = 0;
                }
                else
                {
                    int randomIndex = Random.Range(0, obstaclePrefabs.Length);
                    randomObstacle = obstaclePrefabs[randomIndex];
                }
    
                float obstacleZ = startZ + (i * offset);
                Vector3 obstaclePosition = new Vector3(0, 0, obstacleZ);
                GameObject obstacle = Instantiate(randomObstacle, obstaclePosition, Quaternion.identity);
                obstacle.transform.parent = obstacleContainer.transform;
    
                // Increment the gate counter
                gateCount++;
            }
            CoinsInitialize();
        }
    
    
        public void ObstaclesSpawn()
        {
            int numberOfObstacles2 = 10;
            float offset2 = 25f;
    
            startZRespawn = startZRespawn + 250f;
    
            int coinCount = 0;
            int powerUpIndex = Random.Range(5, 15);    //CHANGE ODDS OF POWERUP SPAWNING
            int gateCount = 0;  // Counter for gate obstacles
    
            for (int i = 0; i < numberOfObstacles2; i++)
            {
                //OBSTACLE SPAWNING
                GameObject randomObstacle;
    
                // Spawn a gate obstacle every 5 to 11 obstacles. more than 11 lower chance, less than 11 higher chance.
                if (gateCount == Random.Range(5, 11))
                {
                    int randomGateIndex = Random.Range(0, 2);
                    randomObstacle = randomGateIndex == 0 ? gateCoin : gateScore;
                    gateCount = 0;
                }
                else
                {
                    int randomIndex = Random.Range(0, obstaclePrefabs.Length);
                    randomObstacle = obstaclePrefabs[randomIndex];
                }
    
                float obstacleZ = startZRespawn + (i * offset2);
                Vector3 obstaclePosition = new Vector3(0, 0, obstacleZ);
                GameObject obstacle = Instantiate(randomObstacle, obstaclePosition, Quaternion.identity);
                obstacle.transform.parent = obstacleContainer.transform;
    
                // Increment the gate counter
                gateCount++;
    
                //COIN AND POWER UP SPAWNING
                if (coinCount == powerUpIndex)
                {
                    // Spawn power up prefab
                    Vector3 powerUpPosition = new Vector3(Random.Range(-4f, 4f), 0f, obstacleZ + offset2 / 2);
                    Collider[] hitColliders = Physics.OverlapSphere(powerUpPosition, 0f);
                    if (hitColliders.Length == 0)
                    {
                        GameObject powerUp = Instantiate(powerUpPrefab, powerUpPosition, Quaternion.identity);
                        powerUp.transform.parent = obstacleContainer.transform;
                    }
                    coinCount = 0;
                }
                else
                {
                    // Spawn coin prefab
                    Vector3 coinPosition = new Vector3(Random.Range(-4f, 4f), 1f, obstacleZ + offset2 / 2);
                    Collider[] hitColliders = Physics.OverlapSphere(coinPosition, 1f);
                    if (hitColliders.Length == 0)
                    {
                        GameObject coin = Instantiate(coinPrefab, coinPosition, Quaternion.identity);
                        coin.transform.parent = obstacleContainer.transform;
                        coinCount++;
                    }
                }
            }
        }
    
    
    
        public void CoinsInitialize()
        {
            int powerUpIndex2 = Random.Range(0, numberOfObstacles);
    
            for (int i = 0; i < numberOfObstacles; i++)
            {
                float coinZ = startZCoins + (i * offset);
                Vector3 coinPosition = new Vector3(Random.Range(-3, 3), 1, coinZ);
    
                if (i == powerUpIndex2)
                {
                    // Spawn power up prefab
                    Vector3 powerUpPosition = new Vector3(Random.Range(-4f, 4f), 0f, coinZ + offset / 3.5f);
                    Collider[] hitColliders = Physics.OverlapSphere(powerUpPosition, 0f);
                    if (hitColliders.Length == 0)
                    {
                        GameObject powerUp = Instantiate(powerUpPrefab, powerUpPosition, Quaternion.identity);
                        powerUp.transform.parent = obstacleContainer.transform;
    
                        GameObject coin = Instantiate(coinPrefab, coinPosition, Quaternion.identity);
                        coin.transform.parent = obstacleContainer.transform;
                    }
                }
                else
                {
                    // Spawn coin prefab
                    GameObject coin = Instantiate(coinPrefab, coinPosition, Quaternion.identity);
                    coin.transform.parent = obstacleContainer.transform;
                }
            }
        }
        public void DeleteObstacles()
        {
            int childCount = obstacleContainer.transform.childCount;
            for (int i = childCount - 1; i >= 0; i--)
            {
                GameObject.Destroy(obstacleContainer.transform.GetChild(i).gameObject);
            }
    
        }
        private void Start()
        {
            ObstaclesInitialize();
        }
    }
}