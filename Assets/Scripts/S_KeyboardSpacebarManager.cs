using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
public class S_KeyboardSpacebarManager : XRBaseInteractable
{

    // Hold a reference to the TextInputManager script
    public S_TextInputManager TextInputScript;

    //Hold a reference to back button
    private Button space;

    private void Start()
    {
        space = gameObject.GetComponent<Button>();
        space.onClick.AddListener(buttonSelect);
    }
    /*
     * @param OnSelectEnter add the letter of this button
     * @param SelectEnterEventArgs arguements used for the Select Enter event
     * @return void
     */
    //protected override void OnSelectEntered(SelectEnterEventArgs args)
    public void buttonSelect()
    {

        // Add a letter to the text input
        TextInputScript.AddLetter(" ");
    }
}
