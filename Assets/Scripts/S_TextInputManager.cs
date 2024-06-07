using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class S_TextInputManager : MonoBehaviour
{

    // Hold a reference to the InputField 
    public TMP_InputField SymptomInputField;

    // Hold a reference to the SceneManager script
    private S_SceneManager SceneManagerScript;

    // Hold a reference of the other symptoms entered
    private List<string> Symptoms = new List<string>();

    // Hold a flag if done was pressed
    private bool Flag = false;

    /*
     * @brief OnStart grab the SceneManager script
     * @param none
     * @return void
     */
    public void Start()
    {

        // Look for the SceneManager Gameobject and set the script
        SceneManagerScript = GameObject.Find("SceneManager").GetComponent<S_SceneManager>();
    }

    /*
     * @brief Add the letter to InputField
     * @param string Letter the letter to append
     * @return void
     */
    public void AddLetter(string letter)
    {

        // Append the letter to the text
        SymptomInputField.text += letter;
    }

    /*
     * @brief Remove the last letter of the InputField
     * @param none
     * @return void
     */
    public void Backspace()
    {

        // Check if there is a letter than back be removed
        if (SymptomInputField.text.Length > 0)
        {

            // Splice the text to remove the last letter
            SymptomInputField.text = SymptomInputField.text.Substring(0, SymptomInputField.text.Length - 1);
        }
    }

    /*
     * @brief Add the other symptom and reset the InputField
     * @param none
     * @return void
     */
    public void Enter()
    {

        // Check if there is text to add
        if (!string.IsNullOrEmpty(SymptomInputField.text))
        {

            // Append the new symptom
            Symptoms.Add(SymptomInputField.text);

            // Reset the InputField
            SymptomInputField.text = string.Empty;
        }
    }

    /*
     * @brief Complete the Keyboard checkpoint in the scene
     * @param none
     * @return void
     */
    public void Done()
    {

        // Check if the user has pressed Done
        if(!Flag)
        {

            // Move to the next checkpoint
            SceneManagerScript.IncrementCheckpoint();
        }
    }
}
