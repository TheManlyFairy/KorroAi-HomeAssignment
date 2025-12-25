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

        public void PlayDamageTakenSoundEffect()
        {
            AudioManager.Instance.PlaySoundEffect(damageTakenSoundEffect);
        }
    }
}