using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    /// <summary>
    /// Switches to the specified scene.
    /// </summary>
    /// <param name="sceneName">The name of the scene to switch to.</param>
    public static void SwitchScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
