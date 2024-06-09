using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    // Hold a reference to the Pills prefab
    public GameObject Pills;

    // Hold a reference to the Virtual Reality Headset
    public GameObject VRHeadset;

    // Hold a reference to the Pulse Oximeter
    public GameObject PulseOximeter;

    // Hold a reference to the SymptomSelector prefab
    public GameObject SymptomsSelectorPrefab;

    // Hold a reference to the OtherSymptomsTextInput prefab
    public GameObject OtherSymptomsTextInputPrefab;

    // Hold a reference to the location to place the other UIs
    public Transform UILocation;

    // Hold a reference to the current objective
    private GameObject CurrentObjective;

    // Hold the current scene checkpoint
    private int Checkpoint = 1;

    // Hold a reference to the bool array
    private bool[] CheckpointList = new bool[10];

    /*
     * @brief On start set up the first message 
     * @param none
     * @return void
     */
    private void Start()
    {

        // Set the first messasge
        SetMessageBoardText("Help Jeff! Grab the scanner using the grip buttons. Follow the arrow to your backpack.");

        // Spawn the Scanner
        SpawnBackPackpackItem(Scanner);

        // Set the wayfinding
        SetWayfinding();
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
        CurrentObjective = Instantiate(Prefab, Position, Quaternion.identity);
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
        MessageBoard.GetComponentInChildren<TextMeshProUGUI>().text = Text;
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

        Debug.Log(Checkpoint);

        if (Checkpoint != 1 && !CheckpointList[Checkpoint - 2])
        {
            // Check the checkpoints
            switch (Checkpoint)
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

                    // Spawn the SymptomSelector
                    SpawnUIPrefab(SymptomsSelectorPrefab, UILocation.position);

                    // Update the wayfinding 
                    SetWayfinding();

                    // Change message on Message board
                    SetMessageBoardText("Press on the symptoms you see. Then press Done.");


                    // Break
                    break;

                // User must type out the other symptoms
                case 4:

                    // Destroy the SymptomSelector
                    Destroy(CurrentObjective);

                    // Spawn the OtherSymptomsTextInput 
                    SpawnUIPrefab(OtherSymptomsTextInputPrefab, UILocation.position);

                    // Update the wayfinding
                    SetWayfinding();

                    // Change message on Message board
                    SetMessageBoardText("Type out any other symptoms.");


                    // Break
                    break;

                // User must grab the pills
                case 5:


                    // Destroy the Symptom Keyboard
                    Destroy(CurrentObjective);

                    // Spawn the pills
                    SpawnBackPackpackItem(Pills);

                    // Update the wayfinding
                    SetWayfinding();

                    // Change message on Message board
                    SetMessageBoardText("Jeff is experiencing drug induced psychosis! Grab the pills to calm him down.");

                    // Break
                    break;

                // User must give Jeff the pills
                case 6:

                    // Set the current objective to Jeff
                    CurrentObjective = Jeff;

                    // Update the wayfinding 
                    SetWayfinding();

                    // Change message on Message board
                    SetMessageBoardText("Give Jeff the pills.");

                    // Logic for checkpoint 6
                    break;

                // User must grab the Virtual Reality Headset
                case 7:

                    // Spawn the Virtual Reality Headset
                    SpawnBackPackpackItem(VRHeadset);

                    // Update the wayfinding
                    SetWayfinding();

                    // Change message on Message board
                    SetMessageBoardText("Jeff needs to change his enviroment so he can calm down. Grab the Virtual Reality Headset on the backpack.");

                    // Break
                    break;

                // User must hand the Virtual Reality Headset to Jeff
                case 8:

                    // Set the current objective to Jeff
                    CurrentObjective = Jeff;

                    // Update the wayfinding 
                    SetWayfinding();

                    // Change message on Message board
                    SetMessageBoardText("Give Jeff the Virtual Reality Headset.");

                    // Break
                    break;

                // User must grab the Pulse Oximeter
                case 9:

                    // Spawn the pills
                    SpawnBackPackpackItem(PulseOximeter);

                    // Update the wayfinding
                    SetWayfinding();

                    // Change message on Message board
                    SetMessageBoardText("While Jeff is in his Virtual Reality we need to scan his vitals. Grab the Pulse Oximeter from the backpack.");

                    // Break
                    break;

                // User must hand the Virtual Reality Headset to Jeff
                case 10:

                    // Set the current objective to Jeff
                    CurrentObjective = Jeff;

                    // Update the wayfinding 
                    SetWayfinding();

                    // Change message on Message board
                    SetMessageBoardText("Jeff is recovering. He will be okay.");

                    // Break
                    break;
                case 11:
                    //Load next scene after this scene (can find scene order in build settings)
                    StartCoroutine(LoadYourAsyncScene());
                    break;
            }
            // Set the checkpoint to true
            CheckpointList[Checkpoint - 2] = true;
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}

