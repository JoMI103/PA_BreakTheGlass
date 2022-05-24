using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    [SerializeField, Range(0.001f, 1)]
    private float scale;

    private bool crash;
    private Rigidbody rb;

    private Vector3 direction;
    [SerializeField, Range(1, 25)]
    private float speed;

    //      Pitch - Yaw - Roll;
    public Vector3 EulerAngleVelocity;
    private float pitch, yaw, roll;

    [SerializeField, Range(1, 10)]
    private float pitchMod, yawMod, rollMod;


  


    void Start()
    {
        crash = false;
        direction = -Vector3.forward;
        transform.rotation = Quaternion.LookRotation(direction);
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = float.MaxValue;
        rb.maxAngularVelocity = float.MaxValue;
    }

    // Update is called once per frame
    void Update()
    {

        if (crash) return;

        if (Input.GetKeyDown(KeyCode.O))
        {
            rb.isKinematic = true;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            rb.isKinematic = false;
        }

        pitch = Input.GetAxis("Vertical");

        roll = -Input.GetAxisRaw("Horizontal");
    }

    public bool IsBetween(float testValue, float bound1, float bound2)
    {

        return testValue >= bound1 && testValue <= bound2;
    }

    private void FixedUpdate()
    {

        if (crash) return;

        updatePhysics();

        rb.MoveRotation(rb.rotation * Quaternion.Euler(EulerAngleVelocity * Time.fixedDeltaTime));
        rb.AddForce(transform.forward.normalized * speed * 10 * scale);
    }
    private void updatePhysics()
    {
        float rollAngle = 360f - rb.rotation.eulerAngles.z;
        float rollAngleRest = rollAngle % 90f;
        rollAngleRest = rollAngleRest / 45;
        if (rollAngleRest > 1) rollAngleRest = 2 - rollAngleRest;

        if (IsBetween(rollAngle, 0.15f, 89.85f))
        {
            yaw = 0.4f * rollAngleRest;
            pitch -= 0.25f * rollAngleRest;
            //Debug.Log(rollAngleRest + "      -     " + roll);
        }
        if (IsBetween(rollAngle, 270.15f, 359.85f))
        {
            yaw = -0.4f * rollAngleRest;
            pitch -= 0.25f * rollAngleRest;
            //Debug.Log(rollAngleRest + "      -     " + roll);
        }
        if (IsBetween(rollAngle, 90.15f, 179.85f))
        {
            yaw = +0.25f * rollAngleRest;
            //Debug.Log(rollAngleRest + "      -     " + roll);
        }
        if (IsBetween(rollAngle, 180.15f, 269.85f))
        {
            yaw = -0.25f * rollAngleRest;
            //Debug.Log(rollAngleRest + "      -     " + roll);
        }

        EulerAngleVelocity = new Vector3(pitch * pitchMod, yaw * yawMod, roll * rollMod) * 10;
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.useGravity = true;
        crash = true;
       // GetComponent<PlaneGun>().crashed();
    }

}
