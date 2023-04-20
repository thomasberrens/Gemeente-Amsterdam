using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    //IMPORTANT: This prefab needs to be part of a canvas!!!
    private bool gameIsPaused = false;
    private bool isInMainMenu = false;
    
    [SerializeField] private GameObject pauseUiElements;
    [SerializeField] private GameObject settingsUiElements;
    [SerializeField] private GameObject mainMenuUiElements;

    private void Awake()
    {
        try { isInMainMenu = mainMenuUiElements.activeSelf; }
        catch (Exception e)
        {
            isInMainMenu = false;
        }
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape) || isInMainMenu) return;
        
        if (gameIsPaused) Resume();
        else Pause();
    }

    public void Resume()
    {
        pauseUiElements.SetActive(false);
        Time.timeScale = 1;
        AudioManager.Instance.UnpauseAudio();
        gameIsPaused = false;
    }

    private void Pause()
    {
        pauseUiElements.SetActive(true);
        Time.timeScale = 0;
        AudioManager.Instance.PauseAudio();
        gameIsPaused = true;
    }

    public void ShowSettings()
    {
        settingsUiElements.SetActive(true);
        
        if (mainMenuUiElements.activeSelf)
        {
            mainMenuUiElements.SetActive(false);
        }

        if (!gameIsPaused) return;
        pauseUiElements.SetActive(false);
    }

    public void CloseSettings()
    {
        settingsUiElements.SetActive(false);
        
        if (!mainMenuUiElements.activeSelf && !gameIsPaused)
        {
            mainMenuUiElements.SetActive(true);
        }

        if (!gameIsPaused) return;
        pauseUiElements.SetActive(true);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
