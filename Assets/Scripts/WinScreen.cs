using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _gameRunnerObject;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _newHighScoreText;
    [SerializeField] private GameObject _returnButton;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _retryText;
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
        Time.timeScale = 0.0f;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
            GameObject.Destroy(go);
        Debug.Log("Game over");
        this._gameRunner = _gameRunnerObject.GetComponent<GameRunner>();
        this._winScreen.SetActive(true);
        if (won)
        {
            this._titleText.text = "You Won!";
            _retryText.text = "Play Again";
        }
        this._scoreText.text = $"Score: {score}";
    }
    public void OnClickMainMenuButton() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0); 
    }
    public void OnClickRetryButton() 
    { 
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
