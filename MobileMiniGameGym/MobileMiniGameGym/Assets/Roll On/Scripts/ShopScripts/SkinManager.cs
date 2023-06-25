using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollOn.Scripts.ShopScripts{
    
    public class SkinManager : MonoBehaviour
    {
      
        public static SkinManager Instance;
        public static Sprite equippedSkin { get; private set; }
    
        [SerializeField] private SSkinInfo[] allSkins;
        private const string skinPref = "skinPref";
    
        [SerializeField] private Transform skinsInShopPanelsParent;
        [SerializeField] private List<SkinInShop> skinsInShopPanels = new List<SkinInShop>();//SFD
    
        private Button currentlyEquippedSkinButton;
    
        public ParticleSystem confettiParticle;
        public AudioClip purchaseSound;
        public AudioClip buttonSound;
        public AudioClip errorSound;
        private AudioSource audioSource;
    
        public Material ball_Mat;
        public Material FX_base;
        public Material rainbow_Mat;
        public MeshRenderer playerModelRenderer;
        public Texture2D poolBallTexture;
    
        public MeshRenderer beachBallMesh;
        public MeshRenderer basketBallMesh;
        public GameObject atomSkinObj;
        public GameObject bombSkinObj;
        public MeshRenderer eyeBallMesh;
        public MeshRenderer golfBallMesh;
        public MeshRenderer soccerBallMesh;
        public MeshRenderer spikeBallMesh;
        public MeshRenderer tennisBallMesh;
        public MeshRenderer watermelonBallMesh;
        public MeshRenderer wheelBallMesh;
        public MeshRenderer woodenBallMesh;
        public MeshRenderer playerModelMesh;
    
    
        public ParticleSystem trailFX;
        public ParticleSystem deathFX;
        public ParticleSystem respawnFX;
    
    
        public bool colorSkin;
        public bool beachSkin;
        public bool basketSkin;
        public bool atomSkin;
        public bool bombSkin;
        public bool eyeSkin;
        public bool golfSkin;
        public bool soccerSkin;
        public bool spikeSkin;
        public bool tennisSkin;
        public bool watermelonSkin;
        public bool wheelSkin;
        public bool woodenSkin;
    
        private void Awake()
        {
            
                Instance = this;
               
               
    
            foreach (Transform s in skinsInShopPanelsParent)
            {
                if (s.TryGetComponent(out SkinInShop skinInShop))
                    skinsInShopPanels.Add(skinInShop);
            }
    
            EquipPreviousSkin();
    
    
            SkinInShop skinEquippedPanel = Array.Find(skinsInShopPanels.ToArray(), dummyFind => dummyFind._skinInfo._skinSprite == equippedSkin);
            //currentlyEquippedSkinButton = skinEquippedPanel.GetComponentInChildren<Button>();
            //currentlyEquippedSkinButton.interactable = false;
    
            if (skinEquippedPanel != null)
            {
                currentlyEquippedSkinButton = skinEquippedPanel.GetComponentInChildren<Button>();
                if (currentlyEquippedSkinButton != null)
                {
                    currentlyEquippedSkinButton.interactable = false;
                }
            }
            }
        
        public void EquipPreviousSkin()
        {
            string lastSkinUsed = PlayerPrefs.GetString(skinPref, SSkinInfo.SkinIDs.red.ToString());
            SkinInShop skinEquippedPanel = Array.Find(skinsInShopPanels.ToArray(), dummyFind => dummyFind._skinInfo._skinID.ToString() == lastSkinUsed);
            EquipSkin(skinEquippedPanel);
        }
    
        public void EquipSkin(SkinInShop skinInfoInShop)
        {
    
            if (skinInfoInShop != null)
            {
                skinInfoInShop.HighlightSkinInShop();
                equippedSkin = skinInfoInShop._skinInfo._skinSprite;
                PlayerPrefs.SetString(skinPref, skinInfoInShop._skinInfo._skinID.ToString());
    
                if (currentlyEquippedSkinButton != null)
                    currentlyEquippedSkinButton.interactable = true;
    
                currentlyEquippedSkinButton = skinInfoInShop.GetComponentInChildren<Button>();
                currentlyEquippedSkinButton.interactable = false;
    
    
                // Get the Ball_Mat material from the SSkinInfo scriptable object
                Material ballMaterial = skinInfoInShop._skinInfo._skinMaterial;
    
                ballMaterial.color = skinInfoInShop._skinInfo._skinColor;
    
                Material particleMaterial = skinInfoInShop._skinInfo._particleMaterial;
    
                particleMaterial.color = skinInfoInShop._skinInfo._skinColor;
    
                Color emissionColor = skinInfoInShop._skinInfo._skinColor * 0.5f;
                ballMaterial.SetColor("_EmissionColor", emissionColor);
    
    
                // Debug.log the skin id of the currently equipped item
                if (skinInfoInShop._skinInfo._skinID.ToString() == PlayerPrefs.GetString(skinPref, SSkinInfo.SkinIDs.red.ToString()))
                {
                    Debug.Log("Currently equipped item skin id: " + skinInfoInShop._skinInfo._skinID.ToString());
                }
    
                if (skinInfoInShop._skinInfo._skinID.ToString() == "blue")
                {
                    colorSkin = true;
                    beachSkin = false;
                    basketSkin = false;
                    atomSkin = false;
                    bombSkin = false;
                    eyeSkin = false;
                    golfSkin = false;
                    soccerSkin = false;
                    spikeSkin = false;
                    tennisSkin = false;
                    watermelonSkin = false;
                    wheelSkin = false;
                    woodenSkin = false;
    
    
                    ball_Mat.mainTexture = null;
                    beachBallMesh.enabled = false;
                    playerModelMesh.enabled = true;
                    playerModelRenderer.material = ball_Mat;
    
                     
                    basketBallMesh.enabled = false;
                    atomSkinObj.SetActive(false);
                    bombSkinObj.SetActive(false);
                    eyeBallMesh.enabled = false;
                    golfBallMesh.enabled = false;
                    soccerBallMesh.enabled = false;
                    spikeBallMesh.enabled = false;
                    tennisBallMesh.enabled = false;
                    watermelonBallMesh.enabled = false;
                    wheelBallMesh.enabled = false;
                    woodenBallMesh.enabled = false;
        
    
        Renderer renderer = trailFX.GetComponent<Renderer>();
                    renderer.material = FX_base;
    
                    if (deathFX != null)
                    {
                        Renderer[] renderers = deathFX.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in renderers)
                        {
                            r.material = FX_base;
                        }
                    }
    
                    if (respawnFX != null)
                    {
                        Renderer renderer3 = respawnFX.GetComponent<Renderer>();
                        if (renderer3 != null)
                            renderer3.material = FX_base;
                    }
    
                }
    
                if (skinInfoInShop._skinInfo._skinID.ToString() == "red")
                {
                    colorSkin = true;
                    beachSkin = false;
                    basketSkin = false;
                    atomSkin = false;
                    bombSkin = false;
                    eyeSkin = false;
                    golfSkin = false;
                    soccerSkin = false;
                    spikeSkin = false;
                    tennisSkin = false;
                    watermelonSkin = false;
                    wheelSkin = false;
                    woodenSkin = false;
    
                    ball_Mat.mainTexture = null;
                    beachBallMesh.enabled = false;
                    playerModelMesh.enabled = true;
                    playerModelRenderer.material = ball_Mat;
    
                    basketBallMesh.enabled = false;
                    atomSkinObj.SetActive(false);
                    bombSkinObj.SetActive(false);
                    eyeBallMesh.enabled = false;
                    golfBallMesh.enabled = false;
                    soccerBallMesh.enabled = false;
                    spikeBallMesh.enabled = false;
                    tennisBallMesh.enabled = false;
                    watermelonBallMesh.enabled = false;
                    wheelBallMesh.enabled = false;
                    woodenBallMesh.enabled = false;
    
                    Renderer renderer = trailFX.GetComponent<Renderer>();
                    renderer.material = FX_base;
    
                    if (deathFX != null)
                    {
                        Renderer[] renderers = deathFX.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in renderers)
                        {
                            r.material = FX_base;
                        }
                    }
    
                    if (respawnFX != null)
                    {
                        Renderer renderer3 = respawnFX.GetComponent<Renderer>();
                        if (renderer3 != null)
                            renderer3.material = FX_base;
                    }
                }
    
                if (skinInfoInShop._skinInfo._skinID.ToString() == "black")
                {
                    colorSkin = true;
                    beachSkin = false;
                    basketSkin = false;
                    atomSkin = false;
                    bombSkin = false;
                    eyeSkin = false;
                    golfSkin = false;
                    soccerSkin = false;
                    spikeSkin = false;
                    tennisSkin = false;
                    watermelonSkin = false;
                    wheelSkin = false;
                    woodenSkin = false;
    
                    beachBallMesh.enabled = false;
                    playerModelMesh.enabled = true;
                   
                    ball_Mat.mainTexture = poolBallTexture;
                    ball_Mat.color = Color.white;
                    playerModelRenderer.material = ball_Mat;
    
                    basketBallMesh.enabled = false;
                    atomSkinObj.SetActive(false);
                    bombSkinObj.SetActive(false);
                    eyeBallMesh.enabled = false;
                    golfBallMesh.enabled = false;
                    soccerBallMesh.enabled = false;
                    spikeBallMesh.enabled = false;
                    tennisBallMesh.enabled = false;
                    watermelonBallMesh.enabled = false;
                    wheelBallMesh.enabled = false;
                    woodenBallMesh.enabled = false;
    
                    Renderer renderer = trailFX.GetComponent<Renderer>();
                    renderer.material = FX_base;
    
                    if (deathFX != null)
                    {
                        Renderer[] renderers = deathFX.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in renderers)
                        {
                            r.material = FX_base;
                        }
                    }
    
                    if (respawnFX != null)
                    {
                        Renderer renderer3 = respawnFX.GetComponent<Renderer>();
                        if (renderer3 != null)
                            renderer3.material = FX_base;
                    }
                }
    
    
                if (skinInfoInShop._skinInfo._skinID.ToString() == "beach")
                {
                    colorSkin = false;
                    beachSkin = true;
                    basketSkin = false;
                    atomSkin = false;
                    bombSkin = false;
                    eyeSkin = false;
                    golfSkin = false;
                    soccerSkin = false;
                    spikeSkin = false;
                    tennisSkin = false;
                    watermelonSkin = false;
                    wheelSkin = false;
                    woodenSkin = false;
    
                    beachBallMesh.enabled = true;
                    playerModelMesh.enabled = false;
                    playerModelRenderer.material = ball_Mat;
    
                    basketBallMesh.enabled = false;
                    atomSkinObj.SetActive(false);
                    bombSkinObj.SetActive(false);
                    eyeBallMesh.enabled = false;
                    golfBallMesh.enabled = false;
                    soccerBallMesh.enabled = false;
                    spikeBallMesh.enabled = false;
                    tennisBallMesh.enabled = false;
                    watermelonBallMesh.enabled = false;
                    wheelBallMesh.enabled = false;
                    woodenBallMesh.enabled = false;
    
                    Renderer renderer = trailFX.GetComponent<Renderer>();
                    renderer.material = FX_base;
    
                    if (deathFX != null)
                    {
                        Renderer[] renderers = deathFX.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in renderers)
                        {
                            r.material = FX_base;
                        }
                    }
    
                    if (respawnFX != null)
                    {
                        Renderer renderer3 = respawnFX.GetComponent<Renderer>();
                        if (renderer3 != null)
                            renderer3.material = FX_base;
                    }
                }
    
                if (skinInfoInShop._skinInfo._skinID.ToString() == "rainbow")
                {
                    colorSkin = true;
                    beachSkin = false;
                    basketSkin = false;
                    atomSkin = false;
                    bombSkin = false;
                    eyeSkin = false;
                    golfSkin = false;
                    soccerSkin = false;
                    spikeSkin = false;
                    tennisSkin = false;
                    watermelonSkin = false;
                    wheelSkin = false;
                    woodenSkin = false;
    
    
                    ball_Mat.mainTexture = null;
                    beachBallMesh.enabled = false;
                    playerModelMesh.enabled = true;
    
                    playerModelRenderer.material = rainbow_Mat;
    
                    basketBallMesh.enabled = false;
                    atomSkinObj.SetActive(false);
                    bombSkinObj.SetActive(false);
                    eyeBallMesh.enabled = false;
                    golfBallMesh.enabled = false;
                    soccerBallMesh.enabled = false;
                    spikeBallMesh.enabled = false;
                    tennisBallMesh.enabled = false;
                    watermelonBallMesh.enabled = false;
                    wheelBallMesh.enabled = false;
                    woodenBallMesh.enabled = false;
    
                    Renderer renderer = trailFX.GetComponent<Renderer>();
                    renderer.material = rainbow_Mat;
    
                    if (deathFX != null)
                    {
                        Renderer[] renderers = deathFX.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in renderers)
                        {
                            r.material = rainbow_Mat;
                        }
                    }
    
                    if (respawnFX != null)
                    {
                        Renderer renderer3 = respawnFX.GetComponent<Renderer>();
                        if (renderer3 != null)
                            renderer3.material = rainbow_Mat;
                    }
                }
    
                if (skinInfoInShop._skinInfo._skinID.ToString() == "basket")
                {
                    colorSkin = false;
                    beachSkin = false;
                    basketSkin = true;
                    atomSkin = false;
                    bombSkin = false;
                    eyeSkin = false;
                    golfSkin = false;
                    soccerSkin = false;
                    spikeSkin = false;
                    tennisSkin = false;
                    watermelonSkin = false;
                    wheelSkin = false;
                    woodenSkin = false;
    
                    beachBallMesh.enabled = false;
                    playerModelMesh.enabled = false;
                    playerModelRenderer.material = ball_Mat;
    
                    basketBallMesh.enabled = true;
                    atomSkinObj.SetActive(false);
                    bombSkinObj.SetActive(false);
                    eyeBallMesh.enabled = false;
                    golfBallMesh.enabled = false;
                    soccerBallMesh.enabled = false;
                    spikeBallMesh.enabled = false;
                    tennisBallMesh.enabled = false;
                    watermelonBallMesh.enabled = false;
                    wheelBallMesh.enabled = false;
                    woodenBallMesh.enabled = false;
    
                    Renderer renderer = trailFX.GetComponent<Renderer>();
                    renderer.material = FX_base;
    
                    if (deathFX != null)
                    {
                        Renderer[] renderers = deathFX.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in renderers)
                        {
                            r.material = FX_base;
                        }
                    }
    
                    if (respawnFX != null)
                    {
                        Renderer renderer3 = respawnFX.GetComponent<Renderer>();
                        if (renderer3 != null)
                            renderer3.material = FX_base;
                    }
                }
    
                if (skinInfoInShop._skinInfo._skinID.ToString() == "atom")
                {
                    colorSkin = false;
                    beachSkin = false;
                    basketSkin = false;
                    atomSkin = true;
                    bombSkin = false;
                    eyeSkin = false;
                    golfSkin = false;
                    soccerSkin = false;
                    spikeSkin = false;
                    tennisSkin = false;
                    watermelonSkin = false;
                    wheelSkin = false;
                    woodenSkin = false;
    
                    beachBallMesh.enabled = false;
                    playerModelMesh.enabled = false;
                    playerModelRenderer.material = ball_Mat;
    
                    basketBallMesh.enabled = false;
                    atomSkinObj.SetActive(true);
                    bombSkinObj.SetActive(false);
                    eyeBallMesh.enabled = false;
                    golfBallMesh.enabled = false;
                    soccerBallMesh.enabled = false;
                    spikeBallMesh.enabled = false;
                    tennisBallMesh.enabled = false;
                    watermelonBallMesh.enabled = false;
                    wheelBallMesh.enabled = false;
                    woodenBallMesh.enabled = false;
    
                    Renderer renderer = trailFX.GetComponent<Renderer>();
                    renderer.material = FX_base;
    
                    if (deathFX != null)
                    {
                        Renderer[] renderers = deathFX.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in renderers)
                        {
                            r.material = FX_base;
                        }
                    }
    
                    if (respawnFX != null)
                    {
                        Renderer renderer3 = respawnFX.GetComponent<Renderer>();
                        if (renderer3 != null)
                            renderer3.material = FX_base;
                    }
                }
    
                if (skinInfoInShop._skinInfo._skinID.ToString() == "bomb")
                {
                    colorSkin = false;
                    beachSkin = false;
                    basketSkin = false;
                    atomSkin = false;
                    bombSkin = true;
                    eyeSkin = false;
                    golfSkin = false;
                    soccerSkin = false;
                    spikeSkin = false;
                    tennisSkin = false;
                    watermelonSkin = false;
                    wheelSkin = false;
                    woodenSkin = false;
    
                    beachBallMesh.enabled = false;
                    playerModelMesh.enabled = false;
                    playerModelRenderer.material = ball_Mat;
    
                    basketBallMesh.enabled = false;
                    atomSkinObj.SetActive(false);
                    bombSkinObj.SetActive(true);
                    eyeBallMesh.enabled = false;
                    golfBallMesh.enabled = false;
                    soccerBallMesh.enabled = false;
                    spikeBallMesh.enabled = false;
                    tennisBallMesh.enabled = false;
                    watermelonBallMesh.enabled = false;
                    wheelBallMesh.enabled = false;
                    woodenBallMesh.enabled = false;
    
                    Renderer renderer = trailFX.GetComponent<Renderer>();
                    renderer.material = FX_base;
    
                    if (deathFX != null)
                    {
                        Renderer[] renderers = deathFX.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in renderers)
                        {
                            r.material = FX_base;
                        }
                    }
    
                    if (respawnFX != null)
                    {
                        Renderer renderer3 = respawnFX.GetComponent<Renderer>();
                        if (renderer3 != null)
                            renderer3.material = FX_base;
                    }
                }
    
                if (skinInfoInShop._skinInfo._skinID.ToString() == "eye")
                {
                    colorSkin = false;
                    beachSkin = false;
                    basketSkin = false;
                    atomSkin = false;
                    bombSkin = false;
                    eyeSkin = true;
                    golfSkin = false;
                    soccerSkin = false;
                    spikeSkin = false;
                    tennisSkin = false;
                    watermelonSkin = false;
                    wheelSkin = false;
                    woodenSkin = false;
    
                    beachBallMesh.enabled = false;
                    playerModelMesh.enabled = false;
                    playerModelRenderer.material = ball_Mat;
    
                    basketBallMesh.enabled = false;
                    atomSkinObj.SetActive(false);
                    bombSkinObj.SetActive(false);
                    eyeBallMesh.enabled = true;
                    golfBallMesh.enabled = false;
                    soccerBallMesh.enabled = false;
                    spikeBallMesh.enabled = false;
                    tennisBallMesh.enabled = false;
                    watermelonBallMesh.enabled = false;
                    wheelBallMesh.enabled = false;
                    woodenBallMesh.enabled = false;
    
                    Renderer renderer = trailFX.GetComponent<Renderer>();
                    renderer.material = FX_base;
    
                    if (deathFX != null)
                    {
                        Renderer[] renderers = deathFX.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in renderers)
                        {
                            r.material = FX_base;
                        }
                    }
    
                    if (respawnFX != null)
                    {
                        Renderer renderer3 = respawnFX.GetComponent<Renderer>();
                        if (renderer3 != null)
                            renderer3.material = FX_base;
                    }
                }
    
                if (skinInfoInShop._skinInfo._skinID.ToString() == "golf")
                {
                    colorSkin = false;
                    beachSkin = false;
                    basketSkin = false;
                    atomSkin = false;
                    bombSkin = false;
                    eyeSkin = false;
                    golfSkin = true;
                    soccerSkin = false;
                    spikeSkin = false;
                    tennisSkin = false;
                    watermelonSkin = false;
                    wheelSkin = false;
                    woodenSkin = false;
    
                    beachBallMesh.enabled = false;
                    playerModelMesh.enabled = false;
                    playerModelRenderer.material = ball_Mat;
    
                    basketBallMesh.enabled = false;
                    atomSkinObj.SetActive(false);
                    bombSkinObj.SetActive(false);
                    eyeBallMesh.enabled = false;
                    golfBallMesh.enabled = true;
                    soccerBallMesh.enabled = false;
                    spikeBallMesh.enabled = false;
                    tennisBallMesh.enabled = false;
                    watermelonBallMesh.enabled = false;
                    wheelBallMesh.enabled = false;
                    woodenBallMesh.enabled = false;
    
                    Renderer renderer = trailFX.GetComponent<Renderer>();
                    renderer.material = FX_base;
    
                    if (deathFX != null)
                    {
                        Renderer[] renderers = deathFX.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in renderers)
                        {
                            r.material = FX_base;
                        }
                    }
    
                    if (respawnFX != null)
                    {
                        Renderer renderer3 = respawnFX.GetComponent<Renderer>();
                        if (renderer3 != null)
                            renderer3.material = FX_base;
                    }
                }
    
                if (skinInfoInShop._skinInfo._skinID.ToString() == "soccer")
                {
                    colorSkin = false;
                    beachSkin = false;
                    basketSkin = false;
                    atomSkin = false;
                    bombSkin = false;
                    eyeSkin = false;
                    golfSkin = false;
                    soccerSkin = true;
                    spikeSkin = false;
                    tennisSkin = false;
                    watermelonSkin = false;
                    wheelSkin = false;
                    woodenSkin = false;
    
                    beachBallMesh.enabled = false;
                    playerModelMesh.enabled = false;
                    playerModelRenderer.material = ball_Mat;
    
                    basketBallMesh.enabled = false;
                    atomSkinObj.SetActive(false);
                    bombSkinObj.SetActive(false);
                    eyeBallMesh.enabled = false;
                    golfBallMesh.enabled = false;
                    soccerBallMesh.enabled = true;
                    spikeBallMesh.enabled = false;
                    tennisBallMesh.enabled = false;
                    watermelonBallMesh.enabled = false;
                    wheelBallMesh.enabled = false;
                    woodenBallMesh.enabled = false;
    
                    Renderer renderer = trailFX.GetComponent<Renderer>();
                    renderer.material = FX_base;
    
                    if (deathFX != null)
                    {
                        Renderer[] renderers = deathFX.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in renderers)
                        {
                            r.material = FX_base;
                        }
                    }
    
                    if (respawnFX != null)
                    {
                        Renderer renderer3 = respawnFX.GetComponent<Renderer>();
                        if (renderer3 != null)
                            renderer3.material = FX_base;
                    }
                }
    
    
                if (skinInfoInShop._skinInfo._skinID.ToString() == "spike")
                {
                    colorSkin = false;
                    beachSkin = false;
                    basketSkin = false;
                    atomSkin = false;
                    bombSkin = false;
                    eyeSkin = false;
                    golfSkin = false;
                    soccerSkin = false;
                    spikeSkin = true;
                    tennisSkin = false;
                    watermelonSkin = false;
                    wheelSkin = false;
                    woodenSkin = false;
    
                    beachBallMesh.enabled = false;
                    playerModelMesh.enabled = false;
                    playerModelRenderer.material = ball_Mat;
    
                    basketBallMesh.enabled = false;
                    atomSkinObj.SetActive(false);
                    bombSkinObj.SetActive(false);
                    eyeBallMesh.enabled = false;
                    golfBallMesh.enabled = false;
                    soccerBallMesh.enabled = false;
                    spikeBallMesh.enabled = true;
                    tennisBallMesh.enabled = false;
                    watermelonBallMesh.enabled = false;
                    wheelBallMesh.enabled = false;
                    woodenBallMesh.enabled = false;
    
                    Renderer renderer = trailFX.GetComponent<Renderer>();
                    renderer.material = FX_base;
    
                    if (deathFX != null)
                    {
                        Renderer[] renderers = deathFX.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in renderers)
                        {
                            r.material = FX_base;
                        }
                    }
    
                    if (respawnFX != null)
                    {
                        Renderer renderer3 = respawnFX.GetComponent<Renderer>();
                        if (renderer3 != null)
                            renderer3.material = FX_base;
                    }
                }
    
                if (skinInfoInShop._skinInfo._skinID.ToString() == "tennis")
                {
                    colorSkin = false;
                    beachSkin = false;
                    basketSkin = false;
                    atomSkin = false;
                    bombSkin = false;
                    eyeSkin = false;
                    golfSkin = false;
                    soccerSkin = false;
                    spikeSkin = false;
                    tennisSkin = true;
                    watermelonSkin = false;
                    wheelSkin = false;
                    woodenSkin = false;
    
                    beachBallMesh.enabled = false;
                    playerModelMesh.enabled = false;
                    playerModelRenderer.material = ball_Mat;
    
                    basketBallMesh.enabled = false;
                    atomSkinObj.SetActive(false);
                    bombSkinObj.SetActive(false);
                    eyeBallMesh.enabled = false;
                    golfBallMesh.enabled = false;
                    soccerBallMesh.enabled = false;
                    spikeBallMesh.enabled = false;
                    tennisBallMesh.enabled = true;
                    watermelonBallMesh.enabled = false;
                    wheelBallMesh.enabled = false;
                    woodenBallMesh.enabled = false;
    
                    Renderer renderer = trailFX.GetComponent<Renderer>();
                    renderer.material = FX_base;
    
                    if (deathFX != null)
                    {
                        Renderer[] renderers = deathFX.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in renderers)
                        {
                            r.material = FX_base;
                        }
                    }
    
                    if (respawnFX != null)
                    {
                        Renderer renderer3 = respawnFX.GetComponent<Renderer>();
                        if (renderer3 != null)
                            renderer3.material = FX_base;
                    }
                }
    
                if (skinInfoInShop._skinInfo._skinID.ToString() == "watermelon")
                {
                    colorSkin = false;
                    beachSkin = false;
                    basketSkin = false;
                    atomSkin = false;
                    bombSkin = false;
                    eyeSkin = false;
                    golfSkin = false;
                    soccerSkin = false;
                    spikeSkin = false;
                    tennisSkin = false;
                    watermelonSkin = true;
                    wheelSkin = false;
                    woodenSkin = false;
    
                    beachBallMesh.enabled = false;
                    playerModelMesh.enabled = false;
                    playerModelRenderer.material = ball_Mat;
    
                    basketBallMesh.enabled = false;
                    atomSkinObj.SetActive(false);
                    bombSkinObj.SetActive(false);
                    eyeBallMesh.enabled = false;
                    golfBallMesh.enabled = false;
                    soccerBallMesh.enabled = false;
                    spikeBallMesh.enabled = false;
                    tennisBallMesh.enabled = false;
                    watermelonBallMesh.enabled = true;
                    wheelBallMesh.enabled = false;
                    woodenBallMesh.enabled = false;
    
                    Renderer renderer = trailFX.GetComponent<Renderer>();
                    renderer.material = FX_base;
    
                    if (deathFX != null)
                    {
                        Renderer[] renderers = deathFX.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in renderers)
                        {
                            r.material = FX_base;
                        }
                    }
    
                    if (respawnFX != null)
                    {
                        Renderer renderer3 = respawnFX.GetComponent<Renderer>();
                        if (renderer3 != null)
                            renderer3.material = FX_base;
                    }
                }
    
                if (skinInfoInShop._skinInfo._skinID.ToString() == "wheel")
                {
                    colorSkin = false;
                    beachSkin = false;
                    basketSkin = false;
                    atomSkin = false;
                    bombSkin = false;
                    eyeSkin = false;
                    golfSkin = false;
                    soccerSkin = false;
                    spikeSkin = false;
                    tennisSkin = false;
                    watermelonSkin = false;
                    wheelSkin = true;
                    woodenSkin = false;
    
                    beachBallMesh.enabled = false;
                    playerModelMesh.enabled = false;
                    playerModelRenderer.material = ball_Mat;
    
                    basketBallMesh.enabled = false;
                    atomSkinObj.SetActive(false);
                    bombSkinObj.SetActive(false);
                    eyeBallMesh.enabled = false;
                    golfBallMesh.enabled = false;
                    soccerBallMesh.enabled = false;
                    spikeBallMesh.enabled = false;
                    tennisBallMesh.enabled = false;
                    watermelonBallMesh.enabled = false;
                    wheelBallMesh.enabled = true;
                    woodenBallMesh.enabled = false;
    
                    Renderer renderer = trailFX.GetComponent<Renderer>();
                    renderer.material = FX_base;
    
                    if (deathFX != null)
                    {
                        Renderer[] renderers = deathFX.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in renderers)
                        {
                            r.material = FX_base;
                        }
                    }
    
                    if (respawnFX != null)
                    {
                        Renderer renderer3 = respawnFX.GetComponent<Renderer>();
                        if (renderer3 != null)
                            renderer3.material = FX_base;
                    }
                }
    
                if (skinInfoInShop._skinInfo._skinID.ToString() == "wooden")
                {
                    colorSkin = false;
                    beachSkin = false;
                    basketSkin = false;
                    atomSkin = false;
                    bombSkin = false;
                    eyeSkin = false;
                    golfSkin = false;
                    soccerSkin = false;
                    spikeSkin = false;
                    tennisSkin = false;
                    watermelonSkin = false;
                    wheelSkin = false;
                    woodenSkin = true;
    
                    beachBallMesh.enabled = false;
                    playerModelMesh.enabled = false;
                    playerModelRenderer.material = ball_Mat;
    
                    basketBallMesh.enabled = false;
                    atomSkinObj.SetActive(false);
                    bombSkinObj.SetActive(false);
                    eyeBallMesh.enabled = false;
                    golfBallMesh.enabled = false;
                    soccerBallMesh.enabled = false;
                    spikeBallMesh.enabled = false;
                    tennisBallMesh.enabled = false;
                    watermelonBallMesh.enabled = false;
                    wheelBallMesh.enabled = false;
                    woodenBallMesh.enabled = true;
    
                    Renderer renderer = trailFX.GetComponent<Renderer>();
                    renderer.material = FX_base;
    
                    if (deathFX != null)
                    {
                        Renderer[] renderers = deathFX.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in renderers)
                        {
                            r.material = FX_base;
                        }
                    }
    
                    if (respawnFX != null)
                    {
                        Renderer renderer3 = respawnFX.GetComponent<Renderer>();
                        if (renderer3 != null)
                            renderer3.material = FX_base;
                    }
                }
    
    
    
            }
        }
    
        private void Start()
        {
    
            audioSource = GetComponent<AudioSource>();
            EquipPreviousSkin();
        }
    
        public void ConfettiBurstPlay()
        {
            confettiParticle.Play();
            audioSource.PlayOneShot(purchaseSound);
        }
    
        public void ErrorSoundPlay()
        {
            audioSource.PlayOneShot(errorSound);
        }
    
        public void ButtonClickedSound()
        {
            audioSource.clip = buttonSound;
            audioSource.Play();
        }
    
    
    }
}