using UnityEngine;
using UnityEngine.InputSystem;

public class MovementManager : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 vector;
    PlayerState playerState;

    public float speed = 7.5f;
    private const float maxYVelocity = 30;
    private const float minYVelocity = -30;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerState = GetComponent<PlayerState>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(vector.x * speed, Mathf.Clamp(rb.velocity.y, minYVelocity, maxYVelocity));
    }

    
    public void Move(InputAction.CallbackContext context) =>
        vector = context.ReadValue<Vector2>();

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0 && playerState.jumpState == JumpState.Grounded)
        {
            rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
            playerState.jumpState = JumpState.Jumping;
        }
    }
}
