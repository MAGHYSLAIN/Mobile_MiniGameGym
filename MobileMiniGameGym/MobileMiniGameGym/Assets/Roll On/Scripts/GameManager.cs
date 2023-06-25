using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using RollOn.Scripts.ShopScripts;

namespace RollOn.Scripts{
    
    public class GameManager : MonoBehaviour
    {
        public string androidUrl;
        public string iOSUrl;
    
        public Text[] popUpTexts; // The two text elements that will display the phrases
    
        public float randomTime;
    
        // The list of phrases to randomly choose from
        private string[] phrases = { "NICE!", "YOU ROCK!", "GREAT!", "WOOHOO!", "FASTER!", "AMAZING!", "PERFECT!", "ON FIRE!", "WOW!", "INSANE!"};
    
        //Declare a variable to store the key for the playerprefs
        private string coinsKey = "Coins";
        public int coins = Coin.coins;
    
        //REFERENCES
        public GameObject CoinUiContinueButton;
        public GameObject ContinueButton;
        public GameObject respawnCountDown;
        public GameObject coinsObj;
        public Text coinsText; 
        public GameObject deathUI;
        public GameObject scoreGameObject;
        public Transform playerPosition;
        public Rigidbody playerRb;
        public Transform playerModel;
        public RotatePlayer rotation;
        public Animator animator;
        public PlayerMovement playerMovement;
        public Transform player;
        public Text scoreText;
        public Canvas tapToPlay;
        public TMP_Text tapToPlayText;
        public ObstacleSpawner obstacleSpawner;
        public ChangeColors changeColorsScript;
        public SettingsButton settingsButtonScript;
        public GameObject powerUpUI;
        public ShopScripts.SkinManager skinManager;
    
        public float playerScore;
        public int highScore;
        public int restartCount;
    
        Vector3 originalPos;
        public bool gameHasEnded = false;
        public bool powerUpCollected = false;
        public bool powerUpNeverCollected = true;
        public bool scoreIncrease = false;
        public bool scoreDecrease = false;
        public float multiplier = 1.2f;
        public float gateMultiplier = 1f;
    
    
        //GROUND SPAWNING
        public GameObject ground1, ground2, ground3, ground4;
        public Vector3 position1, position2, position3, position4;
    
        //PARTICLES
        public GameObject trailFX;
        public GameObject fireFX;
        public GameObject deathFX;
        public GameObject respawnFX;
        public GameObject gateGreenFX;
        public GameObject gateRedFX;
        public GameObject vignetteGreen;
        public GameObject vignetteRed;
    
        //SKINS
        public MeshRenderer playerMesh;
        public MeshRenderer beachBallSkinMesh;
        public MeshRenderer basketBallSkinMesh;
        public GameObject atomBallObj;
        public GameObject bombBallObj;
        public MeshRenderer eyeBallSkinMesh;
        public MeshRenderer golfBallSkinMesh;
        public MeshRenderer soccerBallSkinMesh;
        public MeshRenderer spikeBallSkinMesh;
        public MeshRenderer tennisBallSkinMesh;
        public MeshRenderer watermelonBallSkinMesh;
        public MeshRenderer wheelBallSkinMesh;
        public MeshRenderer woodenBallSkinMesh;

        //AUDIO
       
        public AudioClip deathSound;
        public AudioClip respawnSound;
        public AudioClip buttonSound;
        public AudioClip gatePositive;
        public AudioClip gatePositive02;
        public AudioClip gatePositive03;
        public AudioClip gatePositive04;
        public AudioClip gateNegative;
        public AudioClip gateNegative02;
        public AudioClip gateNegative03;
        public AudioClip gateNegative04;
    
        public AudioSource audioSource;
    
