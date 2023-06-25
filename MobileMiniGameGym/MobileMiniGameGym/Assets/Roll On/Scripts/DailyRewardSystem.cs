using UnityEngine;
using UnityEngine.UI;
using System;

namespace RollOn.Scripts{
    public class DailyRewardSystem : MonoBehaviour
    {
        public Button rewardButton; // Reference to the button that will trigger the reward
        public Text rewardText; // Reference to the text that will display the reward status
        public int coinsPerReward = 50; // Number of coins to give as reward
        public GameObject buttonObject;
        public GameManager gameManager;
        public AudioClip dailyRewardSound;
        public ParticleSystem confettiParticle;
        public GameObject coinText;
    
        public Animator animator; // Reference to the Animator component
        private string dailyRewardEnd = "DailyRewardEnd"; // Name of the animation you want to play
    
        private DateTime lastRewardDate; // Date when the last reward was collected
    
        private void Start()
        {
            // Load the last reward date from player prefs
            string lastRewardDateString = PlayerPrefs.GetString("LastRewardDate", "");
            if (!string.IsNullOrEmpty(lastRewardDateString))
            {
                lastRewardDate = DateTime.ParseExact(lastRewardDateString, "yyyyMMdd", null);
            }
            else
            {
                lastRewardDate = DateTime.MinValue;
            }
    
            // Check if a reward is available
            if (IsRewardAvailable())
            {
                rewardText.text = "DAILY Reward!";
                rewardButton.interactable = true;
                rewardText.enabled = true;
                buttonObject.SetActive(true);
                coinText.SetActive(true);
            }
            else
            {
                rewardText.text = "Collected";
                rewardButton.interactable = false;
                rewardText.enabled = false;
                buttonObject.SetActive(false);
                coinText.SetActive(false);
            }
        }
    
        public void CollectReward()
        {
            if (IsRewardAvailable())
            {
                // Give the reward
                Coin.coins += coinsPerReward;
    
                // Update the last reward date
                lastRewardDate = DateTime.Today;
                PlayerPrefs.SetString("LastRewardDate", lastRewardDate.ToString("yyyyMMdd"));
    
                // Disable the button
                rewardButton.interactable = false;
                rewardText.text = "Collected";
                coinText.SetActive(false);
    
                //audio and vfx
                gameManager.audioSource.PlayOneShot(dailyRewardSound);
                confettiParticle.Play();
                animator.Play(dailyRewardEnd);
            }
        }
    
        private bool IsRewardAvailable()
        {
            // Check if today is a new day
            DateTime today = DateTime.Today;
            if (lastRewardDate < today)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
}
