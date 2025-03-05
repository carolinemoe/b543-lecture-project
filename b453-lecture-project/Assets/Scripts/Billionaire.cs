using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Billionaire : MonoBehaviour
{
    [SerializeField] Vector3 moveAmount;
    [SerializeField] GameObject flagPrefab;
    GameObject closestFlag;
    GameObject[] flags;
    //[SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    Vector2 direction;
    [SerializeField] string colorTag;


    //gameObject.AddComponent<BoxCollider2D>();
    // Start is called before the first frame update

   /* void Awake()
    {
        rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }*/

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        flags = GameObject.FindGameObjectsWithTag(colorTag);
        
       
        if (flags.Length > 0)
        {
            closestFlag = GetClosestFlag(transform.position);
            Debug.Log(closestFlag.transform.position);
        }
    }

    void FixedUpdate()
    {
        if (closestFlag != null)
        {
            direction = (closestFlag.transform.position - transform.position);
            direction.Normalize();
            rb.velocity = direction * speed;
            Debug.Log("moving");
        }
      
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
        transform.position += moveAmount;
    }

    GameObject GetClosestFlag(Vector2 point)
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
        Debug.Log(closestFlag.ToString());
        return closestFlag;
    }
}
