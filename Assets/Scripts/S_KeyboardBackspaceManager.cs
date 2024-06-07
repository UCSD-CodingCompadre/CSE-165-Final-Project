using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class S_KeyboardBackspaceManager : MonoBehaviour
{

    // Hold a reference to the TextInputManager script
    public S_TextInputManager TextInputScript;

    /*
     * @param OnSelectEnter remove the last letter if possible
     * @param SelectEnterEventArgs arguements used for the Select Enter event
     * @return void
     */
    public void OnSelectEntered(SelectEnterEventArgs args)
    {

        // Remove a letter from the text input
        TextInputScript.Backspace();
    }
}
