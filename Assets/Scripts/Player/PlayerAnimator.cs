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

        /// <summary>
        /// Triggers the players idle or move animations. Changes depend on player input.
        /// </summary>
        /// <param name="context">Player input context.</param>
        public void TriggerWalkOrIdleAnimation(CallbackContext context)
        {
            Vector2 moveInput = context.ReadValue<Vector2>();
            bool isRunning = moveInput != Vector2.zero;
            animator.SetBool(animBoolIsRunning, isRunning);
        }

        /// <summary>
        /// Triggers the player's jump animation.
        /// </summary>
        public void TriggerJumpAnimation()
        {
            animator.SetTrigger(animTriggerJump);
        }
        
        /// <summary>
        /// Triggers the player's hit reaction animation.
        /// </summary>
        public void TriggerHitReactionAnimation()
        {
            animator.SetTrigger(animTriggerHit);
        }
    }
}