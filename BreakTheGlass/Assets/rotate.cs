using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 v1, v2;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.R))
        {
            rb.AddTorque(v1);

        }else
        if (Input.GetKey(KeyCode.T))
        {
            rb.AddTorque(v2);

        }else
        rb.angularVelocity=new Vector3(0,0,0);
    }
}
