using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

namespace RollOn.Scripts.Ads{
    
    public class BannerAds : MonoBehaviour
    {
        public bool enableBannerAd = true;
        [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;

        //ADD YOUR OWN ID'S IN PRDUCTION
        [SerializeField] string _androidAdUnitId = "Banner_Android";
        [SerializeField] string _iOSAdUnitId = "Banner_iOS";

        string _adUnitId = null; // This will remain null for unsupported platforms.
    
        public AdsManager adsManager;
        public Transform settingsButton;
        public Transform coinDisplay;
    
        private float yPositionSettingsButton = 45f;    //75 works great on apk, 45 for editor
        private float yPositionCoinsDisplay = 45f;
    
    
        void Start()
        {
            // Get the Ad Unit ID for the current platform:
    #if UNITY_IOS
            _adUnitId = _iOSAdUnitId;
    #elif UNITY_ANDROID
            _adUnitId = _androidAdUnitId;
    #endif
            // Set the banner position:
            Advertisement.Banner.SetPosition(_bannerPosition);
    
            if (enableBannerAd == true && adsManager.enableAds == true)
            {
                SetYPositions();
                LoadBanner();
            }
        }
    
        // Implement a method to call when the Load Banner button is clicked:
        public void LoadBanner()
        {
            // Set up options to notify the SDK of load events:
            BannerLoadOptions options = new BannerLoadOptions
            {
                loadCallback = OnBannerLoaded,
                errorCallback = OnBannerError
            };
    
            // Load the Ad Unit with banner content:
            Advertisement.Banner.Load(_adUnitId, options);
        }
    
        // Implement code to execute when the loadCallback event triggers:
        void OnBannerLoaded()
        {
            Debug.Log("Banner loaded");
            ShowBannerAd();
        }
    
        // Implement code to execute when the load errorCallback event triggers:
        void OnBannerError(string message)
        {
            Debug.Log($"Banner Error: {message}");
            // Optionally execute additional code, such as attempting to load another ad.
        }
    
        // Implement a method to call when the Show Banner button is clicked:
        void ShowBannerAd()
        {
            // Set up options to notify the SDK of show events:
            BannerOptions options = new BannerOptions
            {
                clickCallback = OnBannerClicked,
                hideCallback = OnBannerHidden,
                showCallback = OnBannerShown
            };
    
            // Show the loaded Banner Ad Unit:
            Advertisement.Banner.Show(_adUnitId, options);
        }
    
        // Implement a method to call when the Hide Banner button is clicked:
        public void HideBannerAd()
        {
            // Hide the banner:
            Advertisement.Banner.Hide();
        }
    
        private void SetYPositions()
        {
            Vector3 settingsButtonPosition = settingsButton.position;
            settingsButton.position = new Vector3(settingsButtonPosition.x, settingsButtonPosition.y + yPositionSettingsButton, settingsButtonPosition.z);
    
            Vector3 coinDisplayPosition = coinDisplay.position;
            coinDisplay.position = new Vector3(coinDisplayPosition.x, coinDisplayPosition.y + yPositionCoinsDisplay, coinDisplayPosition.z);
        }
    
        public void ResetPositions()
        {
            Vector3 settingsButtonDefaultPosition = settingsButton.position;
            settingsButton.position = new Vector3(settingsButtonDefaultPosition.x, settingsButtonDefaultPosition.y - yPositionSettingsButton, settingsButtonDefaultPosition.z);
    
            Vector3 coinDisplayDefaultPosition = coinDisplay.position;
            coinDisplay.position = new Vector3(coinDisplayDefaultPosition.x, coinDisplayDefaultPosition.y - yPositionCoinsDisplay, coinDisplayDefaultPosition.z);
        }
    
    
    
        void OnBannerClicked() { }
        void OnBannerShown() { }
        void OnBannerHidden() { }
    }
    
}
