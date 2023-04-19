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

    private AudioManager audioManager;

    [SerializeField] private GameObject pauseUiElements;
    [SerializeField] private GameObject settingsUiElements;
    [SerializeField] [CanBeNull] private GameObject mainMenuUiElements;
    [SerializeField] private List<GameObject> objectsToDisabled;
    

    private void Awake()
    {
        audioManager = GameObject.Find("GameManager").GetComponent<AudioManager>();
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
        foreach (var obj in objectsToDisabled)
            obj.SetActive(true);
        Time.timeScale = 1;
        audioManager.UnpauseAudio();
        gameIsPaused = false;
    }

    private void Pause()
    {
        pauseUiElements.SetActive(true);
        foreach (var obj in objectsToDisabled)
            obj.SetActive(false);
        Time.timeScale = 0;
        if (!audioManager.isAudioPlaying())
        {
            AudioClip audioClip = Resources.Load<AudioClip>("Assets/Sounds/AnimalCrossing");
            audioManager.PlayAudio(audioClip, false);
        }
        audioManager.PauseAudio();
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