        private void PopUpText()
        {
            if (gameHasEnded == false && playerScore > 70)
            {
    
                // Choose a random phrase to display
                string chosenPhrase = phrases[Random.Range(0, phrases.Length)];
    
                // Choose a random text element to display the phrase in
                int chosenTextIndex = Random.Range(0, popUpTexts.Length);
                Text chosenText = popUpTexts[chosenTextIndex];
    
                // Set the text of both text elements to the chosen phrase
                foreach (Text text in popUpTexts)
                {
                    text.text = chosenPhrase;
                }
    
                // Enable the chosen text element and disable the other one
                chosenText.gameObject.SetActive(true);
                popUpTexts[(chosenTextIndex + 1) % popUpTexts.Length].gameObject.SetActive(false);
    
                // Disable the active text element after 3 seconds
                Invoke("DisableActiveText", 3f);
    
                randomTime = Random.Range(10f, 22.5f);
            }
        }
    
        private void DisableActiveText()
        {
            foreach (Text text in popUpTexts)
            {
                if (text.gameObject.activeSelf)
                {
                    text.gameObject.SetActive(false);
                    break;
                }
            }
        }
    
    
        //CALL THIS AFTER REWARDED VIDEO WATCHED SUCCESS
        public void AdRespawn()
        {
            audioSource.clip = respawnSound;
            audioSource.Play();
    
            Coin.coins += 100;
    
            if (skinManager.colorSkin == true)
            {
                playerMesh.enabled = true;
            }
    
            if(skinManager.beachSkin == true)
            {
                beachBallSkinMesh.enabled = true;
            }
    
            if (skinManager.basketSkin == true)
            {
                basketBallSkinMesh.enabled = true;
            }
    
            if (skinManager.atomSkin == true)
            {
                atomBallObj.SetActive(true);
            }
    
            if (skinManager.bombSkin == true)
            {
                bombBallObj.SetActive(true);
            }
    
            if (skinManager.eyeSkin == true)
            {
                eyeBallSkinMesh.enabled = true;
            }
    
            if (skinManager.golfSkin == true)
            {
               golfBallSkinMesh.enabled = true;
            }
    
            if (skinManager.soccerSkin == true)
            {
                soccerBallSkinMesh.enabled = true;
            }
    
            if (skinManager.spikeSkin == true)
            {
                spikeBallSkinMesh.enabled = true;
            }
    
            if (skinManager.tennisSkin == true)
            {
                tennisBallSkinMesh.enabled = true;
            }
    
            if (skinManager.watermelonSkin == true)
            {
                watermelonBallSkinMesh.enabled = true;
            }
    
            if (skinManager.wheelSkin == true)
            {
                wheelBallSkinMesh.enabled = true;
            }
    
            if (skinManager.woodenSkin == true)
            {
                woodenBallSkinMesh.enabled = true;
            }
    
            respawnCountDown.SetActive(true);
            respawnFX.SetActive(true);
            CoinUiContinueButton.SetActive(false);
            ContinueButton.SetActive(false);
            respawnCountDown.SetActive(true);
    
            playerPosition.transform.rotation = Quaternion.Euler(0, 0, 0);
            playerModel.transform.rotation = Quaternion.Euler(0, 0, 0);
    
            playerPosition.transform.position = new Vector3(playerPosition.transform.position.x, playerPosition.transform.position.y, playerPosition.transform.position.z - 30f);
    
            DisableDeathUI();
            Invoke("TapToPlay", 3.05f);
    
        }
    
        public void ButtonClickedSound()
        {
            audioSource.clip = buttonSound;
            audioSource.Play();
        }
    
        public void TapToPlay()
        {
            settingsButtonScript.timesClicked = 0;
            settingsButtonScript.DisableButtons();
            EnableScore();
    
            rotation.enabled = true;
    
            playerMovement.forwardForce = 4000f;
            playerRb.isKinematic = false;
    
            playerMovement.enabled = true;
            tapToPlay.enabled = false;
            tapToPlayText.enabled = false;
    
            coinsObj.SetActive(false);
            deathFX.SetActive(false);
           
                trailFX.SetActive(true);
            
    
            respawnFX.SetActive(false);
            gameHasEnded = false;
    
            playerModel.transform.rotation = Quaternion.identity;
        }
    
