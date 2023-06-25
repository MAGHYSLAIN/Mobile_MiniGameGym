using UnityEngine;
using UnityEngine.Advertisements;

namespace RollOn.Scripts.Ads{
    
    public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        [SerializeField] string _androidAdUnitId = "Interstitial_Android";
        [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
        string _adUnitId;
    
        public GameManager gameManager;
        public AdsManager adsManager;
    
        [SerializeField, Range(1, 10), Tooltip("Play interstitial ad every X number of restarts")]
        public int playInterstitialEveryXRestarts = 3;
    
        void Update()
        {
            if(gameManager.restartCount == playInterstitialEveryXRestarts && adsManager.enableAds == true)
            {
                ShowAd();
                gameManager.restartCount = 0;
            }
        }
    
        void Awake()
        {
            // Get the Ad Unit ID for the current platform:
            _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
                ? _iOsAdUnitId
                : _androidAdUnitId;
        }
    
        void Start()
        {
            LoadAd();
        }
    
        public void LoadAd()
        {
            Debug.Log("Loading Ad: " + _adUnitId);
            Advertisement.Load(_adUnitId, this);
        }
    
        public void ShowAd()
        {
            Debug.Log("Showing Ad: " + _adUnitId);
            Advertisement.Show(_adUnitId, this);
        }
    
        public void OnUnityAdsAdLoaded(string adUnitId)
        {
        }
    
        public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
        {
            Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
        }
    
        public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
        {
            Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        }
    
        public void OnUnityAdsShowStart(string adUnitId) { }
        public void OnUnityAdsShowClick(string adUnitId) { }
        public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState) { }
    }
    
}
