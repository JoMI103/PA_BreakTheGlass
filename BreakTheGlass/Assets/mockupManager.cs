using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mockupManager : MonoBehaviour
{

    public GameObject mockUpIn, mockUpOut;
    public GameObject placeObjectUI;

    public Transform[] placeVectors;

    
    void Start()
    {


        foreach(Transform tf in placeVectors)
        {
            Instantiate(placeObjectUI, mockUpIn.transform.position + Vector3.Scale(tf.localPosition, mockUpIn.transform.localScale), mockUpIn.transform.localRotation, mockUpIn.transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
