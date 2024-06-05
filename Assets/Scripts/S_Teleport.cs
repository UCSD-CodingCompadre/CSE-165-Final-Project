using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Teleport : MonoBehaviour
{

    public Vector3 teleportLocation;

    private void OnTriggerEnter(Collider other)
    {
        // if player enters trigger, turn off controller
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterController>().enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // if player is in trigger, teleport
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = teleportLocation;

            // turn controller on
            other.gameObject.GetComponent<CharacterController>().enabled = false;
        }
    }
}
