using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> DontDestroyOnLoadObjects = new List<GameObject>();
    public static GameManager Instance {get; private set; }
    public PlayerInfo PlayerInfo { get; set; } = new PlayerInfo();

    [field: SerializeField] public string API_URL = "http://localhost:8080/";

    [field: SerializeField] public string FILES_URL { get; private set; } = "https://thomasberrens.github.io/Gemeente-Amsterdam/public/";

    private void Awake()
    {
        Instance ??= this;
        
        // Set up the resolution and fullscreen mode for web build
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
        Screen.fullScreen = true;

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

    public void SetUUID(string UUID)
    {
        PlayerInfo.UUID = UUID;
    }

    public void RegisterGameInfo()
    {
        JsonObject jsonObject = new JsonObject();
        
        jsonObject.AddField("playerID", PlayerInfo.UUID);

        string json = JsonAdapter.Serialize(jsonObject);
            
        Debug.Log("JSON: " + json);
            
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var client = new HttpClient();
        var response =  client.PostAsync(API_URL + "gameinfo/create", content).Result;

        string responseContent = response.Content.ReadAsStringAsync().Result;

        if (!response.IsSuccessStatusCode)
        {
            Debug.Log("Couldn't verify ID.");
            return;
        }
        

        JsonObject responseJson = JsonAdapter.ToJsonObject(responseContent);

        string gameID = responseJson.GetField("gameID").ToString();
        
        
        PlayerInfo.GameID = gameID;
    }
    
}
