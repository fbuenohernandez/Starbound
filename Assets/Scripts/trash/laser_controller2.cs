using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class laser_controller2 : MonoBehaviour
{

    Rigidbody rb;
    public float speed = 10f;
    public float boundary = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.up * speed;

        if (this.transform.position.y > boundary) Destroy(this.gameObject);
    }
}
