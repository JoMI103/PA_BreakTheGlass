using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
 
    private InventorySystem _IS;
    private WorldInspector _WI;

    public CharacterController controller;

    private float speed;
    private float gravity;
    private float jumpHeight;

    public Transform groundCheck;
    private float groundDistance;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;

    private void Start()
    {
        _IS = GetComponent<InventorySystem>();
        _WI = GetComponentInChildren<WorldInspector>();
        speed = 2.5f;
        gravity = -9.81f;
        jumpHeight = 1f;
        groundDistance = 0.4f;
    }

    void Update()
    {
        //Debug.Log("body" + this.transform.position);
        if (_WI.Worldinspecting) return;
        if (_IS.InventoryIsOpen) 
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0) velocity.y = -2;

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            if (Input.GetKeyDown(KeyCode.LeftShift))
                speed = 5;
            if (Input.GetKeyUp(KeyCode.LeftShift))
                speed = 2.5f;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);


            velocity.y += gravity * Time.deltaTime;
        }

       

        controller.Move(velocity * Time.deltaTime);

        //if (move.x > 0.1f || move.z > 0.1f || move.z < -0.1f || move.x < -0.1f)
       
    }
}
