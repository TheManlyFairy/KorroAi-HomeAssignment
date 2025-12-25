using System.Collections;
using Controllers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace Player
{
    /// <summary>
    /// Component for handling the player's movement input.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        private const string MANNEQUIN_ACTIONS = "MannequinActions";
        private const string EMPTY_ACTIONS = "Empty";
        
        [Header("Local References")] 
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform groundedCheckTransform;
        [SerializeField] private Animator animator;
        [SerializeField] private PlayerInput playerInput;
        
        [Header("Movement")] 
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpHeight = 0.35f;
        [SerializeField] private float gravity = -9.81f;

        [Header("Jumping")] 
        [SerializeField] private float groundCheckGraceTime = 0.2f;
        [SerializeField] private float groundCheckRadius = 0.25f;
        [SerializeField] private float distanceFromGroundToStop = 0.01f;
        [SerializeField] private LayerMask groundLayerMask;

        [Header("View Rotation")] 
        [SerializeField] private float minViewAngle = -90f;
        [SerializeField] private float maxViewAngle = 90f;
        [SerializeField] private float rotationSpeed = 5f;
        [Range(0f, 1f)] [SerializeField] private float sensitivity = 1f;

        /// <summary>
        /// Subscribe to this event to know when an actual jump has been performed by the player.
        /// </summary>
        public UnityEvent OnJumpPerformed;
        
        private CharacterController playerController;
        private WaitForSeconds jumpGraceWait;
        private Vector3 velocity;
        private Vector2 moveInput;
        private Vector2 rotateViewInput;
        private bool jumpPressed;
        private bool isGroundedCheck;
        private bool isWaitingJumpGrace;
        private float cameraRotation;
        
        #region Unity Lifecycle

        private void Awake()
        {
            TimelineManager.OnPlay += DisableInput;
            TimelineManager.OnEnd += EnableInput;
        }
        private void Start()
        {
            jumpGraceWait = new WaitForSeconds(groundCheckGraceTime);
            InitializeInputActions();
        }

        private void Update()
        {
            RotateView();
            Move();
            Jump();
        }

        #endregion
        
        #region Initialization

        private void DisableInput()
        {
            playerInput.SwitchCurrentActionMap(EMPTY_ACTIONS);
        }

        private void EnableInput()
        {
            playerInput.SwitchCurrentActionMap(MANNEQUIN_ACTIONS);
        }
        private void InitializeInputActions()
        {
            playerController = GetComponent<CharacterController>();
            cameraRotation = cameraTransform.localRotation.eulerAngles.y;
        }
#endregion

        #region Input Callbacks

        /// <summary>
        /// Callback method for when a jump input is received.
        /// </summary>
        /// <param name="context">Input context.</param>
        public void OnJump(CallbackContext context)
        {
            if (context.performed == false || isGroundedCheck == false)
            {
                return;
            }

            jumpPressed = true;
        }

        /// <summary>
        /// Callback method for when a movement input is received.
        /// </summary>
        /// <param name="context">Input context.</param>
        public void OnMove(CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
        }

        /// <summary>
        /// Callback method for when a rotation input is received.
        /// </summary>
        /// <param name="context">Input context.</param>
        public void OnRotateView(CallbackContext context)
        {
            rotateViewInput = context.ReadValue<Vector2>();
        }

        #endregion

        #region Input Actions

        private void Move()
        {
            Vector3 moveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;
            float frameMoveSpeed = moveSpeed * Time.deltaTime;
            playerController.Move(moveDirection * frameMoveSpeed);
        }

        private void Jump()
        {
            velocity.y += gravity * Time.deltaTime;
            if (jumpPressed)
            {
                jumpPressed = false;
                velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
                isGroundedCheck = false;
                StartCoroutine(CheckGroundedGraceCoroutine());
                velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
                OnJumpPerformed?.Invoke();
            }
            
            playerController.Move(velocity * Time.deltaTime);
            CheckIsGrounded();
        }

        private void RotateView()
        {
            float playerRotation = rotateViewInput.x * rotationSpeed * sensitivity;
            float cameraRotationDelta = rotateViewInput.y * rotationSpeed * sensitivity;

            transform.Rotate(Vector3.up, playerRotation);

            cameraRotation -= cameraRotationDelta;
            cameraRotation = Mathf.Clamp(cameraRotation, minViewAngle, maxViewAngle);

            cameraTransform.localRotation = Quaternion.Euler(cameraRotation, 0f, 0f);
        }

        private void CheckIsGrounded()
        {
            if (isWaitingJumpGrace) // Disable ground checks for a short duration after a jump to ensure ground checks don't happen as the player is ascending.
            {
                return;
            }
            isGroundedCheck = Physics.CheckSphere(groundedCheckTransform.position, groundCheckRadius, groundLayerMask);
            if (isGroundedCheck && velocity.y < 0)
            {
                velocity.y = 0f;
            }
        }

        private IEnumerator CheckGroundedGraceCoroutine()
        {
            isWaitingJumpGrace = true;
            yield return jumpGraceWait;
            isWaitingJumpGrace = false;
        }

        #endregion
        
        private void OnDrawGizmosSelected()
        {
            if (groundedCheckTransform != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(groundedCheckTransform.position, groundCheckRadius);
            }
        }
    }
}