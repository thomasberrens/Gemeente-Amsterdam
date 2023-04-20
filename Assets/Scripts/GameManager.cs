using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set; }

    private void Awake()
    {
        Instance ??= this;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
