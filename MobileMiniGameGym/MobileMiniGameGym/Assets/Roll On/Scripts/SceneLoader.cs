using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RollOn.Scripts{
    
    public class SceneLoader : MonoBehaviour
    {
        public float transitionTime = 1f;
        public Animator transition;
    
        // Update is called once per frame
        void Update()
        {
            
        }
    
        public void LoadShopScene()
        {
            StartCoroutine(LoadShopLevel(SceneManager.GetActiveScene().buildIndex +1));
        }
    
        IEnumerator LoadShopLevel(int levelIndex)
        {
            transition.SetTrigger("Start");
    
            yield return new WaitForSeconds(transitionTime);
    
            SceneManager.LoadScene(levelIndex);
        }
    
        public void LoadGameScene()
        {
            StartCoroutine(LoadGameLevel(SceneManager.GetActiveScene().buildIndex -1));
        }
    
        IEnumerator LoadGameLevel(int levelIndex)
        {
            transition.SetTrigger("Start");
    
            yield return new WaitForSeconds(transitionTime);
    
            SceneManager.LoadScene(levelIndex);
        }
    }
    
}
