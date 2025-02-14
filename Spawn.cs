using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;  // Assign the prefab in Inspector
    public float spawnDistance = 2f;  // Distance in front of player

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Left-click
        {
            SpawnObject();
           
            
        }
    }

    void SpawnObject()
    {
        if (objectToSpawn == null) return;

        // Calculate spawn position (in front of player)
        Vector3 spawnPosition = transform.position + transform.forward * spawnDistance;

        // Spawn the object
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
   
}
