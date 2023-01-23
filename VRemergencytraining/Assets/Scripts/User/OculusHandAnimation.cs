

using UnityEngine;
using System.Collections;
using UnityEngine.XR;

public class OculusHandAnimation : MonoBehaviour
{
     
    //private Variables
    
    
    [SerializeField] private XRNode _HandType;
    [SerializeField] private Animator _HandAnimator;

     
    //private methods
    
    private void Update()
    {
        bool grip = false;
        bool trigger = false;
        bool primaryAxisTouch = false;
        bool primaryTouch = false;
        bool secondaryTouch = false;
        float triggerDown = 0;
        InputDevice hand = InputDevices.GetDeviceAtXRNode(_HandType);
        hand.TryGetFeatureValue(CommonUsages.gripButton, out grip);
        hand.TryGetFeatureValue(CommonUsages.triggerButton, out trigger);
        hand.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out primaryAxisTouch);
        hand.TryGetFeatureValue(CommonUsages.primaryTouch, out primaryTouch);
        hand.TryGetFeatureValue(CommonUsages.secondaryTouch, out secondaryTouch);
        hand.TryGetFeatureValue(CommonUsages.trigger, out triggerDown);

        bool thumbDown = primaryAxisTouch || primaryTouch || secondaryTouch;

        float triggerTotal = 0f;
        if (trigger)
        {
            triggerTotal = 0.1f;
        }
        if (triggerDown > 0.1f)
        {
            triggerTotal = triggerDown;
        }

        _HandAnimator.SetBool("GrabbingGrip", grip);
        _HandAnimator.SetBool("ThumbUp", !thumbDown);
        _HandAnimator.SetFloat("TriggerDown", triggerTotal);
    }
}