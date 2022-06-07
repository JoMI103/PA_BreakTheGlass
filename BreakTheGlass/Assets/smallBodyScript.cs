using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallBodyScript : MonoBehaviour
{
    public PlayerMovement pm;

    public CharacterController cc;

    public Transform pos;

    public Vector3 currentScale;

    private bool go;

    private void Start()
    {
        go = false;
        currentScale = pm.transform.localScale;
    }

    public void Update()
    {
        Debug.Log(pm.transform.position);
    }

    public void teleport()
    {

        go = true;

        //cc.stepOffset = 0.3f / 57.33232f;
        //pm.transform.localScale = currentScale / 57.33232f;
        //pm.setVelocity(2.5f / 10f, 1 / 57.33232f, -9.81f / 57.33232f);

        pm.transform.position = new Vector3(0.533999979f, 0.643999994f, -10.6850004f);
        Debug.Log(pm.transform.position);
    }

    private void LateUpdate()
    {
        if (go)
        {
            go = false;
        
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            teleport();

        }
        
    }
}
