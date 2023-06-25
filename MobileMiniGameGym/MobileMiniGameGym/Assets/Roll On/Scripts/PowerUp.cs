using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollOn.Scripts{
    
    public class PowerUp : MonoBehaviour
    {
        public GameObject powerUpMulitiplierParticle;
    
        public GameObject powerUpTextPrefab;
    
        //sound
        public AudioClip powerUpMultiplierSoundClip;
    
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                Vector3 particlePosition = transform.position;
    
                //Offsets
                particlePosition.z += 5f;
                particlePosition.y += -0.5f;
    
                //spawn coin particle
                GameObject multiplierParticleObject = Instantiate(powerUpMulitiplierParticle, particlePosition, Quaternion.identity);
                // Destroy the particle object after 0.5 seconds
                Destroy(multiplierParticleObject, 0.5f);
    
                GameManager gameManager = FindObjectOfType<GameManager>();
                gameManager.audioSource.clip = powerUpMultiplierSoundClip;
                gameManager.audioSource.PlayOneShot(powerUpMultiplierSoundClip);
                gameManager.PowerUpCollected();
    
                Destroy(gameObject, 0.01f);
            }
        }
    
        void Start()
        {
            
        }
    
    
        void Update()
        {
           
        }
    }
    
}
