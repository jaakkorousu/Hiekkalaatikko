using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputController : MonoBehaviour
{
    private Vector2 moveInput;
    private bool jumpRequested;

    public Vector2 MoveInput => moveInput;
    public bool JumpRequested => jumpRequested;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            jumpRequested = true;
        }
    }

    public void ConsumeJumpRequest()
    {
        jumpRequested = false;
    }
}