        public void TapToPlayRestart()
        {
            playerMovement.enabled = false;
            tapToPlay.enabled = true;
            tapToPlayText.enabled = true;
    
            if (skinManager.colorSkin == true)
            {
                playerMesh.enabled = true;
            }
    
            if (skinManager.beachSkin == true)
            {
                beachBallSkinMesh.enabled = true;
            }
    
            if (skinManager.basketSkin == true)
            {
                basketBallSkinMesh.enabled = true;
            }
    
            if (skinManager.atomSkin == true)
            {
                atomBallObj.SetActive(true);
            }
    
            if (skinManager.bombSkin == true)
            {
                bombBallObj.SetActive(true);
            }
    
            if (skinManager.eyeSkin == true)
            {
                eyeBallSkinMesh.enabled = true;
            }
    
            if (skinManager.golfSkin == true)
            {
                golfBallSkinMesh.enabled = true;
            }
    
            if (skinManager.soccerSkin == true)
            {
                soccerBallSkinMesh.enabled = true;
            }
    
            if (skinManager.spikeSkin == true)
            {
                spikeBallSkinMesh.enabled = true;
            }
    
            if (skinManager.tennisSkin == true)
            {
                tennisBallSkinMesh.enabled = true;
            }
    
            if (skinManager.watermelonSkin == true)
            {
                watermelonBallSkinMesh.enabled = true;
            }
    
            if (skinManager.wheelSkin == true)
            {
                wheelBallSkinMesh.enabled = true;
            }
    
            if (skinManager.woodenSkin == true)
            {
                woodenBallSkinMesh.enabled = true;
            }
    
            coinsObj.SetActive(true);
            powerUpNeverCollected = true;
    
        }
    
        void Update()
        {
            //playerScore = ((int)player.position.z);
    
    
            //PLAYERPREFS save coins value
            coins = Coin.coins;
            PlayerPrefs.SetInt(coinsKey, coins);
            PlayerPrefs.Save();
    
            if(powerUpNeverCollected == true)
            {
                playerScore = player.position.z * gateMultiplier;
            }
    
            if(scoreIncrease == true)
            {
                gateMultiplier *= 1.25f;
                scoreIncrease = false;
            }
    
            if (scoreDecrease == true)
            {
                gateMultiplier *= 0.75f;
                scoreDecrease = false;
            }
    
    
            if (powerUpCollected == false)
            {
                if (powerUpNeverCollected == false)
                {
                    playerScore = player.position.z * multiplier * gateMultiplier;
                   
                }
            }
    
            if (powerUpCollected == true)
            {
                playerScore = player.position.z * multiplier * gateMultiplier;
               
            }
            if (scoreText != null)
            {
                scoreText.text = playerScore.ToString("0");
            }
    
    
            if (playerScore > 1000)
            {
                playerMovement.forwardForce = 4200f;
               
            }
    
            if (playerScore > 2000)
            {
                playerMovement.forwardForce = 4300f;
            }
    
            if (playerScore > 3000)
            {
                playerMovement.forwardForce = 4450f;
            }
    
            if (playerScore > 4000)
            {
                playerMovement.forwardForce = 4600f;
            }
    
            if (playerScore > 5000)
            {
                playerMovement.forwardForce = 4700f;
            }
    
            if (playerScore > 6000)
            {
                playerMovement.forwardForce = 4800f;
            }
    
            if (playerScore > 7000)
            {
                playerMovement.forwardForce = 5000f;
            }
    
            if (playerScore > 8000)
            {
                playerMovement.forwardForce = 5100f;
            }
    
            if (playerScore > 9000)
            {
                playerMovement.forwardForce = 5200f;
            }
    
            if (playerScore > 10000)
            {
                playerMovement.forwardForce = 5400f;
            }
    
            if (playerScore > 12000)
            {
                playerMovement.forwardForce = 5600f;
            }
    
            if (playerScore > 15000)
            {
                playerMovement.forwardForce = 5700f;
            }
        }
        public void DisableScore()
        {
            scoreGameObject.SetActive(false);
        }
    
        public void EnableScore()
        {
            scoreGameObject.SetActive(true);
        }
    
