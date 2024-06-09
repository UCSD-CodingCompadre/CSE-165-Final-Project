using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class S_KeyboardLetterManager : XRBaseInteractable
{

    // Hold a reference to the character to append
    public string Character; 

    // Hold a reference to the TextInputManager script
    public S_TextInputManager TextInputScript;

    // Reference to button letter 
    public Button letter;
    public void Start()
    {
        letter = gameObject.GetComponent<Button>();
        letter.onClick.AddListener(buttonSelect);
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
        TextInputScript.AddLetter(Character);
    }
}
