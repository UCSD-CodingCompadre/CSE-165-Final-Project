using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ItemSpawnerManager : MonoBehaviour
{
    // Hold the Transform location
    public Transform SpawnPoint;

    /*
     * @brief Spawn the object at the SpawnPoint
     * @param GameObject Prefab the object being spawned
     * @return GameObject
     */
    public GameObject SpawnObjectAtTransform(GameObject Prefab)
    {

        // Check if there is a spawn point and prefab
        if (Prefab != null && SpawnPoint != null)
        {

            // Instantiate the prefab at the position and rotation of the spawn point
            return Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
        }

        // Else return null
        return null;
    }
}
