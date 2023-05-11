using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> DontDestroyOnLoadObjects = new List<GameObject>();
    public static GameManager Instance {get; private set; }

    private void Awake()
    {
        Instance ??= this;

        for (int i = 0; i < DontDestroyOnLoadObjects.Count; i++)
        {
            DontDestroyOnLoad(DontDestroyOnLoadObjects[i]);
        }
    }
    
    /// <summary>
    /// Quits the application.
    /// </summary>

    public void QuitGame()
    {
        Application.Quit();
    }
}
