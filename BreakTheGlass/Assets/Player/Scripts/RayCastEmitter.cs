using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayCastEmitter : MonoBehaviour
{
    [SerializeField]
    private GameObject _IS;
    [SerializeField]
    private float distance;

    public bool ForwardFree;

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
            if (ForwardFree)
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, layerMask))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distance, Color.green);
                    RayCastReceiver rayC;
                    rayC = hit.transform.gameObject.GetComponent<RayCastReceiver>();

                    if (rayC != null)
                    {
                        rayC.player = _IS;
                        rayC.castLeft();
                    }
                }
                else
                {
                    Debug.Log("Did not Hit Left");
                }
            }
            else
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, distance, layerMask))
                {
                    Debug.DrawLine(ray.origin, hit.point);
                    RayCastReceiver rayC;
                    rayC = hit.transform.gameObject.GetComponent<RayCastReceiver>();

                    if (rayC != null)
                    {
                        rayC.player = _IS;
                        rayC.castLeft();
                    }
                }
                else
                {
                    Debug.Log("Did not Hit Left");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit hit;
            if (ForwardFree)
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, layerMask))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distance, Color.green);
                    RayCastReceiver rayC;
                    rayC = hit.transform.gameObject.GetComponent<RayCastReceiver>();

                    if (rayC != null)
                    {
                        rayC.player = _IS;
                        rayC.castRight();
                    }
                }
                else
                {
                    Debug.Log("Did not Hit Righ");
                }
            }
            else
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, distance,layerMask))
                {
                    Debug.DrawLine(ray.origin, hit.point);
                    RayCastReceiver rayC;
                    rayC = hit.transform.gameObject.GetComponent<RayCastReceiver>();

                    if (rayC != null)
                    {
                        Debug.Log("olaaa");
                        rayC.player = _IS;
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
}
