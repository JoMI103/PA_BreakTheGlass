using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endMaze : MonoBehaviour
{
    public GameObject key;
    public Transform keySpawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Marble")
        {
            Destroy(other.gameObject);
            Instantiate(key, keySpawnPoint.position, new Quaternion(), keySpawnPoint);
        }
    }
}
