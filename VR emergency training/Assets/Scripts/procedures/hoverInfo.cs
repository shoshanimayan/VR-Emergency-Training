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
       // onSelectEnter.AddListener(on);
       // onSelectExit.AddListener(off);
        
    }
    
    public void on(XRBaseInteractor interactor) {
		debug.enabled = true;
		debug.text = message;
 }

	public void off(XRBaseInteractor interactor) {
		debug.enabled = false;
 }
    
}
