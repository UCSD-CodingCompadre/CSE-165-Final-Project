using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class S_SceneManager : MonoBehaviour
{

    // Hold a reference to the ItemSpawnerManager script
    public S_ItemSpawnerManager ItemSpawnerScript; 

    // Hold a reference to the Camera Offset Gameobject from the AR rig
    public GameObject RigCameraOffset;

    // Hold a reference to the MessageBoard prefab
    public GameObject MessageBoardPrefab;

    // Hold a reference to the Scanner prefab
    public GameObject Scanner;

    // Hold a reference to the current UI element
    private GameObject CurrentUIElement;

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
        CurrentUIElement.GetComponent<TextMeshProUGUI>().text = "Help Jeff! Grab the scanner using the grip buttons. Follow the arrow to your backpack.";

        // Spawn the scanner
        ItemSpawnerScript.SpawnObjectAtTransform(Scanner);
    }

    /*
     * @brief Spawn the specific UI prefab at a location
     * @param GameObject Prefab the prefrab being spawned
     * Vector3 Position the location to spawn the prefab
     * @return void
     */
    void SpawnUIPrefab(GameObject Prefab, Vector3 Position)
    {

        // Instantiate the prefab at the specified position
        CurrentUIElement = Instantiate(Prefab, RigCameraOffset.transform);

        // Set the location relative to the camera offset
        CurrentUIElement.transform.localPosition = Position;
    }
}
