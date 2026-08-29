using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IHealth, IDamageable
{
    public static PlayerHealth Instance;

    public event System.Action OnPlayerDeath;

    [SerializeField] float maxHP = 100f;
    [SerializeField] float currentHP;
    [SerializeField] float minHP = 0;

    [SerializeField] GameObject healthBar;
    private Slider healthSlider;

    [SerializeField] string damageDealerTag;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        healthSlider = healthBar.GetComponent<Slider>();

        currentHP = maxHP;
        BindSliderToHealth(healthSlider, currentHP, maxHP);
    }

    void Update()
    {
        GameOver(healthSlider, currentHP, minHP);
    }

    public void BindSliderToHealth(Slider slider, float currentHP, float maximumHP)
    {
        slider.value = currentHP;
        slider.maxValue = maximumHP;
    }

    public void GameOver(Slider slider, float currentHP, float minimumHP)
    {
        slider.value = currentHP;
        slider.minValue = minimumHP;

        if (currentHP <= minimumHP)
        {
            OnPlayerDeath?.Invoke();
        }
    }

    public float TakeDamage(float damageValue)
    {
        currentHP -= damageValue;
        GameOver(healthSlider, currentHP, minHP);

        return currentHP;
    }
}