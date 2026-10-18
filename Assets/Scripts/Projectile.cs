using System.Numerics;
using TMPro;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    public float _lifeSpan;
    public float _time;
    private float damage;

    public void Init(UnityEngine.Vector2 mousePos, Player BigShot)
    {
        _rb.linearVelocity = mousePos * _speed;
        _lifeSpan = 2;
        damage = BigShot._damage;
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
        IDamageTracker damagee = collision.gameObject.GetComponent<IDamageTracker>();

        if (damagee != null)
        {
            Debug.Log(this+" is hurting: "+damagee+" for "+damage+" health!");
            damagee.TakeDamage(damage);
        }
        if(collision.gameObject.name != "Player")
        {
            Destroy(gameObject);
        }
    }

}
