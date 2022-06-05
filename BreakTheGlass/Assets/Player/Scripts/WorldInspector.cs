
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInspector : MonoBehaviour
{
   
    private Vector3 targetPos,lastPos;
    private Quaternion targetRot, lastRot;

    public bool Worldinspecting;
    private bool isMoving, makeWorldinspecting;

    [SerializeField]
    private float transitionSpeed, magnitude, degree;

    const float errorfloat = 0.01f;

    private RayCastEmitter rce;

    void Start()
    {
        rce = GetComponent<RayCastEmitter>();
           targetPos = transform.position;
        targetRot = transform.rotation;
        isMoving = false;
        Worldinspecting = false;
        makeWorldinspecting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Worldinspecting) { 
            Cursor.lockState = CursorLockMode.None;
            rce.ForwardFree = false;
        }

        if (!Worldinspecting && !isMoving)
        {
            lastPos = transform.position;
            lastRot = transform.rotation;
            rce.ForwardFree = true;
            return;
        }


        if (transform.position.magnitude >= targetPos.magnitude - errorfloat
            && transform.position.magnitude <= targetPos.magnitude + errorfloat)
        {
            transform.position = targetPos;
            transform.rotation = targetRot;
            if (makeWorldinspecting) { Worldinspecting = false; makeWorldinspecting = false; }
            isMoving = false;
            return;
        }
        else
        {
            
            isMoving = true;
            Debug.Log("FWER");
            transform.position = Vector3.MoveTowards(transform.position, targetPos, transitionSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.RotateTowards(transform.rotation.eulerAngles, targetRot.eulerAngles,
                degree * Mathf.Deg2Rad,magnitude));
        }
    }

    public bool cameraToInspecting(Vector3 finalPosition, Quaternion finalRotation)
    {
        if (isMoving) return false;
        targetPos = finalPosition;
        targetRot = finalRotation;
        Worldinspecting = true;
    
        return true;
    }
    public bool cameraToBody()
    {
        if (isMoving) return false;
        targetPos = lastPos;
        targetRot = lastRot;
        makeWorldinspecting = true;
        isMoving = true;
       
        return true;
    }

}
