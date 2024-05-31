using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class laser_controller1 : MonoBehaviour
{

    Rigidbody rb;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey("j") || Input.GetKey("left")))
        {
            this.transform.Translate(Vector3.left * 5 * Time.deltaTime);
        }
        else if ((Input.GetKey("l") || Input.GetKey("right")))
        {
            this.transform.Translate(Vector3.right * 5 * Time.deltaTime);
        }

        if ((Input.GetKey("i") || Input.GetKey("up")))
        {
            this.transform.Translate(Vector3.up * 5 * Time.deltaTime);
        }
        else if ((Input.GetKey("k") || Input.GetKey("down")))
        {
            this.transform.Translate(Vector3.down * 5 * Time.deltaTime);
        }

    }
}
