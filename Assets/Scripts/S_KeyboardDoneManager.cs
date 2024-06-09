using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class S_KeyboardDoneManager : MonoBehaviour
{

    // Hold a reference to the TextInputManager script
    public S_TextInputManager TextInputScript;

    //Hold a reference to back button
    private Button done;

    private void Start()
    {
        done = gameObject.GetComponent<Button>();
        done.onClick.AddListener(buttonSelect);
    }
    /*
     * @param OnSelectEnter finish using the keyboard and move on to the next
     * checkpoint
     * @param SelectEnterEventArgs arguements used for the Select Enter event
     * @return void
     */
    //public void OnSelectEntered(SelectEnterEventArgs args)
    public void buttonSelect()
    {

        // Remove the keyboard UI and move on to the next checkpoint
        TextInputScript.Done();
    }
}
