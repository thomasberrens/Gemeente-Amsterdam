using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

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
        UnityWebRequest www = new UnityWebRequest(API_URL + "gameinfo/create", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        www.uploadHandler = new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");

        www.SendWebRequest().completed += operation =>
        {
            Debug.Log("Result: " + www.result);

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Couldn't verify ID.");
            }
            else
            {
                string responseContent = www.downloadHandler.text;
                JsonObject responseJson = JsonAdapter.ToJsonObject(responseContent);
                string gameID = responseJson.GetField("gameID").ToString();
                PlayerInfo.GameID = gameID;

                SceneController.SwitchScene("MainScene");
            }
        } ;
    }

}
