/*
 * Copyright (c) 2019 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;
using System.Collections;
using UnityEngine.XR;

public class OculusHandAnimation : MonoBehaviour
{
    public XRNode HandType;
    public Animator HandAnimator;

    private void Update()
    {
        bool grip = false;
        bool trigger = false;
        bool primaryAxisTouch = false;
        bool primaryTouch = false;
        bool secondaryTouch = false;
        float triggerDown = 0;

        //1. Collect controller data
        InputDevice hand = InputDevices.GetDeviceAtXRNode(HandType);
        hand.TryGetFeatureValue(CommonUsages.gripButton, out grip);
        hand.TryGetFeatureValue(CommonUsages.triggerButton, out trigger);
        hand.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out primaryAxisTouch);
        hand.TryGetFeatureValue(CommonUsages.primaryTouch, out primaryTouch);
        hand.TryGetFeatureValue(CommonUsages.secondaryTouch, out secondaryTouch);
        hand.TryGetFeatureValue(CommonUsages.trigger, out triggerDown);

        bool thumbDown = primaryAxisTouch || primaryTouch || secondaryTouch;

        //2. Trigger down
        float triggerTotal = 0f;
        if (trigger)
        {
            triggerTotal = 0.1f;
        }
        if (triggerDown > 0.1f)
        {
            triggerTotal = triggerDown;
        }

        //3. Set animations
        HandAnimator.SetBool("GrabbingGrip", grip);
        HandAnimator.SetBool("ThumbUp", !thumbDown);
        HandAnimator.SetFloat("TriggerDown", triggerTotal);
    }
}