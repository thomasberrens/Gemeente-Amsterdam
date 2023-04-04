using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Tooltip("IMPORTANT: This prefab needs to be part of a canvas!!!.")]
    public static bool GameIsPaused = false;
    
    [SerializeField] private GameObject pauseUiElements;
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        
        if (GameIsPaused) Resume();
        else Pause();
    }

    public void Resume()
    {
        pauseUiElements.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    private void Pause()
    {
        pauseUiElements.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
}
