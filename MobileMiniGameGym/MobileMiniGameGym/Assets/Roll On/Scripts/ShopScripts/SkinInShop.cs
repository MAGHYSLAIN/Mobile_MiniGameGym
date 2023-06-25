using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RollOn.Scripts.ShopScripts{
    
    public class SkinInShop : MonoBehaviour
    {
        [SerializeField] private SSkinInfo skinInfo;
        public SSkinInfo _skinInfo { get { return skinInfo; } }
    
        [SerializeField] private TextMeshProUGUI buttonText;
        [SerializeField] private Image skinImage;
    
        private Image skinOutline;
        [SerializeField] private Color skinColor = Color.black;
        [SerializeField] private Color skinColorWhite = Color.white;
    
        [SerializeField] private bool isSkinUnlocked;//SFD
        [SerializeField] private bool isFreeSkin;
    
        private SkinManager skinManager;
    
        public GameObject coinDisplay;
        public GameObject questionMark;
        public GameObject lockedOutline;
        public Image outline;
    
        public Sprite questionMarkSprite;
    
    
        private void Awake()
        {
            //PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 0);                 //RESET THE SHOP
                                                                                
            // Set the skin sprite
            skinImage.sprite = skinInfo._skinSprite;
    
    
    
            if (isFreeSkin)
            {
                if (PlayerMoney.Instance.TryRemoveMoney(0))
                {
                    PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);
                }
            }
    
            IsSkinUnlocked();
        }
    
        private void IsSkinUnlocked()
        {
            if (PlayerPrefs.GetInt(skinInfo._skinID.ToString()) == 1)
            {
                //Item bought 
                isSkinUnlocked = true;
    
                Color imageColor = skinImage.color;
                imageColor.a = 1f;
                skinImage.color = imageColor;
    
                buttonText.text = null;
                coinDisplay.SetActive(false);
                questionMark.SetActive(false);
                lockedOutline.SetActive(false);
    
    
            }
            else
            {
                //Item not bought
                buttonText.text = skinInfo._skinPrice.ToString();
               
                Color imageColor = skinImage.color;
                imageColor.a = 0f;
                skinImage.color = imageColor;
                questionMark.SetActive(true);
                lockedOutline.SetActive(true);
    
    
            }
        }
    
        public void OnButtonPress()
        {
            if (isSkinUnlocked)
            {
                //equip
                SkinManager.Instance.EquipSkin(this);
    
                // Get the Ball_Mat material from the SSkinInfo scriptable object
                Material ballMaterial = skinInfo._skinMaterial;
    
    
                if (skinInfo._skinID.ToString() == "red" || skinInfo._skinID.ToString() == "blue")
                {
                    // Set the color of the material to the value of the skinColor property
                    ballMaterial.color = skinInfo._skinColor;
                }
               
    
                Material particleMaterial = skinInfo._particleMaterial;
                particleMaterial.color = skinInfo._skinColor;
    
                Color emissionColor = skinInfo._skinColor * 0.5f;
                ballMaterial.SetColor("_EmissionColor", emissionColor);
            }
            else
            {
                //buy
                if (PlayerMoney.Instance.TryRemoveMoney(skinInfo._skinPrice))
                {
                    PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);
                    PlayerPrefs.Save();
                    IsSkinUnlocked();
    
                   
                    skinManager.ConfettiBurstPlay();
                    SkinManager.Instance.EquipSkin(this);
    
    
                }
                else
                {
                    skinManager.ErrorSoundPlay();
                }
            }
        }
    
        private void Start()
        {
    
            GameObject shopManagerObject = GameObject.Find("ShopManager");
            if (shopManagerObject == null)
            {
                Debug.LogError("SkinManager object not found!");
                return;
            }
    
            skinManager = shopManagerObject.GetComponent<SkinManager>();
            if (skinManager == null)
            {
                Debug.LogError("SkinManager component not found!");
            }
        }
    
        private void UnHighlightSkin()
        {
            outline.color = skinColorWhite;
        }
    
        private void HighLightSkin()
        {
            outline.color = skinColor;
        }
    
        public void HighlightSkinInShop()
        {
            // Get all SkinInShop components in the scene
            SkinInShop[] allSkins = FindObjectsOfType<SkinInShop>();
    
            // Unhighlight all the skins except for this one
            foreach (SkinInShop skin in allSkins)
            {
                if (skin == this)
                {
                    skin.HighLightSkin();
                }
                else
                {
                    skin.UnHighlightSkin();
                }
            }
        }
    }
}