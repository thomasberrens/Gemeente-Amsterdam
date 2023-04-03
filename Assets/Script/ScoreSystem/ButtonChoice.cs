using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChoice : MonoBehaviour
{
    public bool isGoodAnswer;

    private ScoreSystem _scoreSystem;

    void Start()
    {
        // Get the GameManager object and cache a reference to it
        _scoreSystem = GameObject.FindObjectOfType<ScoreSystem>();
    }

    public void OnButtonClick()
    {
        // Call the OnAnswerClicked function on the GameManager object
        _scoreSystem.OnAnswerClicked(isGoodAnswer);
    }
}