using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System;

public class NetworkManager : Singleton<NetworkManager>
{

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (GameManager.Online)
        {
            CheckConnect();
        }
    }

    private async void CheckConnect()
    {
        using var www = UnityWebRequest.Get(Constants.url);
        www.SetRequestHeader("content_Type", "application/json");
        var operation = www.SendWebRequest();
        while (!operation.isDone)
        {
            await Task.Yield();
        }
        if (www.result == UnityWebRequest.Result.Success)
        {
            GameManager.Online = true;
        }
        else
        {
            GameManager.Online = false;

        }
        Debug.Log(GameManager.Online);
    }

    public async void SendExercise(string name, string totalHint, string foundHint, string time)
    {
        string json = "{\"name\": \"" + name + "\", \"totalHint\": \"" + totalHint + "\", \"foundHint\": \"" + foundHint + "\", \"time\":\""+time+"\"}";
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);

        Debug.Log(json);
        using var www = new UnityWebRequest(Constants.url + "createExercise", "POST");
        www.uploadHandler = (UploadHandler)new UploadHandlerRaw(postData);

        www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        www.SetRequestHeader("content_Type", "application/json");
        var operation = www.SendWebRequest();
        while (!operation.isDone)
        {
            await Task.Yield();
        }
        if (www.result == UnityWebRequest.Result.Success)
        {
            var jsonResponse = www.downloadHandler.text;
            try
            {
                Debug.Log(jsonResponse);
                if (!jsonResponse.Contains("exerciseAdded"))
                {
                    Debug.LogError(jsonResponse);

                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
        else
        {
            Debug.LogError(www.result.ToString());
        }

    }

}
