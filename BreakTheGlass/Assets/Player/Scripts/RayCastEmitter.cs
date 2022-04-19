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
        if (InspectorScript.inspecting) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f, layerMask))
            {
                RayCastReceiver rayC;
                rayC = hit.transform.gameObject.GetComponent<RayCastReceiver>();

                if(rayC != null)
                {
                    rayC.player = this.gameObject;
                    rayC.cast(); 
                }


            }
            else
            {
                
                Debug.Log("Did not Hit");
            }
        }
    }
}
