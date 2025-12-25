using Controllers;
using UnityEngine;

namespace Interactables
{
    /// <summary>
    /// Component for animation the doorway opening when all keys are collected.
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class DoorAnimator : MonoBehaviour
    {
        private void Start()
        {
            LevelManager.Instance.OnAllKeysCollected += TriggerDoorOpenAnimation;
        }

        private void TriggerDoorOpenAnimation()
        {
            GetComponent<Animator>().SetTrigger("Open");
        }
    }
}