using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    private int _goodAnswerCount = 0;
    private int _badAnswerCount = 0;

    private int _scenarioCount = 0;

    public Button goodAnswerButton;
    public Button badAnswerButton;

    public void Start()
    {
        // Set up the click listeners for the buttons
        goodAnswerButton.onClick.AddListener(() => OnAnswerClicked(true));
        badAnswerButton.onClick.AddListener(() => OnAnswerClicked(false));
    }

    public void OnAnswerClicked(bool isGoodAnswer)
    {
        if (isGoodAnswer)
        {
            _goodAnswerCount++;
        }
        else
        {
            _badAnswerCount++;
        }
        
        _scenarioCount++;
        
        if (_scenarioCount > 0)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene (assuming it is the next in the build order)
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}