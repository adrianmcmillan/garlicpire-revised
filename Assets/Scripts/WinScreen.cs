using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _gameRunnerObject;
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
}
