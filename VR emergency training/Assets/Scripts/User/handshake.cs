using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;


public class handshake : MonoBehaviour
{
    public XRRayInteractor xrray;
    public LineRenderer linerender;
    public XRInteractorLineVisual XRlineVis;

    public XRNode HandType;
    private void Update()
    {
        bool grip = false;
       

        //1. Collect controller data
        InputDevice hand = InputDevices.GetDeviceAtXRNode(HandType);
        hand.TryGetFeatureValue(CommonUsages.gripButton, out grip);

        if (grip) { //xrray.enabled = true;

            linerender.enabled = true;
            XRlineVis.enabled = true;
            xrray.maxRaycastDistance = 30;
        }
        else{
              //xrray.enabled = false;

             linerender.enabled = false;
            XRlineVis.enabled = false;
            xrray.maxRaycastDistance = .5f;


        }

    }

}
