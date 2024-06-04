using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class S_TextInputManager : MonoBehaviour
{

    // Hold a reference to the InputField 
    public TMP_InputField SymptomInputField; 

    // Hold a reference of the other symptoms entered
    private List<string> Symptoms = new List<string>(); 

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
}
