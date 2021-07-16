using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerState = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        var y = rb.velocity.y;

        if (y > 0)
            playerState.jumpState = JumpState.Jumping;

        if (y < 0)
            playerState.jumpState = JumpState.Landing;

        if (y == 0 && playerState.jumpState == JumpState.Landing)
            playerState.jumpState = JumpState.Grounded;
    }
}
