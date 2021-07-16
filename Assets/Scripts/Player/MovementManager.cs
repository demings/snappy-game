using UnityEngine;
using UnityEngine.InputSystem;

public class MovementManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();

        Debug.Log("Move " + value);

    }

    public void Jump(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();

        Debug.Log("Jump " + value);
    }
}
