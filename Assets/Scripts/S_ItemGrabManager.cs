using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class S_ItemGrabManager : MonoBehaviour
{

    // Hold a reference to the SceneManager script
    private S_SceneManager SceneManagerScript;

    // Hold a reference to Jeff
    private GameObject Jeff;

    // Hold a reference to the XR Grab Interactable component
    private XRGrabInteractable GrabInteractable;

    // Hold a flag to prevent another checkpoint increment
    private bool WasGrabbed = false;

    /*
     * @brief On start set the SceneManager script 
     * @param none
     * @return void 
     */
    void Start()
    {
        
        // Look for the SceneManager Gameobject and set the script
        SceneManagerScript = GameObject.Find("GameManager").GetComponent<S_SceneManager>();

        // Look for Jeff and set the reference
        Jeff = GameObject.Find("Jeff");

        // Set the XRGrabInteractable component attached to this GameObject
        GrabInteractable = GetComponent<XRGrabInteractable>();

        // Add the OnSelectedEntered Method
        GrabInteractable.selectEntered.AddListener(OnSelectEntered);
    }

    /*
     * @brief Call the ChangeMessage method from the SceneManager script
     * @param SelectEnterEventArgs args the arguments for the SelectEnterEvent
     * @return void
     */
    private void OnSelectEntered(SelectEnterEventArgs args)
    {

        // Check if this is the first time the item was grabbed
        if (!WasGrabbed) SceneManagerScript.IncrementCheckpoint();

        // Set to true
        WasGrabbed = true;
    }
}
