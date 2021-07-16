using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    Animator animator;
    PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerState = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetInteger("JumpState", (int)playerState.jumpState);
    }
}
