using System.Collections;
using Interactables;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    /// <summary>
    /// Component for handling player's collisions within the level.
    /// </summary>
    public class PlayerCollider : MonoBehaviour
    {
        [SerializeField] private float damageGraceTime = 0.5f;

        [SerializeField] private UnityEvent<int> OnDamageTaken;

        private WaitForSeconds trapGraceWait;
        private bool isWaitingTrapGrace;

        private void Start()
        {
            trapGraceWait = new WaitForSeconds(damageGraceTime);
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            CheckForTraps(hit);
        }

        private void CheckForTraps(ControllerColliderHit hit)
        {
            if (isWaitingTrapGrace)
            {
                return;
            }

            Trap trap = hit.collider.GetComponent<Trap>();
            if (trap == null)
            {
                return;
            }

            OnDamageTaken?.Invoke(trap.Damage);
            StartCoroutine(WaitForTrapGrace());
        }

        private IEnumerator WaitForTrapGrace()
        {
            isWaitingTrapGrace = true;
            yield return trapGraceWait;
            isWaitingTrapGrace = false;
        }
    }
}