using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Actions : MonoBehaviour
{
    // [SerializeField] private GameObject potionPrefab;
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
        currentPotion = Instantiate(PotionStates.instance.activePotion, potionHold.position, fpCamera.rotation, potionHold);
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
