using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollOn.Scripts{
    
    public class Coin : MonoBehaviour
    {
        public static int coins;
        public GameObject coinParticle;
        public GameObject floatingText1;
        public GameObject floatingText3;
        public bool showFloatingText = true; // TOGGLE ON OR OFF FOR FLOATING TEXT
    
        //animation
        private Vector3 initialPosition;
        private Vector3 targetPosition;
        private float animationSpeed = 8f;
        private float animationDistance = 0.1f;
    
        //sound
        public AudioClip coinSoundClip;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                GameManager gameManager = FindObjectOfType<GameManager>();
    
                GameObject floatingTextObject;
                if (gameManager.powerUpCollected == false)
                {
                    coins++;
                    floatingTextObject = floatingText1;
                }
                else
                {
                    coins += 3;
                    floatingTextObject = floatingText3;
                }
    
                Vector3 particlePosition = transform.position;
    
                //Offsets
                particlePosition.z += 5f;
                particlePosition.y += -0.5f;
    
                //spawn coin particle
                GameObject coinParticleObject = Instantiate(coinParticle, particlePosition, Quaternion.identity);
                // Destroy the particle object after 0.5 seconds
                Destroy(coinParticleObject, 0.5f);
    
                if (showFloatingText)
                {
                    //spawn floatingText
                    GameObject floatingTextInstance = Instantiate(floatingTextObject, particlePosition, Quaternion.identity);
                    // Destroy the floatingText object after 0.4 seconds
                    Destroy(floatingTextInstance, 0.4f);
                }
    
                gameManager.audioSource.clip = coinSoundClip;
                gameManager.audioSource.Play();
    
                Destroy(gameObject);
            }
        }
    
        void Start()
        {
            coins = PlayerPrefs.GetInt("Coins");
            initialPosition = transform.position;
            targetPosition = initialPosition + new Vector3(0f, animationDistance, 0f);
        }
    
        void Update()
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, animationSpeed * Time.deltaTime);
            transform.Rotate(0f, Time.deltaTime * 100f, 0f);
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                targetPosition = initialPosition;
            }
        }
    }
    
}
