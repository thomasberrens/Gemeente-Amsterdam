using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private string audioKey = "audioValue";
    private float audioValue = 1.0f;

    void Start()
    {
        // Load the audio value from PlayerPrefs
        audioSource.volume = PlayerPrefs.GetFloat(audioKey, 1.0f);;
    }

    public void PlayAudio(AudioClip audioClip, bool isSoundEffect)
    {
        if (isSoundEffect)
        {
            audioSource.PlayOneShot(audioClip);
        }
        else
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    public bool isAudioPlaying()
    {
        return audioSource.isPlaying;
    }

    public void PauseAudio()
    {
        audioSource.Pause();
    }

    public void UnpauseAudio()
    {
        audioSource.UnPause();
    }
    
    
}