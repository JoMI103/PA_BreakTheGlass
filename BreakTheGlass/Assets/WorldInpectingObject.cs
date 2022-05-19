using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInpectingObject : MonoBehaviour
{
    [SerializeField]
    private Transform InspectorCameraTransform;

    private RayCastReceiver receiver;
    private bool inspecting;

    // Start is called before the first frame update
    void Start()
    {
        receiver = GetComponent<RayCastReceiver>();
        inspecting = true;
    }

    // Update is called once per frame
    void Update()
    {
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
