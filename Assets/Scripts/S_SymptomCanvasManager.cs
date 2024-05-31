using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SymptomCanvasManager : MonoBehaviour
{

    // Hold a reference to the selected symptoms
    private List<string> SelectedSymptoms = new List<string>();

    /*
     * @brief Handle adding a symptom to the list
     * @param string SymptomName
     * @return void
     */
    public void AddSelectedSymptom(string Symptom)
    {

        // Check if the list already contains the symptom
        if (!SelectedSymptoms.Contains(Symptom))
        {

            // Add the symptom to the list
            SelectedSymptoms.Add(Symptom);
        }
    }

    /*
     * @brief Handle removing a symptom to the list
     * @param string SymptomName
     * @return void
     */
    public void RemoveSelectedSymptom(string Symptom)
    {

        // Check if the list does not have the symptom
        if (selectedSymptoms.Contains(Symptom))
        {

            // Remove the symptom from the list
            selectedSymptoms.Remove(Symtpom);
        }
    }
}
