using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Array : MonoBehaviour
{
    public GameObject Object;
    public int numb;
    public Vector3 offSet ,of;

    public void CreateArray()
    {
        for(int i = 0; i < numb; i++)
        {
            
            GameObject instiatedObject = Instantiate(Object, this.transform);
            Debug.Log(offSet);
            Debug.Log(instiatedObject.GetComponent<MeshFilter>().sharedMesh.bounds.extents);
            Debug.Log(instiatedObject.transform.localScale + "\n\n");
            instiatedObject.transform.localPosition = Vector3.zero + Vector3.Scale(offSet,Vector3.Scale(instiatedObject.GetComponent<MeshFilter>().mesh.bounds.extents,instiatedObject.transform.localScale)) * i;
        }
        

        

    }
}
