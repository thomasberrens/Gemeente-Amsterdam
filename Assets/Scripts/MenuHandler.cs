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
    [SerializeField] [CanBeNull] private GameObject mainMenuUiElements;
    [SerializeField] private List<GameObject> objectsToDisabled;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// This method checks if the user is in the main menu or not.
    /// </summary>
    private void Awake()
    {
        try { isInMainMenu = mainMenuUiElements.activeSelf; }
        catch (Exception e)
        {
            isInMainMenu = false;
        }
    }

    /// <summary>
    /// Update is called once per frame. 
    /// This method checks if the Escape key is pressed and toggles the game's pause state accordingly.
    /// </summary>
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape) || isInMainMenu) return;
        
        if (gameIsPaused) Resume();
        else Pause();
    }

    /// <summary>
    /// Resumes the game by hiding the pause UI elements, enabling specified objects, and resuming time.
    /// </summary>
    public void Resume()
    {
        pauseUiElements.SetActive(false);
        foreach (var obj in objectsToDisabled)
            obj.SetActive(true);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    /// <summary>
    /// Pauses the game by displaying the pause UI elements, disabling specified objects, and freezing time.
    /// </summary>
    private void Pause()
    {
        pauseUiElements.SetActive(true);
        foreach (var obj in objectsToDisabled)
            obj.SetActive(false);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    /// <summary>
    /// Displays the settings UI elements and hides the main menu or pause UI elements if necessary.
    /// </summary>
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

    
    /// <summary>
    /// Closes the settings UI elements and displays the main menu or pause UI elements if necessary.
    /// </summary>
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

    /// <summary>
    /// Quits the application.
    /// </summary>
    public static void QuitGame()
    {
        Application.Quit();
    }
}
