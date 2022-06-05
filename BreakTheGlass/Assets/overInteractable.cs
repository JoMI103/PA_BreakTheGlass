using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overInteractable : MonoBehaviour
{
    public bool over;

    public void Start()
    {
        over = false;
    }

    public void isover()
    {
        over = true;
    }
    public void isntover()
    {
        over = false ;
    }
}
