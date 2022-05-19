using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{

    private RayCastReceiver receiver;

    public Item item;

    void Start()
    {
        receiver = GetComponent<RayCastReceiver>();
    }


    void Update()
    {
        if (receiver.ctLeft)
        {
            receiver.castedLeft();
            if(receiver.player!=null)
            receiver.player.GetComponentInParent<InventorySystem>().addItem(item);
            Destroy(this.gameObject);
        }

    }
}
