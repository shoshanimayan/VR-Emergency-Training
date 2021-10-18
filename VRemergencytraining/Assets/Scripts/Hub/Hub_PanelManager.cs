using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.AddressableAssets;

public class Hub_PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _panelList;

    [SerializeField] private TextMeshProUGUI _ErrorText;

    [SerializeField] private GameObject _back;

    [SerializeField] private TextMeshProUGUI _loginUsername;
    [SerializeField] private TextMeshProUGUI _loginPassword;

    [SerializeField] private TextMeshProUGUI _signupUsername;
    [SerializeField] private TextMeshProUGUI _signupPassword;
    [SerializeField] private TextMeshProUGUI _signupEmail;
    [SerializeField] private AssetReference _scene;

    private Hub_NetWorkManager network;
    private char[] _trim = { '*', ' ', '\'' };
    private SceneLoader _sceneLoader { get { return SceneLoader.Instance; } }

    private void Awake()
    {
        network = GetComponent<Hub_NetWorkManager>();
        _back.SetActive(false);

    }

    public void GoLogin() {
        if (GameManager.Online)
        {
            _panelList[0].SetActive(false);
            _panelList[1].SetActive(true);
        }
        else 
        {
            ErrorMessager("could not connect to API, please use offline demo");

        }
    }

    public void Back() 
    {
        _panelList[2].SetActive(false);
        _panelList[1].SetActive(false);
        _panelList[0].SetActive(true);
        _back.SetActive(false);
    }



    public void GoSignUp()
    {
        if (GameManager.Online)
        {
            _panelList[0].SetActive(false);
            _panelList[2].SetActive(true);
            _back.SetActive(true);

        }
        else
        {
            ErrorMessager("could not connect to API, please use offline demo");
        }
    }

    public void SignUp()
    {
        if (_signupUsername.text.Remove(_signupUsername.text.Length - 1).Trim(_trim).Length > 0 && _signupPassword.text.Remove(_signupPassword.text.Length - 1).Trim(_trim).Length > 0)
        {
            Debug.Log(_signupUsername.text.Remove(_signupUsername.text.Length - 1).Trim(_trim));
            network.SignUp(_signupUsername.text.Remove(_signupUsername.text.Length - 1).Trim(_trim), _signupEmail.text.Remove(_signupEmail.text.Length - 1).Trim(_trim), _signupPassword.text.Remove(_signupPassword.text.Length - 1).Trim(_trim));
            _back.SetActive(true);
        }
        else {
            ErrorMessager("missing field");
        }

    }

    public void Login()
    {
        if (_loginUsername.text.Remove(_loginUsername.text.Length - 1).Trim(_trim).Length > 0 && _loginPassword.text.Remove(_loginPassword.text.Length - 1).Trim(_trim).Length > 0)
        {
            network.Login(_loginUsername.text.Remove(_loginUsername.text.Length - 1).Trim(_trim), _loginPassword.text.Remove(_loginPassword.text.Length - 1).Trim(_trim));
        }
        else
        {
            ErrorMessager("missing field");
        }
    }

    public void OffLineStart()
    {
        GameManager.Online = false;
        _sceneLoader.Load(_scene);
        
    }

    public void OnLineStart()
    {
        _sceneLoader.Load(_scene);
    }

    public void ErrorMessager(string msg)
    {
        _ErrorText.text = msg;
    }


}
