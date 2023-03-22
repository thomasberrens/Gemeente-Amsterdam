using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher
{
    public static void SwitchScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
