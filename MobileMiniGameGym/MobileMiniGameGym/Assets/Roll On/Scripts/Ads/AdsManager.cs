using UnityEngine;
using UnityEngine.Advertisements;

namespace RollOn.Scripts.Ads{
    
    public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
    {
        public bool enableAds;
        [SerializeField] string _androidGameId;
        [SerializeField] string _iOSGameId;
        [SerializeField] bool _testMode = true;
        private string _gameId;
        public BannerAds bannerAds;
    
        private const string NoAdsKey = "NoAds";
    
        void Awake()
        {
            LoadNoAdsStatus();
            InitializeAds();
        }
    
        public void InitializeAds()
        {
            if (!enableAds) return;
    
    #if UNITY_IOS
            _gameId = _iOSGameId;
    #elif UNITY_ANDROID
            _gameId = _androidGameId;
    #elif UNITY_EDITOR
            _gameId = _androidGameId; //Only for testing the functionality in the Editor
    #endif
            if (!Advertisement.isInitialized && Advertisement.isSupported)
            {
                Advertisement.Initialize(_gameId, _testMode, this);
            }
        }
    
        public void OnInitializationComplete()
        {
            Debug.Log("Unity Ads initialization complete.");
        }
    
        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
        }
    
        public void PurchaseNoAds()
        {
            enableAds = false;
            PlayerPrefs.SetInt(NoAdsKey, 1);
            PlayerPrefs.Save();
            bannerAds.HideBannerAd();
            bannerAds.ResetPositions();
        }
    
        private void LoadNoAdsStatus()
        {
            enableAds = PlayerPrefs.GetInt(NoAdsKey, 0) == 0;
        }
    
        public void ResetNoAdsStatus()
        {
            PlayerPrefs.DeleteKey(NoAdsKey);
            PlayerPrefs.Save();
            enableAds = true;
        }
    
        private void Start()
        {
            ResetNoAdsStatus();   //RESET THE NOADS PLAYERPREFS
        }
    
    }
    
}
