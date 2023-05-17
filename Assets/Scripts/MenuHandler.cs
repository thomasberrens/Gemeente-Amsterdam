using System;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    //IMPORTANT: This prefab needs to be part of a canvas!!!
    private bool isInMainMenu = false;
    
    [SerializeField] private GameObject settingsUiElements;
    [SerializeField] private GameObject mainMenuUiElements;

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
    /// Displays the settings UI elements and hides the main menu or pause UI elements if necessary.
    /// </summary>
    public void ShowSettings()
    {
        settingsUiElements.SetActive(true);
        
        if (mainMenuUiElements.activeSelf)
        {
            mainMenuUiElements.SetActive(false);
        }
    }

    
    /// <summary>
    /// Closes the settings UI elements and displays the main menu or pause UI elements if necessary.
    /// </summary>
    public void CloseSettings()
    {
        settingsUiElements.SetActive(false);
        
        if (!mainMenuUiElements.activeSelf)
        {
            mainMenuUiElements.SetActive(true);
        }
    }

    /// <summary>
    /// Quits the application.
    /// </summary>
    public static void QuitGame()
    {
        Application.Quit();
    }
}
