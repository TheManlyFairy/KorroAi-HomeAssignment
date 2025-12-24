using Interactables;
using UnityEngine;

namespace Controllers
{
    /// <summary>
    /// Manager for handling audio within a level.
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [SerializeField] protected SoundEffector soundEffectorPrefab;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }
        
        public void PlaySoundEffect(AudioClip clip)
        {
            if (clip == null)
            {
                return;
            }
            SoundEffector soundEffector = Instantiate(soundEffectorPrefab);
            soundEffector.PlayClip(clip);
        }
    }
}