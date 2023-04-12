using System;
using System.Collections.Generic;
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

    public void PlayCutscene(VideoClip videoClip)
    {
        if (cutscenePlaying)
            return;

        cutscenePlaying = true;

        // Play the video clip for the cutscene
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        videoPlayer.targetTexture = renderTexture;
        videoPlayer.clip = videoClip;
        RawImage.texture = renderTexture;

        // Enable the RawImage before playing the video
        RawImage.enabled = true;
        
        RawImage.gameObject.SetActive(true);

        videoPlayer.Play();
    }

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

    private void Awake()
    {
      //  PlayCutscene(0);
        // Add listener for when the video finishes playing
        videoPlayer.loopPointReached += OnVideoFinished;
    }
}