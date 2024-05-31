using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemy_controller1: MonoBehaviour
{
    Rigidbody rb;
    public float speed = -2f;
    BoxCollider bc;


    // Start is called before the first frame update
    void Start()
    {
     
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Laser") Destroy(this.gameObject);
    }
}
