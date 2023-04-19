using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    [SerializeField] private Toggle toggleButton;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Slider soundSlider;
    private string audioKey = "audioValue";

    private void Start()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
        Screen.fullScreen = true;
        soundSlider.value = PlayerPrefs.GetFloat(audioKey, 1f);
        toggleButton.onValueChanged.AddListener(OnToggleValueChanged);
        soundSlider.onValueChanged.AddListener(OnSliderValueChanged);
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
    }

    private void SetResolution(int index)
    {
        string[] option = resolutionDropdown.options[index].text.Split('x');
        int width = int.Parse(option[0]);
        int height = int.Parse(option[1]);
        //this will only work if the application is build
        Screen.SetResolution(width, height, Screen.fullScreen);
    }
    
    private void OnToggleValueChanged(bool value)
    {
        Screen.fullScreenMode = value ? FullScreenMode.MaximizedWindow : FullScreenMode.Windowed;
    }

    private void OnSliderValueChanged(float value)
    {
        PlayerPrefs.SetFloat("AudioValue", value);
    }
}
