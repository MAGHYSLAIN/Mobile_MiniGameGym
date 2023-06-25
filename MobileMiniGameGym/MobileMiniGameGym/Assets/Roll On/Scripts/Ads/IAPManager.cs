//IF YOU WANT TO USE IAP UNCOMMENT THIS IN PRODUCTION

//using System;
//using UnityEngine;
//using UnityEngine.Purchasing;

//namespace RollOn.Scripts.Ads{
    
//    public class IAPManager : MonoBehaviour, IStoreListener
//    {
//        private static IStoreController storeController;
//        private static IExtensionProvider storeExtensionProvider;
    
//        public const string noAdsProductId = "no_ads";   //REPLACE THIS WITH YOUR OWN ID
    
//        void Start()
//        {
//            if (storeController == null)
//            {
//                InitializePurchasing();
//            }
//        }
    
//        public void InitializePurchasing()
//        {
//            if (IsInitialized())
//            {
//                return;
//            }
    
//            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
    
//            builder.AddProduct(noAdsProductId, ProductType.NonConsumable);
    
//            UnityPurchasing.Initialize(this, builder);
//        }
    
//        private bool IsInitialized()
//        {
//            return storeController != null && storeExtensionProvider != null;
//        }
    
//        public void BuyNoAds()
//        {
//            BuyProductID(noAdsProductId);
//        }
    
//        void BuyProductID(string productId)
//        {
//            if (IsInitialized())
//            {
//                Product product = storeController.products.WithID(productId);
    
//                if (product != null && product.availableToPurchase)
//                {
//                    storeController.InitiatePurchase(product);
//                }
//                else
//                {
//                    Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
//                }
//            }
//            else
//            {
//                Debug.Log("BuyProductID FAIL. Not initialized.");
//            }
//        }
    
//        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
//        {
//            storeController = controller;
//            storeExtensionProvider = extensions;
//        }
    
//        public void OnInitializeFailed(InitializationFailureReason error)
//        {
//            Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
//        }
    
//        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
//        {
//            if (String.Equals(args.purchasedProduct.definition.id, noAdsProductId, StringComparison.Ordinal))
//            {
//                AdsManager adsManager = FindObjectOfType<AdsManager>();
//                if (adsManager != null)
//                {
//                    adsManager.PurchaseNoAds();
//                }
//            }
//            else
//            {
//                Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
//            }
    
//            return PurchaseProcessingResult.Complete;
//        }
    
//        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
//        {
//            Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
//        }
    
//        public void OnInitializeFailed(InitializationFailureReason error, string message)
//        {
//            Debug.LogError($"In-App Purchase Initialization Failed: {error} - {message}");
//        }
    
//    }
    
//}
