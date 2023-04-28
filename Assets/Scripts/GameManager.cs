using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
        var response =  client.PostAsync("http://localhost:8080/gameinfo/create", content).Result;

        string responseContent = response.Content.ReadAsStringAsync().Result;

        Debug.Log("Response content: " + responseContent);

        JsonObject responseJson = JsonAdapter.ToJsonObject(responseContent);

        string gameID = responseJson.GetField("gameID").ToString();
        
        Debug.Log("Game ID: " + gameID);
        
        PlayerInfo.GameID = gameID;
    }
    
}
