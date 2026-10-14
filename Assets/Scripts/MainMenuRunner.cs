using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuRunner : MonoBehaviour
{
    [SerializeField] private GameObject _playButton;
    void Awake()
    {
        Globals.Initialize();
    }
    public void OnStartButtonClicked()
    {
        LevelManager.LoadLevel(Levels.GameWorld);
    }
    public void OnSettingsMenuClicked()
    {
        LevelManager.LoadLevel(Levels.SettingsMenu);
    }
}