        void Start()
        {

            randomTime = Random.Range(10f, 20f);
            InvokeRepeating("PopUpText", 0f, randomTime);
    
            Application.targetFrameRate = 288;   //THIS IS TO SET THE FRAMERATE
    
            //REFERENCES
            audioSource = GetComponent<AudioSource>();
    
            //For respawning the player
            originalPos = new Vector3(playerPosition.transform.position.x, playerPosition.transform.position.y, playerPosition.transform.position.z);  //To reset the player to the original position when he dies
    
    
            // Load the high score from PlayerPrefs or set it to 0 if it doesn't exist
           highScore = PlayerPrefs.GetInt("HighScore", 0);
    
            //Retrieve the saved value of the coins, or set it to 0 if it hasn't been saved yet
            int savedCoins = PlayerPrefs.GetInt(coinsKey, 0);
            //Set the value of the coins integer to the saved value
            coins = savedCoins;
    
            DisableScore();
        }
    
        public void CheckHighScore()
        {
            // Update the high score if the player's score beats the old high score
            if (playerScore > highScore)
            {
                highScore = (int)playerScore;
                PlayerPrefs.SetInt("HighScore", highScore);
                Debug.Log("New high score!!!!!" + PlayerPrefs.GetInt("HighScore"));
            }
        }
        public void EndGame()
        {
            if (gameHasEnded == false)
            {
                DisableActiveText();
                CheckHighScore();
                gameHasEnded = true;
                Invoke("DeathUI", 0f);
                DisableScore();
    
                rotation.enabled = false;
                playerMovement.forwardForce = 4000f;
                playerRb.isKinematic = true;
    
                //PARTICLES
    
                deathFX.SetActive(true);
    
               
                    trailFX.SetActive(false);
                
    
                fireFX.SetActive(false);
                powerUpUI.SetActive(false);
    
                if (skinManager.colorSkin == true)
                {
                    playerMesh.enabled = false;
                }
    
                if (skinManager.beachSkin == true)
                {
                    beachBallSkinMesh.enabled = false;
                }
    
                if (skinManager.basketSkin == true)
                {
                    basketBallSkinMesh.enabled = false;
                }
    
                if (skinManager.atomSkin == true)
                {
                    atomBallObj.SetActive(false);
                }
    
                if (skinManager.bombSkin == true)
                {
                    bombBallObj.SetActive(false);
                }
    
                if (skinManager.eyeSkin == true)
                {
                    eyeBallSkinMesh.enabled = false;
                }
    
                if (skinManager.golfSkin == true)
                {
                    golfBallSkinMesh.enabled = false;
                }
    
                if (skinManager.soccerSkin == true)
                {
                    soccerBallSkinMesh.enabled = false;
                }
    
                if (skinManager.spikeSkin == true)
                {
                    spikeBallSkinMesh.enabled = false;
                }
    
                if (skinManager.tennisSkin == true)
                {
                    tennisBallSkinMesh.enabled = false;
                }
    
                if (skinManager.watermelonSkin == true)
                {
                    watermelonBallSkinMesh.enabled = false;
                }
    
                if (skinManager.wheelSkin == true)
                {
                    wheelBallSkinMesh.enabled = false;
                }
    
                if (skinManager.woodenSkin == true)
                {
                    woodenBallSkinMesh.enabled = false;
                }
    
                //SOUND
    
                audioSource.clip = deathSound;
                audioSource.Play();
    
    
            }
        }
    
        public void Restart()
        {
            // RESET GROUND POSITION
            ground1.transform.position = position1;
            ground2.transform.position = position2;
            ground3.transform.position = position3;
            ground4.transform.position = position4;
    
            FindObjectOfType<ObstacleSpawner>().DeleteObstacles();
            FindObjectOfType<ObstacleSpawner>().Invoke("ObstaclesInitialize", 0.01f);
    
            FindObjectOfType<GroundSpawner>().SortGroundsAlphabetically();
    
            obstacleSpawner.startZRespawn = 750f;
            multiplier = 1.2f;
            gateMultiplier = 1f;
    
    
            //UI re-enable
            deathUI.SetActive(false);
            CoinUiContinueButton.SetActive(true);
            ContinueButton.SetActive(true);
            respawnCountDown.SetActive(false);
    
            //Reset player positions
            playerRb.velocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero;
            playerPosition.transform.position = originalPos;
            playerPosition.transform.rotation = Quaternion.Euler(0, 0, 0);
            playerModel.transform.position = originalPos;
            playerModel.transform.rotation = Quaternion.Euler(0, 0, 0);
    
            playerMovement.enabled = false;
    
            TapToPlayRestart();
            restartCount++;
        }
    
    
        void DeathUI()
        {
            deathUI.SetActive(true);
            animator.enabled = true;
        }
    
