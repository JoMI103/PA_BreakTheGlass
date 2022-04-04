using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastEmitter : MonoBehaviour
{
    public LayerMask layerMask;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2f, layerMask))
        {
            
//            hit.transform.gameObject.GetComponent<>
            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 2, Color.white);
            Debug.Log("Did not Hit");
        }

    }
}
