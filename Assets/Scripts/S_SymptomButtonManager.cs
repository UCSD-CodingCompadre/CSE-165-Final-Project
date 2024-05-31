using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
        interactor = GetComponent<XRDirectInteractor>();
    }

    public void OnPointerEnter()
    {
        if (!isSelected)
            buttonImage.color = hoveredColor;
    }

    public void OnPointerExit()
    {
        if (!isSelected)
            buttonImage.color = defaultColor;
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!isSelected)
        {
            isSelected = true;
            buttonImage.color = selectedColor;
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
