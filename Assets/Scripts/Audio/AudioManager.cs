using UnityEngine;

/// <summary>
/// Manages the audio playback in the game.
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    private AudioSource audioSource;
    private GameObject camera;
    private string audioKey = "AudioValue";
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

    /// <summary>
    /// Plays the specified audio clip.
    /// </summary>
    /// <param name="audioClipName">The name of the audio clip to play.</param>
    public void PlayAudio(string audioClipName)
    {
        // Make sure to put the audio in the map: Assets/Recources/Audio/
        GetAudioSource();
        AudioClip audioClip = Resources.Load<AudioClip>("Audio/" + audioClipName);
        audioSource.clip = audioClip;
        audioSource.volume = PlayerPrefs.GetFloat(audioKey, 1.0f);
        audioSource.Play();
    }

    /// <summary>
    /// Plays a sound effect using the specified audio clip.
    /// </summary>
    /// <param name="audioClipName">The name of the audio clip to play as a sound effect.</param>
    public void PlaySoundEffect(string audioClipName)
    {
        // Make sure to put the audio in the map: Assets/Recources/Audio/
        GetAudioSource();
        AudioClip audioClip = Resources.Load<AudioClip>("Audio/" + audioClipName);
        audioSource.volume = PlayerPrefs.GetFloat(audioKey, 1.0f);
        audioSource.PlayOneShot(audioClip);
    }

    /// <summary>
    /// Checks if audio is currently playing.
    /// </summary>
    /// <returns><c>true</c> if audio is playing; otherwise, <c>false</c>.</returns>
    public bool isAudioPlaying()
    {
        return audioSource.isPlaying;
    }

    /// <summary>
    /// Pauses the audio playback.
    /// </summary>
    public void PauseAudio()
    {
        audioSource.Pause();
    }

    /// <summary>
    /// Unpauses the audio playback.
    /// </summary>
    public void UnpauseAudio()
    {
        audioSource.UnPause();
    }
}