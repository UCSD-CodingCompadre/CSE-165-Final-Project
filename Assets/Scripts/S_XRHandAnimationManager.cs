using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_XRHandAnimationManager : MonoBehaviour
{

    // Hold a reference to the InputActionProperty for the pinch animation
    public InputActionProperty PinchAnimationAction;

    // Hold a reference to the InputActionProperty for the grip animation 
    public InputActionProperty GripAnimationAction;

    // Hold the Animator for the animations
    public Animator HandAnimator;

    /*
     * @brief Every frame watch for the triggers of the animations
     * @param none
     * @return void
     */
    void Update()
    {

        // Set the pinch value from the Action
        float PinchValue = PinchAnimationAction.action.ReadValue<float>();

        // Set the value for the pinch animation
        HandAnimator.SetFloat("Trigger", PinchValue);

        // Set the grip value from Action
        float GripValue = GripAnimationAction.action.ReadValue<float>();

        // Set the value for the grab animation
        HandAnimator.SetFloat("Grip", GripValue);
    }
}
