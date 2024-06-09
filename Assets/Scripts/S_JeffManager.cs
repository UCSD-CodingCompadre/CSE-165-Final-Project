using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_JeffManager : MonoBehaviour
{

    // Hold a reference to the SceneManager script
    public S_SceneManager SceneManager;

    // Hold a reference to the TriggeredTags
    private List<string> TriggeredTags = new List<string>();


    /*
     * @brief On start add the default tags to prevent unecessary collisions
     * @param none
     * @return void
     */
    private void Start()
    {

        // The starting tags
        TriggeredTags.Add("hands");
        TriggeredTags.Add("floor");
        TriggeredTags.Add("Player");
    }


    /*
     * @brief OnTriggerEnter check if a tag is contained
     * @param Collider CollidingObject the object that is colliding with 
     * Jeff
     * @return void
     */
    private void OnTriggerEnter(Collider CollidingObject)
    {

        
        // Check if the other collider has the target tag and if the tag is not already in the list
        if (!TriggeredTags.Contains(CollidingObject.tag))
        {

            Debug.Log(CollidingObject.transform.name);

            // Add the tag to the list
            TriggeredTags.Add(CollidingObject.tag);

            // Increment the checkpoint
            SceneManager.IncrementCheckpoint();

            // Destroy the item
            Destroy(CollidingObject);
        }
    }
}
