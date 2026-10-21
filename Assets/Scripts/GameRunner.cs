using System.Collections;
using Unity.VectorGraphics;
using UnityEditor;
using UnityEngine;

public class GameRunner : MonoBehaviour
{
    public static GameObject LastInstance = null;
    public static readonly float ScoreScale = 1.25f;
    public static readonly int MaxEnemies = 3;
    public enum Zone
    {
        Forest = 0,
        Village,
        Desert
    }

    public delegate void Notify();
    public delegate void NotifyInt(int i);
    public delegate void NotifyInt2(int u, int v);
    public event NotifyInt GainedXP;
    public event NotifyInt2 LevelUp;
    //public event Notify FruitDied;
    public event NotifyInt ScoreChanged;
    public event NotifyInt2 GameOver;

    public const float ProjectileLifetime = 2.0f;

    public int XP { get; private set; } = 0;
    public int Level { get; private set; } = 1;
    public int ToNextLevel { get; private set; } = 10;


    [SerializeField] private Rect _bounds;
    [SerializeField] private Zone _currentZone;
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _playerCharacter;

    // non serialized
    private ArrayList _projectiles;
    private ArrayList _enemies;
    private int _score;
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
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this._enemies = new ArrayList();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
            this._enemies.Add(go);
        Debug.Log(this._enemies.Count);
        this._playerCharacter.GetComponent<Player>().Died += this.OnPlayerDied;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPlayerDied()
    {
        Debug.Log("Dead");
    }

    void OnShot()
    {
        Debug.Log("Shot");
    }

    /// <summary>
    /// Tells the game runner to subscribe to an enemy's death event, so it knows when an enemy has died.
    /// </summary>
    /// <param name="enemy">The newly created enemy.</param>
    public void RegisterEnemy(Enemy enemy)
    {
        enemy.Died += ((maxhealth) => {
            // award a lil XP based on enemy's amx health
            //this.XP += maxhealth;  // TODO adrianmcmillan: revise XP gain function to something more robust than the enemy's max health
            //this.ToNextLevel -= maxhealth;
            //this.GainedXP.Invoke(this.XP);
            //this.CheckLevelUp();
            this._score += ((int)(maxhealth * ScoreScale));
            this.ScoreChanged.Invoke(this._score);
            this.CheckEnemyCapacity();
        });
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
    /// <summary>
    /// Spawns more enemies if we do not have enough in the scene.
    /// </summary>
    private void CheckEnemyCapacity()
    {

    }
    /// <summary>
    /// Checks if the player has won the game, sending a message if they have.
    /// </summary>
    private void CheckWinCondition()
    {

    }
}
