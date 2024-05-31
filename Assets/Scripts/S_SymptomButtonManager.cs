using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class S_SymptomButtonManager : MonoBehaviour
{

    // Hold the name of the symptom
    public string Symptom;

    // Hold a reference to the default color 
    private Color DefaultColor = new Color(0f, 0f, 1f); 

    // Hold a reference to the hovered color
    private Color HoveredColor = new Color(0.5f, 0.5f, 1f); 

    // Hold a reference to the selected color
    private Color SelectedColor = new Color(0.7f, 0.7f, 1f); // Color when selected

    // Hold a reference to the Image component
    private Image ButtonImage;

    // Hold a reference to the XRDirectInteractor component
    private XRDirectInteractor DirectInteractor;
    
    // Hold a flag to check if the button was been selected
    private bool IsSelected = false;

    /*
     * @brief On start set the components
     * @param none
     * @return void
     */
    void Start()
    {

        // Set the Image component
        ButtonImage = GetComponent<Image>();
        
        // Set the XRDirectInteractor component
        DirectInteractor = GetComponent<XRDirectInteractor>();
    }

    /*
     * @brief OnPointerEnter check if the button is not selected and show the
     * hovered color
     * @param none
     * @return void
     */
    public void OnPointerEnter()
    {

        // Check if the button is not selected
        if (!isSelected)
        {

            // Change the Image color
            ButtonImage.color = HoveredColor;
        }
    }

    /*
     * @brief OnPointerExit check if the button is not selected and show the
     * default color
     * @param none
     * @return void
     */
    public void OnPointerExit()
    {

        // Check if the button is not selected
        if (!isSelected)
        {

            // Change the Image color
            ButtonImage.color = DefaultColor;
        }
    }

    /*
     * @brief OnSelectEntered check if the button is selected or not
     * and add or remove the symptom from the SymptomManager script
     * @param SelectEnterEventArgs args the arguements for the SelectEnter event
     * @return void
     */
    public void OnSelectEntered(SelectEnterEventArgs args)
    {

        // Check if the button has not been selected
        if (!isSelected)
        {

            // Set IsSelected to true
            IsSelected = true;

            // Change the Image color 
            buttonImage.color = SelectedColor;

            // Send selected symptom to Canvas script
            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null)
            {
                canvas.GetComponent<CanvasScript>().AddSelectedSymptom(symptomName);
            }
        }
        else
        {
            isSelected = false;
            buttonImage.color = defaultColor;
            // Remove selected symptom from Canvas script
            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null)
            {
                canvas.GetComponent<CanvasScript>().RemoveSelectedSymptom(symptomName);
            }
        }
    }
}
