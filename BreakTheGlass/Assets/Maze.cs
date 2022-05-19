using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Maze : MonoBehaviour
{
    [SerializeField]
    private Transform InspectorCameraTransform;



    public Collider cl;
    public Transform spawnPoint;
    public GameObject marble;

    private RayCastReceiver receiver;
    private checkItem _CI;

    private bool lockk;
    public bool inspecting;

    private void Start()
    {
        receiver = GetComponent<RayCastReceiver>();
        _CI = GetComponent<checkItem>();
        lockk = false;
        inspecting = true;
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

        if (receiver.ctRight)
        {
            Debug.Log("vremivretirve");
            receiver.castedRight();

            if (inspecting)
            {
                if (receiver.player.GetComponent<WorldInspector>().
                    cameraToInspecting(InspectorCameraTransform.position, InspectorCameraTransform.rotation))
                    inspecting = !inspecting;
            }
            else
                    if (receiver.player.GetComponent<WorldInspector>().cameraToBody()) inspecting = !inspecting;
        }
    }

}
