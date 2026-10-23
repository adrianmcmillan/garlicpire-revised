using UnityEngine;
using UnityEngine.Audio;

public class SoundPlayer : MonoBehaviour
{
    public AudioResource Resource;
    public AudioClip AudioClip;

    public void PlayResource()
    {
        AudioManager.Instance.PlayResource(Resource);
    }
    public void PlayAudioClip()
    {
        AudioManager.Instance.PlaySFX(AudioClip);
    }
}
