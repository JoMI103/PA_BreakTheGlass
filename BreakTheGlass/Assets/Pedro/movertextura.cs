using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movertextura : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveX = 0.5f;
    public float MoveY = 0.5f;

    private void Update()
    {
        float Movexx = Time.time * MoveX;
        float Moveyy = Time.time * MoveY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Movexx, Moveyy);
    }
}
