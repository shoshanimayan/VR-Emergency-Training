
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System;

public class Hub_NetWorkManager : MonoBehaviour
{
    /////////////////// 
    //private variables
    ///////////////////
    private Hub_PanelManager _panelManager;

    /////////////////// 
    //private methods
    //////////////////
    private void Awake()
    {
        _panelManager = GetComponent<Hub_PanelManager>();
        CheckConnect();
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
    /////////////////// 
    //public API
    //////////////////
    public async void Login(string username, string password)
    {
        using var www = UnityWebRequest.Get(Constants.url + $"login?username={username}&password={password}");
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

                if (jsonResponse.Contains("Success"))
                {
                    _panelManager.OnLineStart();
                }
                else
                {
                   _panelManager.ErrorMessager("Failed to login");

                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }

        }
        else
        {
            try
            {
                _panelManager.ErrorMessager(www.result.ToString());
            }
            catch (Exception e)
            {
                Debug.LogError("Not able to connect to panel manager\n" + e.Message);
            }
        }

    }

    public async void SignUp(string username, string email, string password)
    {
        string json = "{\"username\": \"" + username + "\", \"password\": \"" + password + "\", \"email\": \"" +email+ "\"}";
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
        using var www = new UnityWebRequest(Constants.url + "createUser", "POST");
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

                if (jsonResponse.Contains("Success"))
                {
                    _panelManager.OnLineStart();
                }
                else
                {
                    _panelManager.ErrorMessager("Failed to create account");

                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
        else
        {
            try
            {
                GetComponent<Hub_PanelManager>().ErrorMessager(www.result.ToString());
            }
            catch (Exception e)
            {
                Debug.LogError("Not able to connect to panel manager\n" + e.Message);
            }
        }

    }


}
