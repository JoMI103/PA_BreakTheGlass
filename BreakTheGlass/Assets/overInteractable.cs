using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overInteractable : MonoBehaviour
{
    public bool over;

    public void isover()
    {
        over = true;
    }
    public void isntover()
    {
        over = false ;
    }
}
