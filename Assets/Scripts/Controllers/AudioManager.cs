using Interactables;
using UnityEngine;

namespace Controllers
{
    /// <summary>
    /// Manager for handling audio within a level.
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        /// <summary>
        /// The singleton instance of this manager.
        /// </summary>
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
        
        /// <summary>
        /// Creates an instance of a <see cref="SoundEffector"/> that plays a clip.
        /// </summary>
        /// <param name="clip">The clip to be played by the effector.</param>
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