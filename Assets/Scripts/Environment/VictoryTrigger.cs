using Controllers;
using UnityEngine;

namespace Interactables
{
    /// <summary>
    /// Script for detecting player reaching the victory trigger zone.
    /// </summary>
    public class VictoryTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Player"))
            {
                LevelManager.Instance.Victory();
            }
        }
    }
}