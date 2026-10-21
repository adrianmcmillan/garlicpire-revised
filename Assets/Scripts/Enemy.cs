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

    public event GameRunner.NotifyInt Died;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.currentHealth = maxHealth;
        this._moveVector = Vector2.zero;
        this._rigidBody = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");

        GameRunner.LastInstance.GetComponent<GameRunner>().RegisterEnemy(this);
    }

    // Update is called once per frame
    void Update()
    {
        deathChecker();
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
        this._rigidBody.linearVelocity = ((Vector2)target.transform.position - (Vector2)transform.position).normalized * this._moveSpeed;
    }

    async Task deathChecker()
    {
        if(this.currentHealth <= 0)
        {
            Debug.Log("I AM DEAD");
            this.Died?.Invoke((int)this.maxHealth);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
}
