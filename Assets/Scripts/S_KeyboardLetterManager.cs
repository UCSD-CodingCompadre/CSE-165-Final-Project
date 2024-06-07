using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class S_KeyboardLetterManager : XRBaseInteractable
{

    // Hold a reference to the character to append
    public string Character; 

    // Hold a reference to the TextInputManager script
    public S_TextInputManager TextInputScript;

    /*
     * @param OnSelectEnter add the letter of this button
     * @param SelectEnterEventArgs arguements used for the Select Enter event
     * @return void
     */
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {

        // Add a letter to the text input
        TextInputScript.AddLetter(Character);
    }
}
