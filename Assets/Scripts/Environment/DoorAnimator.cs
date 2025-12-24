using Controllers;
using UnityEngine;

namespace Interactables
{
    [RequireComponent(typeof(Animator))]
    public class DoorAnimator : MonoBehaviour
    {
        private void Start()
        {
            LevelManager.Instance.OnAllKeysCollected += TriggerDoorOpenAnimation;
        }

        public void TriggerDoorOpenAnimation()
        {
            GetComponent<Animator>().SetTrigger("Open");
        }
    }
}