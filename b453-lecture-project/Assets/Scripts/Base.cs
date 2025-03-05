
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] GameObject billionairePrefab;
    [SerializeField] float spawnRate;
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] Vector3 offset;
    [SerializeField] GameObject flagPrefab;
    [SerializeField] int player;
    int flagsOut = 0;
    List<GameObject> flags = new List<GameObject> ();

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

        if (Input.GetMouseButtonDown(0))
        {
            if(flagsOut < 2)
            {
                Flag();
            }
            else if (Input.GetKey(KeyCode.Alpha1))
            {
                Move();
            }
        }
    }
    
    void Spawn()
    {
        GameObject billionaire = Instantiate(billionairePrefab);
        billionaire.transform.position = spawnPosition;
        spawnPosition += offset;
      
    }
    
    void Flag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -1f;

        if (Input.GetKey(KeyCode.Alpha1) && player == 1)
       {
            Debug.Log("Spawn");
            GameObject flag = Instantiate(flagPrefab);
            flag.transform.position = mousePos;
            flagsOut++;  
            flags.Add(flag);
        }

       /* if (Input.GetKey(KeyCode.Alpha2) && player == 2)
        {
            Debug.Log("Spawn");
            GameObject flag = Instantiate(flagPrefab);
            flag.transform.position = mousePos;
            flagsOut++;
            flags.Add(flag);
        } */
    }

    void Move()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -1f;
        GameObject closest = GetClosestFlag(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        closest.transform.position = mousePos;
    }

    GameObject GetClosestFlag(Vector3 point)
    {
        GameObject closestFlag = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject flag in flags)
        {
            float distance = Vector2.Distance(flag.transform.position, point);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestFlag = flag;
            }
        }
        //Debug.Log(closestFlag.ToString());
        return closestFlag;
    }
}
