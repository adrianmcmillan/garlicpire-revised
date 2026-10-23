using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuRunner : MonoBehaviour
{
    public AudioClip MenuMusic;
    void Awake()
    {
        AudioManager.Instance.PlayMusic(MenuMusic);
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
