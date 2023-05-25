using System.Text;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> dontDestroyOnLoadObjects = new List<GameObject>();
    public static GameManager Instance {get; private set; }
    public PlayerInfo PlayerInfo { get; set; } = new PlayerInfo();
    
    [field: SerializeField] public string ApiURL { get; private set; } = "http://localhost:8080/";
    [field: SerializeField] public string FilesURL { get; private set; } = "https://thomasberrens.github.io/Gemeente-Amsterdam/public/";
    
    [SerializeField] private TMP_Text authenticationFeedback;
    private void Awake()
    {
        Instance ??= this;

        // Set up the resolution and fullscreen mode for web build
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
        Screen.fullScreen = true;

        for (int i = 0; i < dontDestroyOnLoadObjects.Count; i++)
        {
            DontDestroyOnLoad(dontDestroyOnLoadObjects[i]);
        }
    }

    /// <summary>
    /// Quits the application.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Sets the UUID for the player.
    /// </summary>
    /// <param name="UUID">The UUID to set.</param>
    public void SetUUID(string UUID)
    {
        PlayerInfo.UUID = UUID;
    }

    /// <summary>
    /// Registers the game info for the player.
    /// </summary>
    public void RegisterGameInfo()
    {
        JsonObject jsonObject = new JsonObject();

        jsonObject.AddField("playerID", PlayerInfo.UUID);

        string json = JsonAdapter.Serialize(jsonObject);
        
        UnityWebRequest www = new UnityWebRequest(ApiURL + "gameinfo/create", "POST");
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
                if (authenticationFeedback == null) return;
                StartCoroutine(ShowAuthenticationFeedback());
            }
            else
            {
                string responseContent = www.downloadHandler.text;
                JsonObject responseJson = JsonAdapter.ToJsonObject(responseContent);
                string gameID = responseJson.GetField("gameID").ToString();
                PlayerInfo.GameID = gameID;

                SceneController.SwitchScene("MainScene");
            }
        };
    }
    /// <summary>
    /// Shows authentication failed feedback.
    /// </summary>
    private IEnumerator ShowAuthenticationFeedback()
    {
        authenticationFeedback.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        authenticationFeedback.gameObject.SetActive(false);
    }

}