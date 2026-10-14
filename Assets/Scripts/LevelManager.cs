using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Levels
{
    MainMenu,
    GameWorld,
    SettingsMenu
}
public class LevelManager
{
    public static void LoadLevel(Levels level)
    {
        SceneManager.LoadScene((int)level);
    }
}