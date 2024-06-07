using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class S_ItemGrabManager : XRBaseInteractable
{

    // Hold a reference to the SceneManager script
    private S_SceneManager SceneManagerScript;

    // Hold a reference to Jeff
    private GameObject Jeff;

    // Hold a flag to prevent another checkpoint increment
    private bool WasGrabbed = false;

    // Hold the hover material
    public Material HoverMaterial;

    // Hold the select Material
    public Material SelectMaterial;

    // Hold the MeshRenderer component for the interactable
    private Renderer ObjectRenderer;

    // Hold the Transform component for the interactable
    private Transform ObjectTransform;

    // Hold the original Material list
    private List<Material> OriginalMaterials = new List<Material>();

    /*
     * @brief On start set the SceneManager script 
     * @param none
     * @return void 
     */
    void Start()
    {

        // Look for the SceneManager Gameobject and set the script
        SceneManagerScript = GameObject.Find("SceneManager").GetComponent<S_SceneManager>();

        // Look for Jeff and set the reference
        Jeff = GameObject.Find("Jeff");
    }

    /*
     * @brief On script awake set the components
     * @param none
     * @return void
     */
    protected override void Awake()
    {

        // Call the base method
        base.Awake();

        // Get the MeshRenderer component from the object
        ObjectRenderer = GetComponent<Renderer>();

        // Get the Transform component from the object
        ObjectTransform = GetComponent<Transform>();

        // Store the original materials
        OriginalMaterials.AddRange(ObjectRenderer.materials);

        // Return
        return;
    }

    /*
     * @brief On hover highlight the furniture to spawn
     * @param none
     * @return void
     */
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {

        // Call the base method 
        base.OnHoverEntered(args);

        // Add the new Materials list
        ObjectRenderer.materials = new Material[] { OriginalMaterials[0], HoverMaterial };

        // Return
        return;
    }

    /*
     * @brief On unhover dehighlight the furniture to spawn
     * @param none
     * @return void
     */
    protected override void OnHoverExited(HoverExitEventArgs args)
    {

        // Call the base method
        base.OnHoverExited(args);

        // Remove the hover material from the list
        ObjectRenderer.materials = OriginalMaterials.ToArray();

        // Return
        return;
    }

    /*
     * @brief On select run the grab functionality and change the materials
     * @param SelectEnterEventArgs args the arguements for the select
     * enter event
     * @return void
     */
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {

        // Call the base method
        base.OnSelectEntered(args);

        // Check if this is the first time the item was grabbed
        if (!WasGrabbed) SceneManagerScript.IncrementCheckpoint();

        // Set to true
        WasGrabbed = true;

        // Start the coroutine function
        StartCoroutine(HandleGrabInteraction());

        // Return
        return;
    }

    /*
     * @brief On select exit run the grab functionality and change the materials
     * @param SelectExitEventArgs args the arguements for the select 
     * exit event
     * @return void
     */
    protected override void OnSelectExited(SelectExitEventArgs args)
    {

        // Call the base method
        base.OnSelectExited(args);

        // Remove the hover material from the list
        ObjectRenderer.materials = OriginalMaterials.ToArray();

        // Start the coroutine function
        StopCoroutine(HandleGrabInteraction());

        // Return
        return;
    }

    /*
     * @brief Coroutine function that handles the grab interaction
     * @param none
     * @return System.Collection.IEnumerator
     */
    private System.Collections.IEnumerator HandleGrabInteraction()
    {

        // Loop until there is no interactor
        while (firstInteractorSelecting != null)
        {

            // Add the new Materials list
            ObjectRenderer.materials = new Material[] { OriginalMaterials[0], SelectMaterial };

            // Calculate the new position of the object
            Vector3 newPosition = firstInteractorSelecting.transform.position + firstInteractorSelecting.transform.forward * 3.0f;

            // Set the new position of the object
            ObjectTransform.position = newPosition;

            // Set the new rotation of the object
            ObjectTransform.rotation = firstInteractorSelecting.transform.rotation;

            // Wait for the next frame
            yield return null;
        }

        // Wait for the next frame
        yield return null;
    }
}
