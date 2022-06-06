using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marbleMove : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed = 5f;



    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
        //Store user input as a movement vector
        Vector3 m_Input = new Vector3(0,0,0);

        if (Input.GetKey(KeyCode.A))
            m_Input = new Vector3(3, 0, m_Input.y);
        if (Input.GetKey(KeyCode.D))
            m_Input = new Vector3(-3, 0, m_Input.y);
        if (Input.GetKey(KeyCode.S))
            m_Input = new Vector3(m_Input.x, 0, 3);
        if (Input.GetKey(KeyCode.W))
            m_Input = new Vector3(m_Input.x, 0,-3);


        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        m_Rigidbody.AddForce( m_Input * Time.deltaTime * m_Speed);
    }
}
