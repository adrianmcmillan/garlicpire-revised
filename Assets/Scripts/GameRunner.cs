using System;
using System.Collections;
using Unity.VectorGraphics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameRunner : MonoBehaviour
{
    public static GameObject LastInstance = null;
    public static readonly float ScoreScale = 1.25f;
    public static readonly int MaxEnemies = 3;
    [SerializeField] private Tilemap _tilemap;
    public enum Zone
    {
        Forest = 0,
        Village,
        Desert
    }

    public delegate void Notify();
    public delegate void NotifyInt(int i);
    public delegate void NotifyInt2(int u, int v);
    public delegate void NotifyGameOver(bool won, int score);
    public event NotifyInt GainedXP;
    public event NotifyInt2 LevelUp;
    //public event Notify FruitDied;
    public event NotifyInt ScoreChanged;
    public event NotifyGameOver GameOver;

    public const float ProjectileLifetime = 2.0f;

    public int XP { get; private set; } = 0;
    public int Level { get; private set; } = 1;
    public int ToNextLevel { get; private set; } = 10;
    [SerializeField] private int _numberOfEnemies = 8;
    [SerializeField] private float _spawnRadius = 5f;


    [SerializeField] private Rect _bounds;
    [SerializeField] private Zone _currentZone;
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _playerCharacter;
    [SerializeField] private GameObject[] _enemyPrefabs;

    private ArrayList _spawnedEnemies;
    [SerializeField] private GameObject _winScreen;

    // non serialized
    private ArrayList _projectiles;
    private ArrayList _enemies;
    private int _score;
    private bool _checkedIfWon = false;
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
        //this._playerCharacter.GetComponent<Player>().PlayerDied += this.OnPlayerDied;
        //this._playerCharacter.GetComponent<Player>().Shot += this.OnShot;
        _spawnedEnemies = new ArrayList();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this._playerCharacter.GetComponent<Player>().Died += this.OnPlayerDied;
        SpawnInCircle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    void OnPlayerDied()
    {
        Debug.Log("Dead");
        this._winScreen.GetComponent<WinScreen>().OnGameover(false, this._score);
    }

    void OnShot()
    {
        Debug.Log("Shot");
    }

    /// <summary>
    /// Checks if the player should level up based on their XP.
    /// </summary>
    private void CheckLevelUp()
    {
        // TODO adrianmcmillan: revise level-up policy, currently each level is awarded after 10 xp is gained
        if (this.ToNextLevel <= 0)
        {
            this.LevelUp.Invoke(++this.Level, this.XP);
        } else
        {
            this.GainedXP.Invoke(this.XP);
        }
    }

    public void SpawnInCircle()
    {
        Vector3 center = _playerCharacter.transform.position;

        while (_spawnedEnemies.Count -1 < _numberOfEnemies)
        {
            // Generate a random position in a circle around the player
            Vector2 randomOffset = UnityEngine.Random.insideUnitCircle * _spawnRadius;

            Vector3 spawnPosition = new Vector3(
                center.x + (randomOffset.x > 0 ? randomOffset.x + 3 : randomOffset.x - 3),
                center.y + (randomOffset.y > 0 ? randomOffset.y + 3 : randomOffset.y - 3),
                center.z
            );

            // Convert the world position to a Tilemap cell
            Vector3Int cell = _tilemap.WorldToCell(spawnPosition);

            // Check that the cell contains a tile
            if (_tilemap.HasTile(cell))
            {
                GameObject enemy = Instantiate(
                    _enemyPrefabs[UnityEngine.Random.Range(0, _enemyPrefabs.Length - 1)],
                    spawnPosition,
                    Quaternion.identity
                );

                _spawnedEnemies.Add(enemy);
                enemy.GetComponent<Enemy>().Died+= HandleEnemyDeath;
            }
        }
    }
    /// <summary>
    /// Spawns more enemies if we do not have enough in the scene.
    /// </summary>
    private void CheckEnemyCapacity()
    {

    }

    private void HandleEnemyDeath(GameObject deadEnemy)
    {
        _spawnedEnemies.Remove(deadEnemy);
        Enemy component = deadEnemy.GetComponent<Enemy>();
        this._score += ((int)(component.maxHealth * ScoreScale));
        this.ScoreChanged.Invoke(this._score);
        this.CheckEnemyCapacity();
        this.CheckWinCondition();
        Destroy(deadEnemy);
        SpawnInCircle();
    }
    /// <summary>
    /// Checks if the player has won the game, sending a message if they have.
    /// </summary>
    private void CheckWinCondition()
    {
        if (this._checkedIfWon) return;
        Debug.Log("Checking if we won");
        if (this._score >= 1000)
        {
            Debug.Log("we won");
            this._checkedIfWon = true;
            //this.GameOver.Invoke(true, this._score);
            this._winScreen.SetActive(true);
            this._winScreen.GetComponent<WinScreen>().OnGameover(true, this._score);
        }
    }
}
