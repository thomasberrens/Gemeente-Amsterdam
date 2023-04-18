using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    [SerializeField] private Toggle toggleButton;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Slider soundSlider;
    
    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.
    /// This method sets up the initial screen resolution, full-screen mode, sound slider value, and event listeners for UI elements.
    /// </summary>
    private void Start()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
        Screen.fullScreen = true;
        
        soundSlider.value = PlayerPrefs.GetFloat("AudioValue", 1f);
        toggleButton.onValueChanged.AddListener(OnToggleValueChanged);
        soundSlider.onValueChanged.AddListener(OnSliderValueChanged);
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
    }

    /// <summary>
    /// Sets the screen resolution based on the selected index in the resolution dropdown menu.
    /// </summary>
    /// <param name="index">The index of the selected resolution option in the dropdown menu.</param>
    private void SetResolution(int index)
    {
        string[] option = resolutionDropdown.options[index].text.Split('x');
        int width = int.Parse(option[0]);
        int height = int.Parse(option[1]);
        //this will only work if the application is build
        Screen.SetResolution(width, height, Screen.fullScreen);
    }
    
    /// <summary>
    /// Sets the full-screen mode based on the value of the toggle button.
    /// </summary>
    /// <param name="value">The value of the toggle button (true for maximized window, false for windowed mode).</param>
    private void OnToggleValueChanged(bool value)
    {
        Screen.fullScreenMode = value ? FullScreenMode.MaximizedWindow : FullScreenMode.Windowed;
    }

    /// <summary>
    /// Saves the audio slider value in PlayerPrefs under the key "AudioValue".
    /// </summary>
    /// <param name="value">The value of the audio slider.</param>
    private void OnSliderValueChanged(float value)
    {
        PlayerPrefs.SetFloat("AudioValue", value);
    }
}
