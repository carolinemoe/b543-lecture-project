using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] GameObject billionairePrefab;
    [SerializeField] float spawnRate;
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] Vector3 offset;
    float timer = 0f;
   // public float checkRadius = 0.1f;    // Radius for the overlap check.
    //public float offsetDistance = 0.5f; // Maximum offset distance if the spawn point is occupied.
   // public LayerMask spawnLayerMask;  // Layer mask to check for existing spawned objects.
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            Spawn();
            timer = 0f;
        }
    }
    
    void Spawn()
    {
        GameObject billionaire = Instantiate(billionairePrefab);
        billionaire.transform.position = spawnPosition;
        spawnPosition += offset;
      

        // Check if there's an object already at the spawn point.
       /* Collider2D hit = Physics2D.OverlapCircle(spawnPos, checkRadius, spawnLayerMask);
        if (hit != null)
        {
            // If the spawn point is occupied, adjust the spawn position slightly.
            // Random.insideUnitCircle gives a random offset within a circle of radius 1.
            spawnPos += Random.insideUnitCircle * offsetDistance;
        }

        Instantiate(billionairePrefab, spawnPos, Quaternion.identity);*/
    }
}
