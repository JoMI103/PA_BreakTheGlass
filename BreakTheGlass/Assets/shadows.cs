using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadows : MonoBehaviour
{
    public Light[] _shadows;


    private void Start()
    {
    
        foreach (Light light in _shadows)
        {
            light.shadows = LightShadows.None;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {         
                foreach (Light light in _shadows)
                {
                    light.shadows = LightShadows.None;
                }
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            foreach (Light light in _shadows)
            {
                light.shadows = LightShadows.Soft;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            foreach (Light light in _shadows)
            {
                light.shadows = LightShadows.Hard;
            }
        }
    }
}
