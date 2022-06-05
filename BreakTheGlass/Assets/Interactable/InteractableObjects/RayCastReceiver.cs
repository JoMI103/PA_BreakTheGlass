using System.Collections.Generic;
using UnityEngine;


public class RayCastReceiver : MonoBehaviour
{
    //[HideInInspector]
    public bool ctLeft, ctRight;
    [HideInInspector]
    public GameObject player;


    public void castedLeft()
    {
        ctLeft = false;
    }

    public void castLeft()
    {
        ctLeft = true;
    }

    public void castedRight()
    {
        ctRight = false;
    }

    public void castRight()
    {
        ctRight = true;
    }

}
