using Controllers;
using UnityEngine;

namespace Interactables
{
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