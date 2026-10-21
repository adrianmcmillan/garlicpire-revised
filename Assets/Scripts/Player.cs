using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDamageTracker
{
    public delegate void Notify();
    public delegate void NotifyWithInstance(GameObject instance);
    //public event Notify PlayerDied;
    //public event Notify Shot;

    [SerializeField] private Rect _bounds;
    private Vector2 _moveVector;
    private Rigidbody2D _rigidBody;
    public float currentHealth;
    public float _maxHealth = 100;
    public float _moveSpeed = 200.0f;
    public float _cooldown = 5.0f;
    public float _time;
    private UnityEngine.Vector3 mousePos;
    private UnityEngine.Vector2 relativeMousePos;

    public GameObject _rotation;

    public Projectile _stake;
    public float _damage = 1;

    public event GameRunner.Notify Died;
    private bool _dead = false;

    void Awake()
    {
        this._moveVector = Vector2.zero;
        this._rigidBody = this.GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        this.currentHealth = _maxHealth;
        _time = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        this._moveVector.x = Input.GetAxisRaw("Horizontal");
        this._moveVector.y = Input.GetAxisRaw("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        relativeMousePos = mousePos - transform.position;
        _rotation.transform.up = relativeMousePos;

        _time += Time.deltaTime;
        if(_time >= _cooldown)
        {
            Instantiate(_stake, transform.position, Quaternion.identity).Init(_rotation.transform.up, this);
            _time = 0;
        }
    }
    // called onec every fixed frame update
    void FixedUpdate()
    {
        this._rigidBody.linearVelocity = this._moveVector.normalized * this._moveSpeed * Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (!_dead && this.currentHealth <= 0)
        {
            _dead = true;
            this.Died.Invoke();
        }
        if (this.currentHealth < 0)
            this.currentHealth = 0;
    }
}
