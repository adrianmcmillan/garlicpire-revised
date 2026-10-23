using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{

    [SerializeField] private Player garlic;
    public Slider slider;
    public TextMeshProUGUI healthText;

    public void SetHealth(float health)
    {
        slider.value = health;
        healthText.SetText("Health: " + garlic.currentHealth + " / " + garlic._maxHealth);
    }
    
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        SetHealth(health);
    }
}
