using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
