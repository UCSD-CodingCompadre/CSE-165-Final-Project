using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class S_KeyboardEnterManager : XRBaseInteractable
{

    // Hold a reference to the TextInputManager script
    public S_TextInputManager TextInputScript;

    /*
     * @param OnSelectEnter enter a symptom and add it to the list
     * @param SelectEnterEventArgs arguements used for the Select Enter event
     * @return void
     */
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {

        // Add a symptom to the symptom list
        TextInputScript.Enter();
    }
}
