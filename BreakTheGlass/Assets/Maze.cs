using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Maze : MonoBehaviour
{
    



    public Collider cl;
    public Transform spawnPoint;
    public GameObject marble;

    private RayCastReceiver receiver;
    private checkItem _CI;

    private bool lockk;


    private void Start()
    {
        receiver = GetComponent<RayCastReceiver>();
        _CI = GetComponent<checkItem>();
        lockk = false;
        
    }

    private void Update()
    {


        if (receiver.ctLeft)
        {
            receiver.castedLeft();
            if (_CI != null) lockk = _CI.checkItems();

            if (lockk)
            {
                Instantiate(marble, spawnPoint.position, new Quaternion(), spawnPoint);
                lockk = false;
            }
        }

       
    }

}
