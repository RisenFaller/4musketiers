using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 moveInput;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 7f;
    private Transform cameraTransform; // Assign your main camera here

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // prevent tipping
        cameraTransform = Camera.main.transform;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        // Get camera forward/right on the ground plane
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // Build movement direction relative to camera
        Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;
        moveDirection.Normalize();

        // Move player
        Vector3 move = moveDirection * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.5f);
    }
}
