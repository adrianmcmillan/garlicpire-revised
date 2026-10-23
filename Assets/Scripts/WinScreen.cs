using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Time.timeScale = 0.0f;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
            GameObject.Destroy(go);
        Debug.Log("Game over");
        this._gameRunner = _gameRunnerObject.GetComponent<GameRunner>();
        this._winScreen.SetActive(true);
        if (won)
        {
            this._titleText.GetComponent<TMPro.TextMeshProUGUI>().text = "You Won!";
        }
        else
        {

        }
        this._scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = $"Score: {score}";
    }
    public void OnClickMainMenuButton() { SceneManager.LoadScene(0); }
    public void OnClickRetryButton() 
    { 
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
