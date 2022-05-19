using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayCastEmitter : MonoBehaviour
{
    [SerializeField]
    private InventorySystem _IS;

    public LayerMask layerMask;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (EventSystem.current.IsPointerOverGameObject()) return;


        if (Input.GetKeyDown(KeyCode.Mouse0))
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
                    rayC.castLeft(); 
                }
            }
            else
            {
                
                Debug.Log("Did not Hit Left");
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red);
                RayCastReceiver rayC;
                rayC = hit.transform.gameObject.GetComponent<RayCastReceiver>();

                if (rayC != null)
                {
                    rayC.player = this.gameObject;
                    rayC.castRight();
                }
            }
            else
            {

                Debug.Log("Did not Hit Righ");
            }
        }
    }
}
