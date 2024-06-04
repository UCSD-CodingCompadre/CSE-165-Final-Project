using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GenerateScene : MonoBehaviour
{
    public GameObject planePrefab; // Reference to the plane prefab
    public GameObject treePrefab; //Reference to the tree prefab
    public int numberOfPlanes = 100; // Number of planes to instantiate
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfPlanes; i++)
        {
            // Instantiate the plane prefab at a random position
            GameObject plane = Instantiate(planePrefab, new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f)), Quaternion.identity);

            // Check if this plane should have trees
            if (Random.value > 0.9f)
            {
                Instantiate(treePrefab, new Vector3(Random.Range(plane.transform.position.x - 5f, plane.transform.position.x + 5f), 0f, Random.Range(plane.transform.position.z - 5f, plane.transform.position.z + 5f)), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
