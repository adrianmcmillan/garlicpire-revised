using System;
using System.Drawing;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageTracker
{

    public float currentHealth;
    public float maxHealth = 10;
    private Vector2 _moveVector;
    private Rigidbody2D _rigidBody;
    public float _moveSpeed;
    public GameObject target;
    public float _damage = 3;
    private GameObject _gameRunner;
    public EnemyHealthTracker healthbar;
    public Action<GameObject> Died;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        this._moveVector = Vector2.zero;
        this._rigidBody = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            IDamageTracker damagee = collision.gameObject.GetComponent<IDamageTracker>();

            if (damagee != null)
            {
                Debug.Log(this+" is hurting: "+damagee+" for "+_damage+" health!");
                damagee.TakeDamage(_damage);
            }
        }
    }

    void movement()
    {
        this._rigidBody.linearVelocity = ((Vector2)target.transform.position - (Vector2)transform.position).normalized * this._moveSpeed * Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Died.Invoke(this.gameObject);
        }
    }
}
