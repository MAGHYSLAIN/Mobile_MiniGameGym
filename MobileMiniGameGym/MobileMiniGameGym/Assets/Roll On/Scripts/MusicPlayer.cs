using UnityEngine;

namespace RollOn.Scripts
{
    public class MusicPlayer : MonoBehaviour
    {
        public AudioClip musicClip;
        private static MusicPlayer instance;
        private AudioSource audioSource;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                audioSource = GetComponent<AudioSource>();
                audioSource.loop = true;

                if (musicClip != null)
                {
                    audioSource.clip = musicClip;
                    audioSource.Play();
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
