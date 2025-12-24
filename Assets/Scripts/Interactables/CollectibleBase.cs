using Controllers;
using UnityEngine;

namespace Interactables
{
    /// <summary>
    /// Base class that defines the behavior of collectible objects (keys, coins, etc.)
    /// </summary>
    public abstract class CollectibleBase : MonoBehaviour
    {
        [SerializeField] protected AudioClip collectedAudioClip;
        
        private void OnTriggerEnter(Collider other)
        {
            Collect();
            AudioManager.Instance.PlaySoundEffect(collectedAudioClip);
            gameObject.SetActive(false);
        }

        public abstract void Collect();
    }
}