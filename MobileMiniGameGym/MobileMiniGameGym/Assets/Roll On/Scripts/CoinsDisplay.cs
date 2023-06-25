using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollOn.Scripts{
    
    public class CoinsDisplay : MonoBehaviour
    {
        public Text coinsText;
    
        // Start is called before the first frame update
        void Start()
        {
            //PlayerPrefs.DeleteAll();        //DELETE ALL PLAYERPREFS!
        }
    
        // Update is called once per frame
        void Update()
        {
            int savedCoins = PlayerPrefs.GetInt("Coins");
            coinsText.text = savedCoins.ToString();
        }
    }
    
}
