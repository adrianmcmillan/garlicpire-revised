using System.Collections;
using Unity.VectorGraphics;
using UnityEngine;

public class GameRunner : MonoBehaviour
{
    public static GameObject LastInstance = null;
    public enum Zone
    {
        Forest = 0,
        Village,
        Desert
    }

    public delegate void Notify();
    public event Notify FruitDied;

    public const float ProjectileLifetime = 2.0f;


    [SerializeField] private Rect _bounds;
    [SerializeField] private Zone _currentZone;
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _playerCharacter;

    // non serialized
    private ArrayList _projectiles;
    private ArrayList _enemies;
    private int score;
    struct Projectile
    {
        public Projectile(GameObject go, float createdOn) {
            this.Instance = go;
            this.CreatedOn = createdOn;
        }
        public GameObject Instance;
        public float CreatedOn;
    }

    void Awake()
    {
        LastInstance = this.gameObject;
        this._playerCharacter.GetComponent<Player>().PlayerDied += this.OnPlayerDied;
        this._playerCharacter.GetComponent<Player>().Shot += this.OnShot;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPlayerDied()
    {
        
    }

    void OnShot()
    {
        Debug.Log("Shot");
    }
}
