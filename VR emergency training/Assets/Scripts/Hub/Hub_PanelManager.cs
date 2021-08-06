using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Hub_PanelManager : MonoBehaviour
{
    [SerializeField] GameObject[] _panelList;

    [SerializeField] TextMeshProUGUI _loginUsername;
    [SerializeField] TextMeshProUGUI _loginPassword;

    [SerializeField] TextMeshProUGUI _signupUsername;
    [SerializeField] TextMeshProUGUI _signupPassword;
    [SerializeField] TextMeshProUGUI _signupEmail;

    private Hub_NetWorkManager network;

    private void Awake()
    {
        network = GetComponent<Hub_NetWorkManager>();
    }

    public void GoLogin() {
        _panelList[0].SetActive(false);
        _panelList[1].SetActive(true);
    }

    public void GoSignUp()
    {
        _panelList[0].SetActive(false);
        _panelList[2].SetActive(true);
    }

    public void SignUp()
    {
        network.SignUp(_signupUsername.text, _signupEmail.text,_signupPassword.text);
    }

    public void Login()
    {

        network.Login(_loginUsername.text,_loginPassword.text);
    }

    public void OffLineStart()
    {
        SceneManager.LoadScene(1);

    }


}
