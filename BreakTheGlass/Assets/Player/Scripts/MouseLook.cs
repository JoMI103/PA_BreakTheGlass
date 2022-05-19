using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseLook : MonoBehaviour
{

    private InventorySystem _IS;
    private WorldInspector _WI;

    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

    public Vector3 posIni = new Vector3(0.05f, 0.623f, 0);

    void Start()
    {
        _IS = GetComponentInParent<InventorySystem>();
        _WI = GetComponent<WorldInspector>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) {  return; }
        if (_IS.InventoryIsOpen || _WI.Worldinspecting) return;


        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(mouseX * Vector3.up);

    }
}
