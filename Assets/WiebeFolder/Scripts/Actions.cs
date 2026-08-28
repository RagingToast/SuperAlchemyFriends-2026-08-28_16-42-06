using UnityEngine;
using UnityEngine.InputSystem;

public class Actions : MonoBehaviour
{
    public void OnThrow(InputAction.CallbackContext context)
    {
        Debug.Log("OnThrow");
    }
}
