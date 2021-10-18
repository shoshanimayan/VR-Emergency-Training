using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AssetReference _scene;
    private SceneLoader _sceneLoader { get { return SceneLoader.Instance; } }

    public void LoadScene()
    {
        _sceneLoader.Load(_scene);
    }


}
