using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public JumpState jumpState = JumpState.Grounded;
}

public enum JumpState
{
    Grounded,
    Jumping,
    Landing
}