using TMPro;
using UnityEngine;
//using UnityEditor.UI;
using UnityEngine.UI;

public class EnemyHealthTracker : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    public Slider slider;

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
