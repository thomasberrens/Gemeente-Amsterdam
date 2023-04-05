using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        ScoreManager scoreManager = ScoreManager.Instance;
        scoreText.text = scoreManager.CurrentScore + "/" + scoreManager.MaxScore;
    }
}
