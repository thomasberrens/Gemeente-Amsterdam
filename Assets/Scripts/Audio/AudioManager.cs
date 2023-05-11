using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set; }
    private AudioSource audioSource;
    private GameObject camera;
    private string audioKey = "audioValue";
    private string cameraTag = "MainCamera";
    private float audioValue = 1.0f;

    private void Awake()
    {
        Instance ??= this;
        DontDestroyOnLoad(this);
        GetAudioSource();
    }

    private void GetAudioSource()
    {
        camera = GameObject.FindWithTag(cameraTag);
        if (camera == null) return;
        audioSource = camera.GetComponent<AudioSource>();
        if (audioSource != null) return;
        audioSource = camera.AddComponent<AudioSource>();
    }

    // These scripts need to seperate since you can only use 1 parameter with a onClickEvent in the unity inspector
    public void PlayAudio(string audioClipName)
    {
        // Make sure to put the audio in the map: Assets/Recources/Audio/
        GetAudioSource();
        AudioClip audioClip = Resources.Load<AudioClip>("Audio/" + audioClipName);
        audioSource.clip = audioClip;
        audioSource.volume = PlayerPrefs.GetFloat(audioKey, 1.0f);
        audioSource.Play();
    }

    public void PlaySoundEffect(string audioClipName)
    {
        // Make sure to put the audio in the map: Assets/Recources/Audio/
        GetAudioSource();
        AudioClip audioClip = Resources.Load<AudioClip>("Audio/" + audioClipName);
        audioSource.volume = PlayerPrefs.GetFloat(audioKey, 1.0f);
        audioSource.PlayOneShot(audioClip);
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