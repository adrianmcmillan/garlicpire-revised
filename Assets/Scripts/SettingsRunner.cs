using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsRunner : MonoBehaviour
{
    public Slider MusicVolumeSlider;
    public Slider SFXVolumeSlider;
    public Toggle IsTutorialToggle;
    public TextMeshProUGUI SettingDescription;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!Globals.initialized)
        {
            Globals.Initialize();
        }
        MusicVolumeSlider.value = Globals.MusicVolume;
        SFXVolumeSlider.value = Globals.SFXVolume;
        IsTutorialToggle.isOn = Globals.IsTutorial;
    }

    public void MusicSliderChanged()
    {
        Globals.MusicVolume = MusicVolumeSlider.value;
        AudioManager.Instance.SetMusicVolume(MusicVolumeSlider.value);
    }

    public void SFXSliderChanged()
    {
        Globals.SFXVolume = SFXVolumeSlider.value;
        AudioManager.Instance.SetSFXVolume(SFXVolumeSlider.value);
    }

    public void IsTutorialOptionChanged()
    {
        Globals.IsTutorial = IsTutorialToggle.isOn;
    }

    public void SettingHovered(string SettingIdentifer)
    {
        switch (SettingIdentifer)
        {
            case "MusicVolume":
            {
                    SettingDescription.text = "Music Volume - Controls the volume of the music";
                    break;
            }
            case "SFXVolume":
                {
                    SettingDescription.text = "SFX Volume - Controls the volume of the sound effects";
                    break;
                }
            case "IsTutorial":
                {
                    SettingDescription.text = "Show Tutorial - Shows the initial on-screen tutorial if set on";
                    break;
                }
            default:
            {
                    break;
            }
        }
    }

    public void SaveChangesAndExit()
    {
        Globals.Save();
        LevelManager.LoadLevel(Levels.MainMenu);
    }
}
