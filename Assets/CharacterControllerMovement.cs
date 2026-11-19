using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInputController))]
public class CharacterControllerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpSpeed = 7.5f;
    [SerializeField] private float gravity = -20f;

    private CharacterController characterController;
    private PlayerInputController input;
    private float verticalSpeed;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        input = GetComponent<PlayerInputController>();
    }

    private void Update()
    {
        if (characterController.isGrounded && verticalSpeed < 0f)
        {
            verticalSpeed = -2f;
        }

        if (characterController.isGrounded && input.JumpRequested)
        {
            verticalSpeed = jumpSpeed;
            input.ConsumeJumpRequest();
        }

        verticalSpeed += gravity * Time.deltaTime;

        Vector2 movement = input.MoveInput;
        Vector3 velocity = new Vector3(movement.x * moveSpeed, verticalSpeed, movement.y * moveSpeed);
        characterController.Move(velocity * Time.deltaTime);
    }
}
