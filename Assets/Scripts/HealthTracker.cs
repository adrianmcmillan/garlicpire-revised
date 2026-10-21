using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{

    [SerializeField] private Player garlic;
    public Slider slider;
    public TextMeshProUGUI healthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        healthText.SetText("PLACEHOLDER");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(healthText != null)
        {
            healthText.SetText("Health: "+garlic.currentHealth+" / "+garlic._maxHealth);
        }
        
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
    
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}
