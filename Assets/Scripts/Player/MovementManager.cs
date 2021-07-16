using UnityEngine;
using UnityEngine.InputSystem;

public class MovementManager : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 vector;
    PlayerState playerState;

    public float speed = 7.5f;
    public float jumpForce = 20;
    public float jumpImpulse = 3;

    private const float maxYVelocity = 30;
    private const float minYVelocity = -30;

    private bool spaceDown = false;
    private const float spaceDownCounterMax = 1;
    private float spaceDownCounter = spaceDownCounterMax;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerState = GetComponent<PlayerState>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(vector.x * speed, Mathf.Clamp(rb.velocity.y, minYVelocity, maxYVelocity));

        if (spaceDown && spaceDownCounter > 0)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            spaceDownCounter -= Time.deltaTime;
        }
    }


    public void Move(InputAction.CallbackContext context) =>
        vector = context.ReadValue<Vector2>();

    public void Jump(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();

        if (value > 0 && playerState.jumpState == JumpState.Grounded)
        {
            rb.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);

            spaceDown = true;
            spaceDownCounter = spaceDownCounterMax;
        }

        if (value == 0)
            spaceDown = false;

        Debug.Log("Jump " + value);
    }
}
