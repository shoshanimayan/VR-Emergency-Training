using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AirplaneNavigation : MonoBehaviour
{
    public void LoadPlane()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadOffice()
    {
        SceneManager.LoadScene(1);
    }
}