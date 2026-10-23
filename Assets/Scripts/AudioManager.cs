using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public AudioMixer MainMixer;
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject prefab = Resources.Load<GameObject>("GlobalAudioManager");
                Instantiate(prefab);
                return prefab.GetComponent<AudioManager>();
            }
            else
            {
                return _instance;
            }
        }
    }
    [SerializeField] private AudioSource _sfxAudiosource;
    [SerializeField] private AudioSource _musicAudioSource;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void PlaySFX(AudioClip clip)
    {
        _sfxAudiosource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip music)
    {
        _musicAudioSource.PlayOneShot(music);
    }

    public void PlayResource(AudioResource resource)
    {
        _sfxAudiosource.resource = resource;
        _sfxAudiosource.Play();
    }

    public void SetSFXVolume(float volume)
    {
        Debug.Log("SFX: " +  volume);
        MainMixer.SetFloat("SFXVolume", floatToDB(volume));
    }

    public void SetMusicVolume(float volume)
    {
        MainMixer.SetFloat("MusicVolume", floatToDB(volume));
    }

    private float floatToDB(float f)
    {
        return f > 0.0001f ? Mathf.Log10(f) * 20f : -80f;
    }
}
