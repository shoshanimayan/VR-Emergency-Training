using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int _scene;

    public void LoadScene()
    {
        SceneManager.LoadScene(_scene);
    }


}
