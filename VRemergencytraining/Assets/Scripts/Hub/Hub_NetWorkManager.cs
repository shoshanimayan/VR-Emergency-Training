using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hub_NetWorkManager : MonoBehaviour
{
    public void Login(string username, string password)
    {
        SceneManager.LoadScene(1);

    }

    public void SignUp(string username, string email, string password)
    {
        SceneManager.LoadScene(1);

    }

}
