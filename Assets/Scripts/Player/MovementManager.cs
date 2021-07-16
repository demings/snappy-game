using UnityEngine;
using UnityEngine.InputSystem;

public class MovementManager : MonoBehaviour
{
    Rigidbody2D rb;
    readonly float speed = 5f;
    private const float maxYVelocity = 30;
    private const float minYVelocity = -30;
    Vector2 vector;
    public JumpState jumpState = JumpState.Grounded;
    public Transform groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var y = Mathf.Clamp(rb.velocity.y, minYVelocity, maxYVelocity);
        rb.velocity = new Vector2(vector.x * speed, y);

        if (y < 0)
            jumpState = JumpState.Landing;

        if (y == 0 && jumpState == JumpState.Landing)
            jumpState = JumpState.Grounded;

    }

    
    public void Move(InputAction.CallbackContext context) =>
        vector = context.ReadValue<Vector2>();

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0 && jumpState == JumpState.Grounded)
        {
            rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
            jumpState = JumpState.Jumping;
        }
    }
}

public enum JumpState
{
    Grounded,
    Jumping,
    Landing
}