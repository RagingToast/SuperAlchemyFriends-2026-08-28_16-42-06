using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PotionState
{
    potionA,
    potionB,
    potionC
}
public class PotionStates : MonoBehaviour
{
    [SerializeField] private GameObject potionA;
    [SerializeField] private GameObject potionB;
    [SerializeField] private GameObject potionC;

    [HideInInspector] public GameObject activePotion;
    
    public static PotionStates instance;
    public PotionState state;

    void Awake()
    {
        instance = this;
        activePotion = potionA;
    }
    
    void Update()
    {
        switch (state)
        {
            case PotionState.potionA:
                // potionA.SetActive(true);
                // potionB.SetActive(false);
                // potionC.SetActive(false);
                
                activePotion = potionA;
                break;
            
            case PotionState.potionB:
                // potionA.SetActive(false);
                // potionB.SetActive(true);
                // potionC.SetActive(false);
                //
                activePotion = potionB;
                break;
            
            case PotionState.potionC:
                // potionA.SetActive(false);
                // potionB.SetActive(false);
                // potionC.SetActive(true);
                
                activePotion = potionC;
                break;
        }
    }

    public void OnPotionA(InputAction.CallbackContext context)
    {
        state = PotionState.potionA;
    }

    public void OnPotionB(InputAction.CallbackContext context)
    {
        state = PotionState.potionB;
    }

    public void OnPotionC(InputAction.CallbackContext context)
    {
        state = PotionState.potionC;
    }
}
