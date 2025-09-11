using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private CharacterController controller;
    private Camera mainCamera;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controller = GetComponent<CharacterController>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Gravity();
        PlayerMove();
    }

    private void PlayerMove()
    {
        Vector2 input = PlayerInput();

        Vector3 move = new Vector3(input.x, 0, input.y);

        Vector3 camForward = mainCamera.transform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Vector3 camRight = mainCamera.transform.right;
        camRight.y = 0f;
        camRight.Normalize();

        Vector3 moveDir = (camForward * move.z + camRight * move.x);

        controller.Move(moveDir * (moveSpeed * Time.deltaTime));
    }

    private Vector2 PlayerInput()
    {
        Vector2 input = Vector2.zero;
        if (Keyboard.current.wKey.isPressed) input.y += 1;
        if (Keyboard.current.sKey.isPressed) input.y -= 1;
        if (Keyboard.current.dKey.isPressed) input.x += 1;
        if (Keyboard.current.aKey.isPressed) input.x -= 1;
        return input.normalized;
    }

    private void Gravity()
    {
        if (controller.isGrounded) return;

        Vector3 gravity = new Vector3(0, -9.81f, 0);
        controller.Move(gravity * Time.deltaTime);
    }
}