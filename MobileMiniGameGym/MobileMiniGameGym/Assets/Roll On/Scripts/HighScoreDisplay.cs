using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace RollOn.Scripts{
    
    public class HighScoreDisplay : MonoBehaviour
    {
    
        public GameManager gameManager;
        public TMP_Text highscoreText;
    
    
        // Update is called once per frame
        void Update()
        {
            highscoreText.text = gameManager.highScore.ToString();
        }
    }
    
}
