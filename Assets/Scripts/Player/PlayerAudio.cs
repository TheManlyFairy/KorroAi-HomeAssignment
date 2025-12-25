using Controllers;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// Component for handling player audio and sound effects.
    /// </summary>
    public class PlayerAudio : MonoBehaviour
    {
        [SerializeField] private AudioClip damageTakenSoundEffect;

        /// <summary>
        /// Plays the damage taken sound effect.
        /// </summary>
        public void PlayDamageTakenSoundEffect()
        {
            AudioManager.Instance.PlaySoundEffect(damageTakenSoundEffect);
        }
    }
}