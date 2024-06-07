using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class S_KeyboardDoneManager : MonoBehaviour
{

    // Hold a reference to the TextInputManager script
    public S_TextInputManager TextInputScript;

    /*
     * @param OnSelectEnter finish using the keyboard and move on to the next
     * checkpoint
     * @param SelectEnterEventArgs arguements used for the Select Enter event
     * @return void
     */
    public void OnSelectEntered(SelectEnterEventArgs args)
    {

        // Remove the keyboard UI and move on to the next checkpoint
        TextInputScript.Done();
    }
}
