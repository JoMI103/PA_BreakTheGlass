using System.Collections.Generic;
using UnityEngine;


public class RayCastReceiver : MonoBehaviour
{
    public bool ct;
    public GameObject player;

    public void casted()
    {
        ct = false;
    }

    public void cast()
    {
        ct = true;
    }
}
