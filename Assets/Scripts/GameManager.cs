using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set; }
    public PlayerInfo PlayerInfo { get; set; } = new PlayerInfo();

    private void Awake()
    {
        Instance ??= this;
        
        DontDestroyOnLoad(this);
    }
    
    /// <summary>
    /// Quits the application.
    /// </summary>

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetUserName(string userName)
    {
        PlayerInfo.Name = userName;
    }
    
}
