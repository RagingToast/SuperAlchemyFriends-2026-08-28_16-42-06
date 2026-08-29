// using System.Collections;
// using UnityEngine;
// using UnityEngine.InputSystem;
//
// public class Actions : MonoBehaviour
// {
//     [SerializeField] private GameObject potion;
//     [SerializeField] private Transform fpCamera;
//     [SerializeField] private Transform potionHold;
//     
//     private Rigidbody _rb;
//     private float _throwForce = 3f;
//
//     private bool _canThrow = true;
//     private float _throwCooldown = 1.5f;
//
//     void Awake()
//     {
//         _rb = potion.GetComponent<Rigidbody>();
//     }
//
//     void Start()
//     {
//         Instantiate(potion, potionHold.position, fpCamera.rotation, potionHold);
//     }
//     
//     public void OnThrow(InputAction.CallbackContext context)
//     {
//         if (context.performed && _canThrow)
//         {
//             Debug.Log("OnThrow");
//             _rb.isKinematic = false;
//             _rb.useGravity = true;
//
//             _rb.linearVelocity = fpCamera.forward * _throwForce + Vector3.up * 5f;
//             StartCoroutine(KillCoroutine());
//             
//             StartCoroutine(ThrowCooldown());
//         }
//         
//     }
//
//     IEnumerator ThrowCooldown()
//     {
//         Debug.Log("RAHHHHHHH");
//         _canThrow = false;
//         
//         yield return new WaitForSeconds(_throwCooldown);
//         
//         _canThrow = true;
//         
//         Instantiate(potion, potionHold.position, fpCamera.rotation, potionHold);
//         _rb.isKinematic = true;
//         _rb.useGravity = false;
//         
//     }
//
//     IEnumerator KillCoroutine()
//     {
//         yield return new WaitForSeconds(1f);
//         
//         Destroy(potion);
//     }
// }

using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Actions : MonoBehaviour
{
    [SerializeField] private GameObject potionPrefab;
    [SerializeField] private Transform fpCamera;
    [SerializeField] private Transform potionHold;

    private GameObject currentPotion;
    private Rigidbody _rb;

    private float _throwForce = 3f;
    private bool _canThrow = true;
    private float _throwCooldown = 1.5f;

    void Start()
    {
        SpawnPotion();
    }

    void SpawnPotion()
    {
        currentPotion = Instantiate(potionPrefab, potionHold.position, fpCamera.rotation, potionHold);
        _rb = currentPotion.GetComponent<Rigidbody>();

        _rb.isKinematic = true;
        _rb.useGravity = false;
    }

    public void OnThrow(InputAction.CallbackContext context)
    {
        if (!context.performed || !_canThrow) return;

        currentPotion.transform.SetParent(null); // detach from player's hand

        _rb.isKinematic = false;
        _rb.useGravity = true;
        _rb.linearVelocity = fpCamera.forward * _throwForce + Vector3.up * 5f;

        // StartCoroutine(KillCoroutine(currentPotion));
        StartCoroutine(ThrowCooldown());
    }
    
    IEnumerator ThrowCooldown()
    {
        _canThrow = false;

        yield return new WaitForSeconds(_throwCooldown);

        _canThrow = true;
        SpawnPotion();
    }

    IEnumerator KillCoroutine(GameObject potion)
    {
        yield return new WaitForSeconds(1f);
        Destroy(potion);
    }
}
