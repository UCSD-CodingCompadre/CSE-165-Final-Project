using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class S_SceneManager : MonoBehaviour
{

    // Hold a reference to the ItemSpawnerManager script
    public S_ItemSpawnerManager ItemSpawnerScript;

    // Hold a reference to the WayfindingManager script
    public S_WayfindingManager WayfindingScript;

    // Hold a reference to the Camera Offset Gameobject from the AR rig
    public GameObject RigCameraOffset;

    // Hold a reference to the MessageBoard prefab
    public GameObject MessageBoardPrefab;

    // Hold a reference to Jeff
    public GameObject Jeff;

    // Hold a reference to the Scanner prefab
    public GameObject Scanner;

    // Hold a reference to the current UI element
    private GameObject CurrentUIElement;

    // Hold a reference to the current objective
    private GameObject CurrentObjective;

    // Hold the current scene checkpoint
    private int Checkpoint = 1;

    /*
     * @brief On start set up the first message 
     * @param none
     * @return void
     */
    void Start()
    {

        // Spawn the message board
        SpawnUIPrefab(MessageBoardPrefab, new Vector3(0, .25f, .75f));

        // Set the first messasge
        SetMessageBoardText("Help Jeff! Grab the scanner using the grip buttons. Follow the arrow to your backpack.");

        // Set the first objective
        SetNextObjective(Scanner);
    }

    /*
     * @brief Spawn the specific UI prefab at a location
     * @param GameObject Prefab the prefrab being spawned
     * Vector3 Position the location to spawn the prefab
     * @return void
     */
    public void SpawnUIPrefab(GameObject Prefab, Vector3 Position)
    {

        // Instantiate the prefab at the specified position
        CurrentUIElement = Instantiate(Prefab, RigCameraOffset.transform);

        // Set the location relative to the camera offset
        CurrentUIElement.transform.localPosition = Position;
    }

    /*
     * @brief Change the TextMeshPro text 
     * @param string Text the text to change the message to
     * @return void
     */
    public void SetMessageBoardText(string Text)
    {

        CurrentUIElement.GetComponent<TextMeshProUGUI>().text = Text;
    }

    /*
     * @brief Destroy the current UIElement
     * @param none
     * @return void
     */
    public void DestroyCurrentUIElement()
    {

        // Destroy the UI element
        Destroy(CurrentUIElement);

        // Set to null
        CurrentUIElement = null;
    }

    /*
     * @brief Destroy the current objective
     * @param none
     * @return void
     */
    public void DestroyCurrentObjective()
    {

        // Destroy the current objective
        Destroy(CurrentObjective);

        // Set to null
        CurrentObjective = null;
    }

    /*
     * @brief Set the new objective
     * @param GameObject the next objective
     * @return void
     */
    public void SetNextObjective(GameObject Objective)
    {

        // Set the new objective
        CurrentObjective = ItemSpawnerScript.SpawnObjectAtTransform(Objective);

        // Set the wayfinding 
        WayfindingScript.SetActiveObject(CurrentObjective);
    }

    /*
     * @brief Increment the checkpoint
     * @param none
     * @return void
     */
    public void IncrementCheckpoint()
    {

        // Increment the checkpoint 
        Checkpoint++;
    }

    /*
     * @brief Every frame check the scene progress
     * @param none
     * @return void
     */
    private void Update()
    {

        // Check the checkpoints
        switch(Checkpoint)
        {
            
            // User must scan Jeff
            case 2:

                // Set the wayfinding to Jeff
                WayfindingScript.SetActiveObject(Jeff);

                // Change message on Message board
                SetMessageBoardText("Quickly! Scan Jeff to see what is wrong!");

                // Break
                break;

            // User must select symptoms from a dropdown menu
            case 3:
                // Logic for checkpoint 3
                break;
            case 4:
                // Logic for checkpoint 4
                break;
            case 5:
                // Logic for checkpoint 5
                break;
            case 6:
                // Logic for checkpoint 6
                break;
        }
    }
}
