using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billionaire : MonoBehaviour
{
    [SerializeField] Vector3 moveAmount;
    //gameObject.AddComponent<BoxCollider2D>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
        transform.position += moveAmount;
    }
}
