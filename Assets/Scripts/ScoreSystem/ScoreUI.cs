using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// This method retrieves the current and maximum scores from the ScoreManager and displays them in the scoreText UI element.
    /// </summary>
    private void Awake()
    {
        ScoreManager scoreManager = ScoreManager.Instance;
        scoreText.text = scoreManager.CurrentScore + "/" + scoreManager.MaxScore;
    }
}
