using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuRunner : MonoBehaviour
{
    public const int MainMenuIndex = 0;
    public const int GameWorldIndex = 1;
    public const int SettingsMenuIndex = 2;
    [SerializeField] private GameObject _playButton;
    void Awake()
    {
        //if (this._playButton != null)
        //    this._playButton.GetComponent<Button>().OnPointerClick
    }
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(MainMenuRunner.GameWorldIndex);
    }
    public void OnSettingsMenuClicked()
    {
        SceneManager.LoadScene(MainMenuRunner.SettingsMenuIndex);
    }
}
