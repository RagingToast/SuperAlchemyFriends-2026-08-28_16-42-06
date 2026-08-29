using UnityEngine;
using UnityEngine.UI;

public interface IHealth
{
    public void BindSliderToHealth(Slider slider, float currentHP, float maximumHP);
    public void GameOver(Slider slider, float currentHP, float minimumHP);
}