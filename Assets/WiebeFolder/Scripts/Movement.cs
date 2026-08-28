using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform fpCamera;
    
    private Vector2 _moveInput;
    private float _moveSpeed = 5f;
    private Rigidbody _rb;
    
    private float _jumpForce = 2f; 

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        Vector3 forward  = fpCamera.forward;
        Vector3 right  = fpCamera.right;
        
        forward.y = 0;
        right.y = 0;
        
        forward.Normalize();
        right.Normalize();
        
        Vector3 movement = (forward * _moveInput.y) + (_moveInput.x * right);
        
        _rb.linearVelocity = new Vector3(movement.x * _moveSpeed, _rb.linearVelocity.y, movement.z * _moveSpeed);
        
        _rb.rotation = fpCamera.rotation;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
}
