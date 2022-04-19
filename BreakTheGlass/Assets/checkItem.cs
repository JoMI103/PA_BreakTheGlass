using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkItem : MonoBehaviour
{
    public bool removeItemAfterUse;
    public Item itemToCheck;
    public RayCastReceiver _RCR;

  

    public bool checkItems()
    {
        bool returnn = false;
        InventorySystem _IS = _RCR.player.gameObject.GetComponentInParent<InventorySystem>();


        returnn = _IS.findItem(itemToCheck);
        if (removeItemAfterUse && returnn)
        {
            //remove;
        }
        return returnn;
    }

}
