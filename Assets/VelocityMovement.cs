using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInputController))]
public class VelocityMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpSpeed = 7.5f;

    private Rigidbody body;
    private PlayerInputController input;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInputController>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = input.MoveInput;
        Vector3 velocity = body.linearVelocity;
        body.linearVelocity = new Vector3(movement.x * moveSpeed, velocity.y, movement.y * moveSpeed);

        bool grounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        if (grounded && input.JumpRequested)
        {
            body.linearVelocity = new Vector3(body.linearVelocity.x, jumpSpeed, body.linearVelocity.z);
            input.ConsumeJumpRequest();
        }
    }
}