        void DisableDeathUI()
        {
            deathUI.SetActive(false);
            animator.enabled = true;
        }
    
        public void PowerUpCollected()
        {
            Invoke("PowerUpEnd", 5f);
            powerUpUI.SetActive(true);
            fireFX.SetActive(true);
            trailFX.SetActive(false);
            powerUpCollected = true;
            powerUpNeverCollected = false;
            multiplier = multiplier + 0.1f;
        }
    
        public void PowerUpEnd()
        {
            powerUpUI.SetActive(false);
            fireFX.SetActive(false);
            if(gameHasEnded == false)
            {
                    trailFX.SetActive(true);
            }
          
            powerUpCollected = false;
        }
    
        public void GateGreen()
        {
            gateGreenFX.SetActive(true);
    
            // Create an array of the four audio clips
            AudioClip[] clips = new AudioClip[] { gatePositive03, gatePositive04, gatePositive02, gatePositive };
    
            // Choose a random index from 0 to 3
            int randomIndex = Random.Range(0, 4);
    
            // Get the selected audio clip from the array
            AudioClip selectedClip = clips[randomIndex];
    
            // Play the selected audio clip
            audioSource.PlayOneShot(selectedClip);
    
            vignetteGreen.SetActive(true);
    
            Invoke("ResetGateEffects", 1.5f);
        }
    
        public void GateRed()
        {
            gateRedFX.SetActive(true);
    
            // Create an array of the four audio clips
            AudioClip[] clips = new AudioClip[] { gateNegative03, gateNegative04, gateNegative02, gateNegative };
    
            // Choose a random index from 0 to 3
            int randomIndex = Random.Range(0, 4);
    
            // Get the selected audio clip from the array
            AudioClip selectedClip = clips[randomIndex];
    
            // Play the selected audio clip
            audioSource.PlayOneShot(selectedClip);
    
            vignetteRed.SetActive(true);
    
            Invoke("ResetGateEffects", 1.5f);
        }
    
        public void ResetGateEffects()
        {
            gateGreenFX.SetActive(false);
            vignetteGreen.SetActive(false);
            gateRedFX.SetActive(false);
            vignetteRed.SetActive(false);
        }
    
    
    
        public void OpenURL()
        {
    #if UNITY_ANDROID
            Application.OpenURL(androidUrl);
    #elif UNITY_IOS
            Application.OpenURL(iOSUrl);
    #endif
        }
    
        public void ShareButton()
        {
            string message = "🌟 Can you beat my high score of: " + highScore + " in this addictive mobile game called Roll On! 🌟 Download now on Google Play or the App Store! 🎮📱";
    
            // Check if we're on Android or iOS
    #if UNITY_ANDROID
        string url = androidUrl;
    #elif UNITY_IOS
        string url = iOSUrl;
    #endif
    
            // Share on Android using an intent
    #if UNITY_ANDROID
        string shareSubject = "Roll On!"; // Subject of the share
        string shareMessage = message + " " + url; // Text to share
        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        intentObject.Call<AndroidJavaObject>("setType", "text/plain");
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), shareSubject);
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), shareMessage);
        AndroidJavaClass unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
        currentActivity.Call("startActivity", intentObject);
    #endif
    
            // Share on iOS using Unity's built-in Social class
    #if UNITY_IOS
        string shareMessage = message + " " + url; // Text to share
        Social.Post(shareMessage);
    #endif
        }
    }
    
}
