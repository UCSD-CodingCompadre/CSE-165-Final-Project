using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class S_KeyboardBackspaceManager : MonoBehaviour
{

    // Hold a reference to the TextInputManager script
    public S_TextInputManager TextInputScript;

    //Hold a reference to back button
    private Button back;

    private void Start()
    {
        back = gameObject.GetComponent<Button>();
        back.onClick.AddListener(buttonSelect);
    }
    /*
     * @param OnSelectEnter remove the last letter if possible
     * @param SelectEnterEventArgs arguements used for the Select Enter event
     * @return void
     */
    //public void OnSelectEntered(SelectEnterEventArgs args)
    public void buttonSelect()
    {

        // Remove a letter from the text input
        TextInputScript.Backspace();
    }
}
