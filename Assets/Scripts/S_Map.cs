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

    private bool mapOpen;

    // pass in map
    public GameObject map;
    public GameObject breatheUI;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (!controller.GetLeftController(out leftController))
        {
            yield return null;
        }
        secondaryPressed = false;
        mapOpen = false;
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
            if (mapOpen) {
                map.SetActive(false);
                breatheUI.SetActive(true);
                mapOpen = false;
            } else {
                map.SetActive(true);
                breatheUI.SetActive(false);
                mapOpen = true;
            }
            mapToggleable = false;
        }
    }
}
