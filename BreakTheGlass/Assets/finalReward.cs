using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalReward : MonoBehaviour
{
    public GameObject portal1, portal2, plane;
    private enterPlane ep;
    

    private void Start()
    {
        ep = plane.GetComponent<enterPlane>();
    }

    public void activateReward()
    {
        portal1.SetActive(true);
        portal2.SetActive(true);
        plane.SetActive(true);
    }

}
