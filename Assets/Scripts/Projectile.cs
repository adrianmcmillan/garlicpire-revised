using System.Collections;
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
    public AudioClip ThrowAudio;
    public AudioClip ImpactAudio;
    private AudioSource _audioSource;

    public void Init(UnityEngine.Vector2 mousePos, Player BigShot, GameObject rotation)
    {
        _rb.linearVelocity = mousePos * _speed;
        _lifeSpan = 2;
        damage = BigShot._damage;
        transform.rotation = rotation.transform.rotation;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = Globals.SFXVolume;
        _audioSource.PlayOneShot(ThrowAudio);
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
        switch (collision.gameObject.name)
        {
            case "Player":
                {
                    return;
                }
            case "Enemy":
                {
                    StartCoroutine(PlayImpactSoundThenDestroy());
                    break;
                }
            default:
                {
                    StartCoroutine(FinishSoundThenDestroy());
                    break;
                }
        }
        CapsuleCollider2D cc = GetComponent<CapsuleCollider2D>();
        cc.enabled = false;
    }

    private IEnumerator PlayImpactSoundThenDestroy()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        sr.enabled = false;

        _audioSource.clip = ImpactAudio;
        _audioSource.volume = _time / _lifeSpan;
        _audioSource.Play();

        while (_audioSource.isPlaying) {
            yield return null;
        }

        Destroy(gameObject);
        yield break;
    }

    private IEnumerator FinishSoundThenDestroy()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        sr.enabled = false;

        while (_audioSource.isPlaying)
        {
            yield return null;
        }

        Destroy(gameObject);
        yield break;
    }

}
