using UnityEngine;
using UnityEngine.InputSystem;

public class MovementManager : MonoBehaviour
{
    Rigidbody2D rb;
    readonly float speed = 5f;
    Vector2 vector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(vector.x * speed, rb.velocity.y);
    }

    public void Move(InputAction.CallbackContext context) =>
        vector = context.ReadValue<Vector2>();

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0)
            rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
    }
}
