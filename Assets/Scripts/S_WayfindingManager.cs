using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_WayfindingManager : MonoBehaviour
{
    // Hold the active checkpoint
    private GameObject ActiveObjective;

    /*
     * @brief Every frame update the arrow rotation
     * @param none
     * @return void
     */
    void Update()
    {

        // Rotate the Arrow to the active checkpoint
        if (ActiveObjective != null)
        {

            // Calculate direction vector from the arrow to the active checkpoint
            Vector3 Direction = ActiveObjective.transform.position - transform.position;

            // Invert the y-component to make it negative
            Direction.y *= -1;

            // Adjust rotation to point towards the active checkpoint
            Quaternion TargetRotation = Quaternion.LookRotation(new Vector3(Direction.x, -Direction.y, Direction.z), Vector3.up);

            // Apply rotation to the arrow
            transform.rotation = TargetRotation;
        }

        // Else there is no active checkpoint
        else
        {

            // Set the rotation to the identity
            transform.rotation = Quaternion.identity;
        }
    }

    /*
     * @brief Update the ActiveObject
     * @param GameObject NewObjective the new objective
     * @return void
     */
    public void SetActiveObject(GameObject NewObjective)
    {

        // Set the new active object
        ActiveObjective = NewObjective;
    }
}
