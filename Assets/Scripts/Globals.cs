using UnityEngine;

public class Globals
{
    private const string MUSIC_VOLUME_PLAYER_PREFS_KEY = "MusicVolume";
    private const string SFX_VOLUME_PLAYER_PREFS_KEY = "SFXVolume";
    private const string IS_TUTORIAL_ACTIVE_PLAYER_PREFS_KEY = "IsInTutorial";
    public static float MusicVolume = 1.0f;
    public static float SFXVolume = 1.0f;
    public static bool IsTutorial = true;
    public static bool GameOver = false;
    public static bool initialized = false;

    public static void Initialize()
    {
        if (PlayerPrefs.HasKey(MUSIC_VOLUME_PLAYER_PREFS_KEY))
        {
            MusicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_PLAYER_PREFS_KEY);
        }
        if (PlayerPrefs.HasKey(SFX_VOLUME_PLAYER_PREFS_KEY))
        {
            SFXVolume = PlayerPrefs.GetFloat(SFX_VOLUME_PLAYER_PREFS_KEY);
        }
        if (PlayerPrefs.HasKey(IS_TUTORIAL_ACTIVE_PLAYER_PREFS_KEY))
        {
            IsTutorial = PlayerPrefs.GetInt(IS_TUTORIAL_ACTIVE_PLAYER_PREFS_KEY) == 1;
        }
        initialized = true;
    }

    public static void Save()
    {
        PlayerPrefs.SetFloat(MUSIC_VOLUME_PLAYER_PREFS_KEY, MusicVolume);
        PlayerPrefs.SetFloat(SFX_VOLUME_PLAYER_PREFS_KEY, SFXVolume);
        PlayerPrefs.SetInt(IS_TUTORIAL_ACTIVE_PLAYER_PREFS_KEY, IsTutorial ? 1 : 0);
    }
}