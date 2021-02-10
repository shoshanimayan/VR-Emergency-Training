using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class hoverInfo : XRBaseInteractable
{
    
	public Text debug;
	public string message;
    protected override void Awake()
    {
        base.Awake();
        onHoverEnter.AddListener(on);
        onHoverExit.AddListener(off);
        
    }
    
    public void on(XRBaseInteractor interactor) {
		debug.enabled = true;
		debug.text = message;
        if (!GameManager.hintsChecked.Contains(gameObject)) {
            GameManager.hintsChecked.Add(gameObject);
        }
 }

	public void off(XRBaseInteractor interactor) {
		debug.enabled = false;
 }
    
}
