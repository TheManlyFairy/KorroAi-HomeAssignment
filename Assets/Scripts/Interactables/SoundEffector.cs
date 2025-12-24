using System.Collections;
using UnityEngine;

namespace Interactables
{
    /// <summary>
    /// Class for spawning in a temporary sound effect object and destroying it after the sound effect is played.
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class SoundEffector : MonoBehaviour
    {
        private AudioSource audioSource;

        public void PlayClip(AudioClip clip)
        {
            StartCoroutine(PlayOneShop(clip));
        }

        private IEnumerator PlayOneShop(AudioClip clip)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(clip);
            yield return new WaitForSeconds(clip.length);
            Destroy(gameObject);
        }
    }
}