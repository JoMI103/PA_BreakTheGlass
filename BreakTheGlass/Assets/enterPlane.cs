using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterPlane : MonoBehaviour
{
    public smallBodyScript sbs;
    public RayCastReceiver rcr;
    public PlaneMovement pm;
    public HeliceSpin hs;
    public GameObject[] deactivate;

    public cameraManager cmtv;

    private bool flying;

    private void Start()
    {
        flying = false;
    }

    private void Update()
    {
        if (flying) {
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                cmtv.changeCamera(2);
            }
            if(Input.GetKeyDown(KeyCode.Alpha2)){
                cmtv.changeCamera(3);
            }
            return;
        }

        if (rcr.ctLeft && sbs.enter)
        {
            foreach (GameObject gm in deactivate) gm.SetActive(false);
            pm.enabled = true;
            hs.enabled = true;
            cmtv.changeCamera(2);
            flying = true;
        }
    }



}
