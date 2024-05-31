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

    // Hold a reference to the MessageBoard 
    public GameObject MessageBoard;

    // Hold a reference to Jeff
    public GameObject Jeff;

    // Hold a reference to the Scanner prefab
    public GameObject Scanner;

    // Hold a reference to the SymptomSelector prefab
    public GameObject SymptomsSelectorPrefab;

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

        // Set the first messasge
        SetMessageBoardText("Help Jeff! Grab the scanner using the grip buttons. Follow the arrow to your backpack.");

        // Spawn the Scanner
        SpawnBackPackpackItem(Scanner);
    }

    /*
     * @brief Spawn the specific UI prefab at the UI interaction location
     * @param GameObject Prefab the prefrab being spawned
     * Vector3 Position the location to spawn the prefab
     * @return void
     */
    public void SpawnUIPrefab(GameObject Prefab, Vector3 Position)
    {

        // Instantiate the prefab at the specified position
        CurrentObjective = Instantiate(Prefab);
    }

    /*
     * @brief Spawn the specific objective at the backpack
     * @param GameObject Prefab the prefrab being spawned
     * Vector3 Position the location to spawn the prefab
     * @return void
     */
    public void SpawnBackPackpackItem(GameObject Prefab)
    {

        // Set the new objective
        CurrentObjective = ItemSpawnerScript.SpawnObjectAtTransform(Prefab);
    }
    

    /*
     * @brief Change the TextMeshPro text 
     * @param string Text the text to change the message to
     * @return void
     */
    public void SetMessageBoardText(string Text)
    {

        // Set the text for MessageBoard
        MessageBoard.GetComponent<TextMeshProUGUI>().text = Text;
    }

    /*
     * @brief Set the new objective
     * @param GameObject the next objective
     * @return void
     */
    public void SetWayfinding()
    {

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

                // Set the current objective to Jeff
                CurrentObjective = Jeff;

                // Update the wayfinding 
                SetWayfinding();

                // Change message on Message board
                SetMessageBoardText("Quickly! Scan Jeff to see what is wrong!");

                // Break
                break;

            // User must select symptoms from a dropdown menu
            case 3:

                // Update the wayfinding 
                SetWayfinding();


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
