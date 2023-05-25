using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private Sprite happySmiley;
    [SerializeField] private Sprite sadSmiley;
    [SerializeField] private Sprite neutralSmiley;
    
    [SerializeField] private Image smileyPlaceholder;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// This method retrieves the current and maximum scores from the ScoreManager and displays them in the scoreText UI element.
    /// </summary>
    private void Awake()
    {
        ScoreManager scoreManager = ScoreManager.Instance;
        
        double relativeScore = scoreManager.CalculateCurrentRelativeScore();

        smileyPlaceholder.sprite = relativeScore switch
        {
            >= 5 and < 7 => neutralSmiley,
            >= 7 => happySmiley,
            < 5 => sadSmiley,
            _ => smileyPlaceholder.sprite
        };

        scoreText.text = scoreManager.CalculateCurrentRelativeScore() + " / 10";
    }
}
