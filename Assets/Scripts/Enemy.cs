using System.Drawing;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth = 10;
    private Vector2 _moveVector;
    private Rigidbody2D _rigidBody;
    public float _moveSpeed;
    public GameObject target;
    public float _damage = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.currentHealth = maxHealth;
        this._moveVector = Vector2.zero;
        this._rigidBody = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        deathChecker();
        movement();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageTracker damagee = collision.gameObject.GetComponent<IDamageTracker>();

        if (damagee != null)
        {
            Debug.Log("Enemy is hurting: "+damagee+" for "+_damage+" health!");
            damagee.TakeDamage(_damage);
        }
        if(collision.gameObject.tag == "Projectile")
        {
            Debug.Log("Enemy was hit by projectile!");
            this.currentHealth -= 1;
        }
    }

    void movement()
    {
        this._rigidBody.linearVelocity = ((Vector2)target.transform.position - (Vector2)transform.position).normalized * this._moveSpeed * Time.deltaTime;
    }

    void deathChecker()
    {
        if(this.currentHealth <= 0)
        {
            Debug.Log("I AM DEAD");
            Destroy(gameObject);
        }
    }
}
