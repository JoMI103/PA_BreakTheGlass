using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Array : MonoBehaviour
{
    public GameObject Object;
    public int numb;
    public Vector3 offSet;
    public bool destroyArray;

    public void CreateArray()
    {
        Debug.Log(transform.childCount);

        List<GameObject> delete = new List<GameObject>();

        if (destroyArray)
        {
            foreach (Transform child in transform)
            delete.Add(child.gameObject);
        
            foreach(GameObject g in delete)
            if (Application.isEditor) DestroyImmediate(g.gameObject);
            else Destroy(g.gameObject);
        }
        for (int i = 0; i < numb; i++)
        {
            GameObject instiatedObject = Instantiate(Object, this.transform);
            instiatedObject.transform.localPosition = Vector3.zero + Vector3.Scale(offSet,Vector3.Scale(instiatedObject.GetComponent<MeshFilter>().sharedMesh.bounds.extents,instiatedObject.transform.localScale)) * 2 * i;
        }
    }
}
