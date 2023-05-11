using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set; }

    [field: SerializeField]
    public string FILES_URL { get; private set; } = "https://thomasberrens.github.io/Gemeente-Amsterdam/public/";

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
