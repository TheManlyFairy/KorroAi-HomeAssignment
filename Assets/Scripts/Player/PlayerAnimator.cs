using UnityEngine;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace Player
{
    /// <summary>
    /// Component for handling the player's animations.
    /// </summary>
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string animBoolIsRunning;
        [SerializeField] private string animTriggerJump;
        [SerializeField] private string animTriggerHit;

        public void TriggerWalkOrIdleAnimation(CallbackContext context)
        {
            Vector2 moveInput = context.ReadValue<Vector2>();
            bool isRunning = moveInput != Vector2.zero;
            animator.SetBool(animBoolIsRunning, isRunning);
        }

        public void TriggerJumpAnimation()
        {
            animator.SetTrigger(animTriggerJump);
        }
        
        public void TriggerHitReactionAnimation()
        {
            animator.SetTrigger(animTriggerHit);
        }
    }
}