using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set; }
    [SerializeField] private AudioSource audioSource;
    private string audioKey = "audioValue";
    private float audioValue = 1.0f;

    private void Awake()
    {
        Instance ??= this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        // Load the audio value from PlayerPrefs
        audioSource.volume = PlayerPrefs.GetFloat(audioKey, 1.0f);
    }

    public void PlayAudio(string audioClipName)
    {
        // Make sure to put the audio in the map: Assets/Recources/Audio/
        AudioClip audioClip = Resources.Load<AudioClip>("Audio/" + audioClipName );
        audioSource.clip = audioClip;
        audioSource.Play();
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