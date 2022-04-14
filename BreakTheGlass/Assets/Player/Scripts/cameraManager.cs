using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    public GameObject[] cameras;

    public void changeCamera(int id)
    {
        foreach(GameObject c in cameras)
        {
            c.SetActive(false);
        }

        if (cameras[id] != null)
        {
            cameras[id].SetActive(true);
        }
        else
        {
            cameras[0].SetActive(true);
        }    


    }
}
