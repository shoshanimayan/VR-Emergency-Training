using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToOffice : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadOffice()
    {
        SceneManager.LoadScene(0);
    }
}