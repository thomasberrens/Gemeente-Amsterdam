
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    // Class representing a single cutscene
    [System.Serializable]
    public class Cutscene
    { 
        [field: SerializeField]public VideoClip VideoClip { get; set; }                // The video clip to play during the cutscene
    }
    [field: SerializeField] public RawImage RawImage { get; set; }
    [field: SerializeField] public UnityEvent OnVideoEnd { get; private set; }
    
    [SerializeField] private VideoPlayer videoPlayer;
    
    private bool cutscenePlaying = false;           // Flag to check if cutscene is currently playing  

    /// <summary>
    /// Plays the provided cutscene video clip. If a cutscene is already playing, the method returns without playing the new clip.
    /// </summary>
    /// <param name="videoClip">The VideoClip to play for the cutscene.</param>
    public void PlayCutscene(VideoClip videoClip)
    {
        if (cutscenePlaying)
            return;

        cutscenePlaying = true;

        // Play the video clip for the cutscene
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        videoPlayer.targetTexture = renderTexture;
        // videoPlayer.clip = videoClip;
    //    videoPlayer.url = videoClip.originalPath;
        videoPlayer.url = "https://thomasberrens.github.io/Gemeente-Amsterdam/public/" + videoClip.name + ".mp4";
        RawImage.texture = renderTexture;

        // Enable the RawImage before playing the video
        RawImage.enabled = true;
        
        RawImage.gameObject.SetActive(true);

        videoPlayer.Play();
    }
    // TODO: remove this function
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            videoPlayer.time = videoPlayer.length;
        }
    }

    /// <summary>
    /// Event handler for when the cutscene video finishes playing. Disables the RawImage, stops video playback, and invokes the OnVideoEnd event.
    /// </summary>
    /// <param name="vp">The VideoPlayer that finished playing the video.</param>
    private void OnVideoFinished(VideoPlayer vp)
    {
        cutscenePlaying = false;

        // Disable the RawImage
        RawImage.enabled = false;
        
        RawImage.gameObject.SetActive(false);

        // Stop the video playback
        vp.Stop();
        
        OnVideoEnd?.Invoke();
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// This method adds the OnVideoFinished event handler to the videoPlayer's loopPointReached event.
    /// </summary>
    private void Awake()
    {
        // Add listener for when the video finishes playing
        videoPlayer.loopPointReached += OnVideoFinished;
    }
}