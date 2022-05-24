using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeliceSpin : MonoBehaviour
{
    [Range(0, 1)]
    public float spinSpeed;




    void Update()
    {

            transform.Rotate(Vector3.forward, spinSpeed * 5000 * Time.deltaTime);
    }
}
