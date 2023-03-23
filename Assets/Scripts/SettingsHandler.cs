using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private void Start()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
    }

    private void SetResolution(int index)
    {
        string[] option = resolutionDropdown.options[index].text.Split('x');
        int width = int.Parse(option[0]);
        int height = int.Parse(option[1]);
        
        Debug.Log(width + " " + height);
        //this will only work if the application is build
        Screen.SetResolution(width, height, Screen.fullScreen);
    }
    
    private void OnToggleValueChanged(bool value)
    {
        Screen.fullScreenMode = value ? FullScreenMode.MaximizedWindow : FullScreenMode.Windowed;
    }
}
