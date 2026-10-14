using System.Numerics;
using TMPro;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    public float _lifeSpan;
    public float _time;

    public void Init(UnityEngine.Vector3 mousePos)
    {
        _rb.linearVelocity = mousePos * _speed;
        _lifeSpan = 2;
    }

    public void Update()
    {
        
        _time += Time.deltaTime;
        if(_time >= _lifeSpan)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name != "Player")
        {
            Destroy(gameObject);
        }
    }

}
