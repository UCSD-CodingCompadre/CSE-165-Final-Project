using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class S_SymptomDoneButtonManager : MonoBehaviour
{

    // Hold a reference to the S_SceneManager script
    private S_SceneManager SceneManagerScript;

    /*
     * @brief OnStart set the SceneManager script
     * @param none
     * @return void
     */
    void Start()
    {
        
        // Set the SceneManager script
        SceneManagerScript = GameObject.Find("GameManager").GetComponent<S_SceneManager>();
    }

    /*
     * @brief OnSelectEntered call IncrementCheckpoint using the SceneMnager
     * script
     * @param SelectEnterEventArgs args the arguements for the SelectEnter 
     * event
     * @return void
     */
    public void OnSelectEntered(SelectEnterEventArgs args)
    {

        // Call the IncrementCheckpoint method
        SceneManagerScript.IncrementCheckpoint();
    }
}
