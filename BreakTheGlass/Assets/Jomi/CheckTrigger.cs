using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    public bool colliding;


    void Start()
    {
        colliding = false;    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            colliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            colliding = false;
        }
    }

}
