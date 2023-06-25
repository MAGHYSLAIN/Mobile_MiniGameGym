using UnityEngine;

namespace RollOn.Scripts.ShopScripts{
    
    public class PlayerMoney : MonoBehaviour
    {
        public static PlayerMoney Instance;
    
        [SerializeField] private int playerMoney;//SFD
    
        private const string prefMoney = "Coins";
    
        private void Awake()
        {
            Instance = this;
            LoadMoney();
        }
    
        private void LoadMoney()
        {
            playerMoney = PlayerPrefs.GetInt(prefMoney, 0);
        }
    
        public bool TryRemoveMoney(int moneyToRemove)
        {
            if (playerMoney >= moneyToRemove)
            {
                playerMoney -= moneyToRemove;
                PlayerPrefs.SetInt(prefMoney, playerMoney);
                PlayerPrefs.Save();
                return true;
            }
            else
            {
                return false;
            }
        }
    
        private void Update()
        {
            PlayerPrefs.SetInt(prefMoney, playerMoney);
            PlayerPrefs.Save();
        }
    }
    
}
