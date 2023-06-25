using UnityEngine;

namespace RollOn.Scripts.ShopScripts{
    
    [System.Serializable, CreateAssetMenu(fileName ="New Skin", menuName ="Create New Skin")]
    public class SSkinInfo : ScriptableObject
    {
        public enum SkinIDs { red, blue, black, beach, rainbow, atom, basket, bomb, eye, golf, soccer, spike, tennis, watermelon, wheel, wooden }
    
        [SerializeField] private SkinIDs skinID;
        public SkinIDs _skinID { get { return skinID; } }
    
        [SerializeField] private Sprite skinSprite;
        public Sprite _skinSprite { get { return skinSprite; } }
    
        [SerializeField] private int skinPrice;
        public int _skinPrice { get { return skinPrice; } }
    
        [SerializeField] private Material skinMaterial;
        public Material _skinMaterial { get { return skinMaterial; } }
    
        [SerializeField] private Material particleMaterial;
        public Material _particleMaterial { get { return particleMaterial; } }
    
        [SerializeField] private Color skinColor = Color.white;
        public Color _skinColor { get { return skinColor; } }
    
    }
    
    
}
