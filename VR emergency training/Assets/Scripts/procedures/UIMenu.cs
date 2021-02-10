using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIMenu : MonoBehaviour
{
    public GameObject instructions;
    public Procedure procedure;
   
    private GameObject board;
    public static string AfterText;
    public static bool reset = false;
    public Text info;
    // Start is called before the first frame update
    void Awake()
    {
        board = transform.parent.gameObject;
        if (reset) {
            info.text = AfterText;
            reset = false;
        }

    }
    public void Update() {

        if (reset)
        {
            info.text = AfterText;
            reset = false;
        }
    }
    public void CloseInstructions() {

        instructions.SetActive(false);
    }
    public void Close() {
        board.SetActive(false);
    }

    public void StartProcedure() {
        CloseInstructions();
        procedure.Initiate();
        Close();
    }

    
}
