using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuRunner : MonoBehaviour
{
    [SerializeField] private GameObject _playButton;
    void Awake()
    {
        if (!Globals.initialized)
        {
            Globals.Initialize();
        }
    }
    public void OnStartButtonClicked()
    {
        LevelManager.LoadLevel(Levels.GameWorld);
    }
    public void OnSettingsMenuClicked()
    {
        LevelManager.LoadLevel(Levels.SettingsMenu);
    }
    public void OnCreditsMenuClicked()
    {
        LevelManager.LoadLevel(Levels.CreditsMenu);
    }
    public void OnExit()
    {
        Application.Quit();
    }
}
