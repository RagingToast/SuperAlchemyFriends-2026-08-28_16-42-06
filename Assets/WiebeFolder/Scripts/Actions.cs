using UnityEngine;
using UnityEngine.InputSystem;

public class Actions : MonoBehaviour
{
    [SerializeField] private GameObject potion;
    [SerializeField] private Transform fpCamera;
    [SerializeField] private Transform potionHold;
    
    private Rigidbody _rb;
    private float _throwForce = 3f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    
    public void OnThrow(InputAction.CallbackContext context)
    {
        Debug.Log("OnThrow");
        _rb.isKinematic = false;
        _rb.useGravity = true;

        _rb.linearVelocity = fpCamera.forward * _throwForce + Vector3.up * 5f;
        
        Instantiate(potion, potionHold.position, fpCamera.rotation);
    }
}
