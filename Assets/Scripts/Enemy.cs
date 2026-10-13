using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.currentHealth <= 0)
        {
            Debug.Log("I AM DEAD");
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Projectile")
        {
            Debug.Log("Enemy was hit by projectile!");
            this.currentHealth -= 1;
        }
    }
}
