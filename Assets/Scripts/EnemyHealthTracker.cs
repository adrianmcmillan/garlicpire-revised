using TMPro;
using UnityEngine;

public class EnemyHealthTracker : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    public TextMeshPro health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health.SetText(enemy.currentHealth+" / "+enemy.maxHealth);
    }
}
