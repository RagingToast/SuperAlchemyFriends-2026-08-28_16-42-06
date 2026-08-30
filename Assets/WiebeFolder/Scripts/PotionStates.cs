using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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
    
    [SerializeField] private Image imageA;
    [SerializeField] private Image imageB;
    [SerializeField] private Image imageC;

    [HideInInspector] public GameObject activePotion;
    [HideInInspector] public LayerMask enemyLayer;
    
    public static PotionStates instance;
    public PotionState state;

    void Awake()
    {
        instance = this;
        activePotion = potionA;
        enemyLayer = LayerMask.GetMask("SpeedScrub");
        
    }
    
    void Update()
    {
        switch (state)
        {
            case PotionState.potionA:
                // potionA.SetActive(true);
                // potionB.SetActive(false);
                // potionC.SetActive(false);

                imageA.color = Color.aliceBlue;
                imageB.color = Color.darkGray;
                imageC.color = Color.darkGray;
                
                
                activePotion = potionA;
                enemyLayer = LayerMask.GetMask("SpeedScrub");
                break;
            
            case PotionState.potionB:
                // potionA.SetActive(false);
                // potionB.SetActive(true);
                // potionC.SetActive(false);
                //
                
                imageA.color = Color.darkGray;
                imageB.color = Color.aliceBlue;
                imageC.color = Color.darkGray;
                
                activePotion = potionB;
                enemyLayer = LayerMask.GetMask("TankScrub");
                break;
            
            case PotionState.potionC:
                // potionA.SetActive(false);
                // potionB.SetActive(false);
                // potionC.SetActive(true);
                
                imageA.color = Color.darkGray;
                imageB.color = Color.darkGray;
                imageC.color = Color.aliceBlue;
                
                activePotion = potionC;
                enemyLayer = LayerMask.GetMask("RangeScrub");
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
