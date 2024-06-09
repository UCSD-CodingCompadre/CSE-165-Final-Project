using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class S_KeyboardEnterManager : XRBaseInteractable
{

    // Hold a reference to the TextInputManager script
    public S_TextInputManager TextInputScript;

    // Hold reference to enter button
    private Button enter;

    private void Start()
    {
        enter = gameObject.GetComponent<Button>();
        enter.onClick.AddListener(buttonSelect);
    }
    /*
     * @param OnSelectEnter enter a symptom and add it to the list
     * @param SelectEnterEventArgs arguements used for the Select Enter event
     * @return void
     */
    //protected override void OnSelectEntered(SelectEnterEventArgs args)
    public void buttonSelect()
    {

        // Add a symptom to the symptom list
        TextInputScript.Enter();
    }
}
