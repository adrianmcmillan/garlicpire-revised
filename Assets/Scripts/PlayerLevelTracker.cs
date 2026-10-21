using TMPro;
using UnityEngine;

public class PlayerLevelTracker : MonoBehaviour
{
    [SerializeField] private GameObject _gameRunner;
    private GameRunner _gameRunnerComponent => _gameRunner.GetComponent<GameRunner>();
    private TextMeshProUGUI _text;
    private float _pct = 0.0f;

    void Awake()
    {
        this._text = this.GetComponent<TextMeshProUGUI>();
        Debug.Log(this._text.text);
        this._gameRunner.GetComponent<GameRunner>().GainedXP += this.OnGainedXP;
        this._gameRunner.GetComponent<GameRunner>().LevelUp += this.OnLevelUp;
        this._gameRunner.GetComponent<GameRunner>().ScoreChanged += this.OnScoreChanged;
    }
    
    void Start()
    {
        this._text.text = "Score: 0";
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
    void OnScoreChanged(int newScore)
    {
        this._text.text = $"Score: {newScore}";
    }
}
