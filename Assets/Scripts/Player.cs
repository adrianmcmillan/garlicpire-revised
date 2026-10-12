using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed;
    private Vector2 _moveVector;
    private Rigidbody2D _rigidBody;
    void Awake()
    {
        this._moveVector = Vector2.zero;
        this._rigidBody = this.GetComponent<Rigidbody2D>();
        this._speed = 25;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this._moveVector.x = Input.GetAxis("Horizontal");
        this._moveVector.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        this._rigidBody.linearVelocity = this._moveVector.normalized * this._speed;
    }
}
