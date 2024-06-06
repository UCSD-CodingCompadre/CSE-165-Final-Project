using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class S_Controllers : MonoBehaviour
{
    private InputDevice leftController;
    private InputDevice rightController;
    private InputDevice headset;
    bool deviceFound;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        deviceFound = false;
        List<InputDevice> ldevices = new List<InputDevice>();
        List<InputDevice> rdevices = new List<InputDevice>();
        List<InputDevice> hdevices = new List<InputDevice>();
        InputDeviceCharacteristics leftCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDeviceCharacteristics rightCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDeviceCharacteristics headCharacteristics = InputDeviceCharacteristics.HeadMounted;

        while (ldevices.Count == 0 || rdevices.Count == 0 || hdevices.Count == 0)
        {
            // check for devices every frame until you find one.
            yield return null;
            InputDevices.GetDevicesWithCharacteristics(leftCharacteristics, ldevices);
            InputDevices.GetDevicesWithCharacteristics(rightCharacteristics, rdevices);
            InputDevices.GetDevicesWithCharacteristics(headCharacteristics, hdevices);
        }

        rightController = rdevices[0];
        leftController = ldevices[0];
        headset = hdevices[0];
        deviceFound = true;
        Debug.Log("All Controllers Connected");
    }
    public bool GetRightController(out InputDevice device)
    {
        device = rightController;
        return deviceFound;
    }
    public bool GetLeftController(out InputDevice device)
    {
        device = leftController;
        return deviceFound;
    }
    public bool GetHeadSet(out InputDevice device)
    {
        device = headset;
        return deviceFound;
    }
}

