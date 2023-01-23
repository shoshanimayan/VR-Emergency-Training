using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;


public class handshake : MonoBehaviour
{
     
    //private Variables
    
    private XRRayInteractor _xrray;
     private LineRenderer _linerender;
     private XRInteractorLineVisual _xrLineVis;

    [SerializeField] private XRNode _handType;

    //private methods
    
    private void Awake()
    {
        _xrray = GetComponent<XRRayInteractor>();
        _linerender = GetComponent<LineRenderer>();
        _xrLineVis = GetComponent<XRInteractorLineVisual>();
    }
    private void Update()
    {
        bool grip = false;
       
        InputDevice hand = InputDevices.GetDeviceAtXRNode(_handType);
        hand.TryGetFeatureValue(CommonUsages.gripButton, out grip);

        if (grip) { 

            _linerender.enabled = true;
            _xrLineVis.enabled = true;
            _xrray.maxRaycastDistance = 30;
        }
        else{

             _linerender.enabled = false;
            _xrLineVis.enabled = false;
            _xrray.maxRaycastDistance = .5f;


        }

    }

}
