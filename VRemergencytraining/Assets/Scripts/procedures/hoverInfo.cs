using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
public class hoverInfo : XRBaseInteractable
{
     
    //private Variables
    
    [SerializeField] private TextMeshProUGUI debug;
    [SerializeField] private string message;

     
    //private methods
    
    protected override void Awake()
    {
        base.Awake();
        onHoverEnter.AddListener(On);
        onHoverExit.AddListener(Off);
        
    }
    
    public void On(XRBaseInteractor interactor) {
		debug.enabled = true;
		debug.text = message;
        if (!GameManager.hintsChecked.Contains(gameObject)) {
            GameManager.hintsChecked.Add(gameObject);
        }
 }

	public void Off(XRBaseInteractor interactor) {
		debug.enabled = false;
 }
    
}
