using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set; }

    private void Awake()
    {
        Instance ??= this;
    }
    
    /// <summary>
    /// Quits the application.
    /// </summary>

    public void QuitGame()
    {
        Application.Quit();
    }
}
