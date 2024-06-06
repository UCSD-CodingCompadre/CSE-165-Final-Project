using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class S_Map : MonoBehaviour
{
    public S_Controllers controller;
    public InputDevice leftController;

    private bool secondaryPressed;
    private bool mapToggleable;

    // pass in map
    public GameObject map;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (!controller.GetLeftController(out leftController))
        {
            yield return null;
        }
        secondaryPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        leftController.TryGetFeatureValue(CommonUsages.secondaryButton, out secondaryPressed);
        if (!secondaryPressed)
        {
            mapToggleable = true;
        }

        // if toggleable and input pressed, hold current input by turning toggleable false
        if (mapToggleable && secondaryPressed)
        {
            map.SetActive(true);
            mapToggleable = false;
        }
    }
}
