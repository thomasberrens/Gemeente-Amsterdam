using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    //IMPORTANT: This prefab needs to be part of a canvas!!!
    public static bool GameIsPaused = false;
    
    [SerializeField] private GameObject pauseUiElements;
    [SerializeField] private GameObject settingsUiElements;
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

    public void ShowSettings()
    {
        Debug.Log("Button Pressed");
        settingsUiElements.SetActive(true);

        if (!GameIsPaused) return;
        pauseUiElements.SetActive(false);
    }

    public void CloseSettings()
    {
        settingsUiElements.SetActive(false);

        if (!GameIsPaused) return;
        pauseUiElements.SetActive(true);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
