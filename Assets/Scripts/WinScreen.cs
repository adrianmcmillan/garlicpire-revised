using TMPro;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _gameRunnerObject;
    [SerializeField] private GameObject _scoreText;
    [SerializeField] private GameObject _newHighScoreText;
    [SerializeField] private GameObject _returnButton;
    [SerializeField] private GameObject _titleText; 
    private GameRunner _gameRunner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this._gameRunner = _gameRunnerObject.GetComponent<GameRunner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameover(bool won, int score) {
        Debug.Log("Game over");
        this._gameRunner = _gameRunnerObject.GetComponent<GameRunner>();
        this._winScreen.SetActive(true);
        if (won)
        {
            this._titleText.GetComponent<UnityEngine.UI.Text>().text = "You Won!";
        }
        else
        {

        }
        this._scoreText.GetComponent<UnityEngine.UI.Text>().text = $"Score: {score}";
    }
}
