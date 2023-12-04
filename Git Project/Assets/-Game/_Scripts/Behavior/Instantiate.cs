using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    #region Public Variables

    [Header("Object to Instantiate")]
    public GameObject objectToInstantiate;

    [Header("Random Offset Bounds")]
    public float minX = -1f;
    public float maxX = 1f;
    public float minY = -1f;
    public float maxY = 1f;

    #endregion

    #region Public Methods

    // Call this method to instantiate the object with a random offset
    public void InstantiateObject()
    {
        // Calculate a random offset within the specified bounds
        Vector3 randomOffset = new Vector3(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY),
            0f
        );

        // Calculate the spawn position by adding the random offset to the current position
        Vector3 spawnPosition = transform.position + randomOffset;

        // Instantiate the object at the calculated position with no rotation (Quaternion.identity)
        GameObject instantiatedObject = Instantiate(objectToInstantiate, spawnPosition, Quaternion.identity);

        // Activate the instantiated object and remove it from its parent (if any)
        instantiatedObject.SetActive(true);
        instantiatedObject.transform.SetParent(null);
    }

    #endregion
}
