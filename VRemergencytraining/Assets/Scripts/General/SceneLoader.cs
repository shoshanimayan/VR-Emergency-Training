using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using System.Linq;
using UnityEngine.XR.Interaction.Toolkit;

public class SceneLoader : Singleton<SceneLoader>
{
    [SerializeField]
    private AssetReference firstScene;
    private AsyncOperationHandle<SceneInstance> handle;
    private bool unloaded;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 90;
        if (Unity.XR.Oculus.Performance.TryGetDisplayRefreshRate(out var rate))
        {
            float newRate = 90f; // fallback to this value if the query fails.
            if (Unity.XR.Oculus.Performance.TryGetAvailableDisplayRefreshRates(out var rates))
            {
                newRate = rates.Max();
            }
            if (rate < newRate)
            {
                if (Unity.XR.Oculus.Performance.TrySetDisplayRefreshRate(newRate))
                {
                    Time.fixedDeltaTime = 1f / newRate;
                    Time.maximumDeltaTime = 1f / newRate;
                }
            }
        }
    }

    void Start()
    {
        //Addressables.LoadSceneAsync(firstScene, UnityEngine.SceneManagement.LoadSceneMode.Additive).Completed += SceneLoadCompleted;
        FirstLoad();
    }

    public void FirstLoad()
    {
        Addressables.LoadSceneAsync(firstScene, UnityEngine.SceneManagement.LoadSceneMode.Additive).Completed += SceneLoadCompleted;

    }

    public IEnumerator ResetCamera()
    {

        yield return new WaitForEndOfFrame();

        FindObjectOfType<XRRig>().transform.eulerAngles = Vector3.zero;
    }

    // Start is called before the first frame update
    public void Load(AssetReference scene)
    {
        Debug.Log("loading level");
        if (!unloaded)
        {
            unloaded = true;
            UnloadScene();
        }
        Addressables.LoadSceneAsync(scene, UnityEngine.SceneManagement.LoadSceneMode.Additive).Completed += SceneLoadCompleted;
    }

    private void SceneLoadCompleted(AsyncOperationHandle<SceneInstance> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log("Successfully loaded scene.");
            handle = obj;
            unloaded = false;
            StartCoroutine(ResetCamera());
        }
    }



    private void UnloadScene()
    {
        Debug.Log("unloading level");
        Debug.Log(handle);
        Addressables.UnloadSceneAsync(handle, true).Completed += op =>
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
                Debug.Log("Successfully unloaded scene.");
            else
            {
                Debug.Log(op.Status.ToString());
            }
        };
    }
}