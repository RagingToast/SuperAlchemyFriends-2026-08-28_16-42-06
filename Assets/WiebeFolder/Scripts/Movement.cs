using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Vector2 _moveInput;
    private float _moveSpeed;
    private Rigidbody _rb;
    
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(_moveInput.x, 0f, _moveInput.y);
        
        _rb.linearVelocity = new Vector3(movement.x * _moveSpeed, _rb.linearVelocity.y, movement.z * _moveSpeed);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();

    }
}
