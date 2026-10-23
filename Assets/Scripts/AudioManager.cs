using System.Collections;
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
        if (!Globals.initialized)
        {
            Globals.Initialize();
        }
        DontDestroyOnLoad(gameObject);
        StartCoroutine(DelayedVolumeSet());
    }


    public void PlaySFX(AudioClip clip)
    {
        _sfxAudiosource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip music)
    {
        if (_musicAudioSource.clip == music)
        {
            return;
        }
        if (_musicAudioSource.isPlaying)
        {
            StartCoroutine(MusicFadeOut(music));
        } else
        {
            _musicAudioSource.clip = music;
            _musicAudioSource.Play();
        }
    }

    public void PlayResource(AudioResource resource)
    {
        _sfxAudiosource.resource = resource;
        _sfxAudiosource.Play();
    }

    public void SetSFXVolume(float volume)
    {
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

    private IEnumerator DelayedVolumeSet()
    {
        float timer = 0.2f;
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        Debug.Log(Globals.SFXVolume);
        Debug.Log(Globals.MusicVolume);
        SetSFXVolume(Globals.SFXVolume);
        SetMusicVolume(Globals.MusicVolume);
        yield break;
    }

    private IEnumerator MusicFadeOut(AudioClip newMusic) {
        float timer = 0.3f;
        float newVolume;
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            newVolume = Mathf.Lerp(0, 1, timer / 0.3f);
            _musicAudioSource.volume = newVolume;
            yield return null;
        }
        _musicAudioSource.Stop();
        _musicAudioSource.volume = 1f;
        _musicAudioSource.clip = newMusic;
        _musicAudioSource.Play();
        yield break;
    }
}
