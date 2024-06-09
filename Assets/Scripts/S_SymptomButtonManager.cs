using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class S_SymptomButtonManager : XRBaseInteractable
{

    // Hold the name of the symptom
    public string Symptom;

    // Hold a reference to S_SymptomCanvasManager script
    public S_SymptomCanvasManager SymptomCanvasScript; 

    // Hold a reference to the default color 
    private Color DefaultColor = new Color(0f, 0f, 1f); 

    // Hold a reference to the hovered color
    private Color HoveredColor = new Color(0.5f, 0.5f, 1f); 

    // Hold a reference to the selected color
    private Color SelectedColor = new Color(0.7f, 0.7f, 1f); // Color when selected

    // Hold a reference to the Image component
    private Image ButtonImage;
    
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
    }

    /*
     * @brief OnHoverEnter check if the button is not selected and show the
     * hovered color
     * @param none
     * @return void
     */
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {

        // Check if the button is not selected
        if (!IsSelected)
        {

            // Change the Image color
            ButtonImage.color = HoveredColor;
        }
    }

    /*
     * @brief OnHoverExited check if the button is not selected and show the
     * default color
     * @param none
     * @return void
     */
    protected override void OnHoverExited(HoverExitEventArgs args)
    {

        // Check if the button is not selected
        if (!IsSelected)
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
    //protected override void OnSelectEntered(SelectEnterEventArgs args)
    public void buttonSelect()
    {

        // Check if the button has not been selected
        if (!IsSelected)
        {

            // Set IsSelected to true
            IsSelected = true;

            // Change the Image color 
            ButtonImage.color = SelectedColor;

            // Add the symptom 
            SymptomCanvasScript.AddSelectedSymptom(Symptom);
        }

        // Else the button is selected
        else
        {

            // Set IsSelected to false
            IsSelected = false;

            // Change the Image color
            ButtonImage.color = DefaultColor;

            // Remove the symptom
            SymptomCanvasScript.RemoveSelectedSymptom(Symptom);
        }
    }
}
