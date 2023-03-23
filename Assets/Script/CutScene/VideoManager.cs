using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    // Class representing a single cutscene
    [System.Serializable]
    public class Cutscene
    { 
        [field: SerializeField]public VideoClip videoClip { get; set; }                // The video clip to play during the cutscene
       [field: SerializeField] public GameObject[] objectsToDisable { get; set; } // GameObjects to disable during the cutscene
       [field: SerializeField] public GameObject[] ObjectsToEnable { get; set; } // GameObjects to enable after the cutscene
    }

    [field: SerializeField]public RawImage RawImage { get; set; } 
    public List<Cutscene> cutscenes { get; set; }                // List of cutscenes
    public GameObject player { get; set; }                      // Reference to player GameObject
    private bool _cutscenePlaying = false;           // Flag to check if cutscene is currently playing

    public void Start()
    {
        PlayCutscene(0);
    }

    public void PlayCutscene(int cutsceneIndex)
    {
        if (_cutscenePlaying)
            return;

        _cutscenePlaying = true;

        // Disable objects that need to be disabled during the cutscene
        foreach (GameObject obj in cutscenes[cutsceneIndex].objectsToDisable)
        {
            obj.SetActive(false);
        }

        // Play the video clip for the cutscene
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.targetTexture = renderTexture;
        videoPlayer.clip = cutscenes[cutsceneIndex].videoClip;
        RawImage.texture = renderTexture;

        // Enable the RawImage before playing the video
        RawImage.enabled = true;

        videoPlayer.Play();
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        _cutscenePlaying = false;

        // Disable the RawImage
        RawImage.enabled = false;

        // Stop the video playback
        vp.Stop();

        // Enable objects that were disabled during the cutscene
        foreach (GameObject obj in cutscenes[GetPlayingCutsceneIndex()].ObjectsToEnable)
        {
            obj.SetActive(true);
        }

        // Re-enable the player's collider so they can move and interact with objects again
        player.GetComponent<Collider2D>().enabled = true;
    }

    private int GetPlayingCutsceneIndex()
    {
        // Loop through all the cutscenes and find the one that is currently playing
        for (int i = 0; i < cutscenes.Count; i++)
        {
            if (GetComponent<VideoPlayer>().clip == cutscenes[i].videoClip)
                return i;
        }

        // If no cutscene is playing, return -1
        return -1;
    }

    private void Awake()
    {
        // Add listener for when the video finishes playing
        GetComponent<VideoPlayer>().loopPointReached += OnVideoFinished;
    }
}