using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollOn.Scripts{
    
    public class ChangeColors : MonoBehaviour
    {
        public GameObject greenButton;
        public GameObject blueButton;
        public GameObject whiteSmokeButton;
        public GameObject purpleButton;
    
        public Material obstaclesMaterialColor;
        public Material groundMaterialColor;
        public Material skyboxGreen;
        public Material skyboxPurple;
        public Material skyboxBlue;
        public Material skyboxWhiteSmoke;
    
        public GameManager gameManager;
    
        public Button retryButton;
    
        public Image settingBtnOutline;
        public Image noAdsBtnOutline;
        public Image muteBtnOutline;
        public Image unMuteBtnOutline;
        public Image settingBtn;
        public Text noAdsTxt;
        public Image muteBtn;
        public Image unMuteBtn;
    
    
    
        [SerializeField]
        public Color UIColorBlack = new Color(38 / 255f, 38 / 255f, 50 / 255f, 1f);
    
        [SerializeField]
        public Color UIColorWhite = new Color(210 / 255f, 210 / 255f, 210 / 255f, 1f);
    
        [SerializeField]
        public Color fogGreen = new Color(4 / 255f, 162 / 255f, 129 / 255f, 1f);
    
        [SerializeField]
        public Color fogBlue = new Color(4 / 255f, 162 / 255f, 129 / 255f, 1f);
    
        [SerializeField]
        public Color fogWhite = new Color(4 / 255f, 162 / 255f, 129 / 255f, 1f);
    
        [SerializeField]
        public Color fogPurple = new Color(158 / 255f, 43 / 255f, 172 / 255f, 1f);
    
        [SerializeField]
        public Color groundYellowGradientTop = new Color(199 / 255f, 202 / 255f, 22 / 255f, 1f);
    
        [SerializeField]
        public Color groundYellowGradientBottom = new Color(252 / 255f, 255 / 255f, 150 / 255f, 1f);
    
        [SerializeField]
        public Color groundBlueGradientTop = new Color(199 / 255f, 202 / 255f, 22 / 255f, 1f);
    
        [SerializeField]
        public Color groundBlueGradientBottom = new Color(252 / 255f, 255 / 255f, 150 / 255f, 1f);
    
        [SerializeField]
        public Color groundTopAndBottomBlack = new Color(31 / 255f, 29 / 255f, 31 / 255f, 1f);
    
        [SerializeField]
        public Color groundWhiteSmokeGradientTop = new Color(199 / 255f, 202 / 255f, 22 / 255f, 1f);
    
        [SerializeField]
        public Color groundWhiteSmokeGradientBottom = new Color(252 / 255f, 255 / 255f, 150 / 255f, 1f);
    
        [SerializeField]
        public Color obstaclesGray = new Color(135 / 255f, 133 / 255f, 133 / 255f, 1f);
    
        [SerializeField]
        public Color obstaclesWhite = new Color(231 / 255f, 231 / 255f, 231 / 255f, 1f);
    
        [SerializeField]
        public Color obstaclesTeal = new Color(231 / 255f, 231 / 255f, 231 / 255f, 1f);
    
        [SerializeField]
        public Color UIColor = new Color(231 / 255f, 231 / 255f, 231 / 255f, 1f);
    
        [SerializeField]
        public Color BlackBlack = new Color(231 / 255f, 231 / 255f, 231 / 255f, 1f);
    
        [SerializeField]
        public Color WhiteWhite = new Color(231 / 255f, 231 / 255f, 231 / 255f, 1f);
    
        [SerializeField]
        public Color TransparentWhite = new Color(231 / 255f, 231 / 255f, 231 / 255f, 1f);
    
        public void ChangeToBlue()
        {
            obstaclesMaterialColor.color = obstaclesTeal;
            groundMaterialColor.SetColor("_Color", groundBlueGradientTop);
            groundMaterialColor.SetColor("_Color1", groundBlueGradientBottom);
            RenderSettings.fogColor = fogBlue;
            RenderSettings.skybox = skyboxBlue;
    
            purpleButton.SetActive(false);
            greenButton.SetActive(false);
            blueButton.SetActive(true);
            whiteSmokeButton.SetActive(false);
    
            if (gameManager.tapToPlayText != null)
            {
                gameManager.tapToPlayText.color = UIColor;
            }
            if (gameManager.coinsText != null)
            {
                gameManager.coinsText.color = UIColor;
            }
            retryButton.image.color = UIColor;
          
    
    
            //PLAYERPREFS
            PlayerPrefs.SetInt("ChangeToWhiteSmoke", 0);
            PlayerPrefs.SetInt("ChangeToGreen", 0);
            PlayerPrefs.SetInt("ChangeToPurple", 0);
            PlayerPrefs.SetInt("ChangeToBlue", 1);
            PlayerPrefs.Save();
        }
    
        public void ChangeToPurple()
        {
            obstaclesMaterialColor.color = obstaclesWhite;
            groundMaterialColor.SetColor("_Color", groundTopAndBottomBlack);
            groundMaterialColor.SetColor("_Color1", groundTopAndBottomBlack);
            RenderSettings.fogColor = fogPurple;
            RenderSettings.skybox = skyboxPurple;
    
            purpleButton.SetActive(true);
            greenButton.SetActive(false);
            blueButton.SetActive(false);
            whiteSmokeButton.SetActive(false);
    
            if (gameManager.tapToPlayText != null)
            {
                gameManager.tapToPlayText.color = obstaclesWhite;
            }
            if (gameManager.coinsText != null)
            {
                gameManager.coinsText.color = obstaclesWhite;
            }
           
            retryButton.image.color = UIColor;
    
    
            if (settingBtnOutline != null)
            {
                settingBtnOutline.color = UIColorBlack;
            }
            if (noAdsBtnOutline != null)
            {
                noAdsBtnOutline.color = UIColorBlack;
            }
            if (muteBtnOutline != null)
            {
                muteBtnOutline.color = UIColorBlack;
            }
            if (unMuteBtnOutline != null)
            {
                unMuteBtnOutline.color = UIColorBlack;
            }
            if (settingBtn != null)
            {
                settingBtn.color = WhiteWhite;
            }
            if (noAdsTxt != null)
            {
                noAdsTxt.color = UIColorWhite;
            }
            if (muteBtn != null)
            {
                muteBtn.color = WhiteWhite;
            }
            if (unMuteBtn != null)
            {
                unMuteBtn.color = WhiteWhite;
            }
    
    
    
            //PLAYERPREFS
            PlayerPrefs.SetInt("ChangeToWhiteSmoke", 0);
            PlayerPrefs.SetInt("ChangeToGreen", 0);
            PlayerPrefs.SetInt("ChangeToPurple", 1);
            PlayerPrefs.SetInt("ChangeToBlue", 0);
            PlayerPrefs.Save();
        }
    
        public void ChangeToGreen()
        {
            obstaclesMaterialColor.color = obstaclesGray;
            groundMaterialColor.SetColor("_Color", groundYellowGradientTop);
            groundMaterialColor.SetColor("_Color1", groundYellowGradientBottom);
            RenderSettings.fogColor = fogGreen;
            RenderSettings.skybox = skyboxGreen;
    
            purpleButton.SetActive(false);
            greenButton.SetActive(true);
            blueButton.SetActive(false);
            whiteSmokeButton.SetActive(false);
    
            if (gameManager.tapToPlayText != null)
            {
                gameManager.tapToPlayText.color = UIColor;
            }
            if (gameManager.coinsText != null)
            {
                gameManager.coinsText.color = UIColor;
            }
            retryButton.image.color = UIColor;
            retryButton.image.color = UIColor;
    
            if (settingBtnOutline != null)
                settingBtnOutline.color = TransparentWhite;
    
            if (noAdsBtnOutline != null)
                noAdsBtnOutline.color = UIColorBlack;
    
            if (muteBtnOutline != null)
    
                muteBtnOutline.color = TransparentWhite;
            if (unMuteBtnOutline != null)
                unMuteBtnOutline.color = TransparentWhite;
    
            if (settingBtn != null)
                settingBtn.color = BlackBlack;
    
            if (noAdsTxt != null)
                noAdsTxt.color = BlackBlack;
    
            if (muteBtn != null)
                muteBtn.color = BlackBlack;
    
            if (unMuteBtn != null)
                unMuteBtn.color = BlackBlack;
    
    
    
    
            //PLAYERPREFS
            PlayerPrefs.SetInt("ChangeToWhiteSmoke", 0);
            PlayerPrefs.SetInt("ChangeToGreen", 1);
            PlayerPrefs.SetInt("ChangeToPurple", 0);
            PlayerPrefs.SetInt("ChangeToBlue", 0);
            PlayerPrefs.Save();
        }
    
    
        public void ChangeToWhiteSmoke()
        {
            obstaclesMaterialColor.color = groundTopAndBottomBlack;
            groundMaterialColor.SetColor("_Color", groundWhiteSmokeGradientTop);
            groundMaterialColor.SetColor("_Color1", groundWhiteSmokeGradientBottom);
            RenderSettings.fogColor = fogWhite;
            RenderSettings.skybox = skyboxWhiteSmoke;
    
            purpleButton.SetActive(false);
            greenButton.SetActive(false);
            blueButton.SetActive(false);
            whiteSmokeButton.SetActive(true);
    
            if (gameManager.tapToPlayText != null)
            {
                gameManager.tapToPlayText.color = UIColor;
            }
            if (gameManager.coinsText != null)
            {
                gameManager.coinsText.color = UIColor;
            }
            retryButton.image.color = UIColor;
           
    
            //PLAYERPREFS
            PlayerPrefs.SetInt("ChangeToWhiteSmoke", 1);
            PlayerPrefs.SetInt("ChangeToGreen", 0);
            PlayerPrefs.SetInt("ChangeToPurple", 0);
            PlayerPrefs.SetInt("ChangeToBlue", 0);
            PlayerPrefs.Save();
        }
    
        public void Start()
        {
            if (PlayerPrefs.GetInt("ChangeToGreen", 0) == 1)
            {
                ChangeToGreen();
            }
            if (PlayerPrefs.GetInt("ChangeToWhiteSmoke", 0) == 1)
            {
                ChangeToWhiteSmoke();
            }
            if (PlayerPrefs.GetInt("ChangeToBlue", 0) == 1)
            {
                ChangeToBlue();
            }
            if (PlayerPrefs.GetInt("ChangeToPurple", 0) == 1)
            {
                ChangeToPurple();
            }
    
            //If NULL
            if (!PlayerPrefs.HasKey("ChangeToGreen") && !PlayerPrefs.HasKey("ChangeToWhiteSmoke")
                 && !PlayerPrefs.HasKey("ChangeToBlue") && !PlayerPrefs.HasKey("ChangeToPurple"))
            {
                ChangeToGreen();
            }
    
        }
    }
    
}
