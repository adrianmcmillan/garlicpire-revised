using UnityEngine;

public class PlayerLevelTracker : MonoBehaviour
{
    [SerializeField] private GameObject _gameRunner;
    private GameRunner _gameRunnerComponent => _gameRunner.GetComponent<GameRunner>();
    private UnityEngine.UI.Text _text;
    private float _pct = 0.0f;

    void Awake()
    {
        this._text = this.GetComponent<UnityEngine.UI.Text>();
        Debug.Log(this._text.text);
        this._gameRunner.GetComponent<GameRunner>().GainedXP += this.OnGainedXP;
        this._gameRunner.GetComponent<GameRunner>().LevelUp += this.OnLevelUp;
    }
    
    void Start()
    {
        this._text.text = "Level 1 (0%)\n0 XP";
    }

    private float GetLevelupPercent(float level, float xp)
    {
        return (xp%10)/10 * 100;
    }

    void OnLevelUp(int newLevel, int newExp)
    {
        this._text.text = $"Level {newLevel} ({GetLevelupPercent((float)newLevel, (float)newExp)}%)\n{newExp} XP";
    }
    void OnGainedXP(int newXP)
    {
        this._text.text = $"Level {_gameRunnerComponent.Level} ({GetLevelupPercent((float)_gameRunnerComponent.Level, (float)newXP)}%)\n{newXP} XP";
    }
}
