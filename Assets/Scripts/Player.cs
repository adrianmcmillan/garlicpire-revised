using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void Notify();
    public delegate void NotifyWithInstance(GameObject instance);
    public event Notify PlayerDied;
    public event Notify Shot;

    [SerializeField] private Rect _bounds;
    private readonly float _speed = 75.0f;
    private Vector2 _moveVector;
    private Rigidbody2D _rigidBody;
    public float currentHealth;
    public float maxHealth = 100f;
    void Awake()
    {
        this._moveVector = Vector2.zero;
        this._rigidBody = this.GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        this._moveVector.x = Input.GetAxis("Horizontal");
        this._moveVector.y = Input.GetAxis("Vertical");
        if (Input.GetAxis("Fire1") >= 1.0f)
            this.Shot.Invoke();
    }

    void FixedUpdate()
    {
        this._rigidBody.linearVelocity = this._moveVector.normalized * this._speed * Time.deltaTime;
    }

    void LateUpdate()
    {
        //if (this._bounds.Contains(new Vector2(this.transform.position.x, this.transform.position.y)))
        //{

        //}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Enemy")
        {
            this.currentHealth -= 1;
        }
    }
}
