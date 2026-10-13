using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class HealthTracker : MonoBehaviour
{

    [SerializeField] private Player garlic;
    public TextMeshProUGUI health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        health.SetText("PLACEHOLDER");
        
    }

    // Update is called once per frame
    void Update()
    {
        health.SetText("Health: "+garlic.maxHealth+" / "+garlic.currentHealth);
    }
}
