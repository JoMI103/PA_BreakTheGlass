using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public cameraManager cm;
    public InspectorScript _IP;
    public Item slotItem;

    public Image img;

    public void updateButton()
    {
        img.sprite = slotItem.image;
    }

    public void InspectItem()
    {
        if(slotItem.prefab != null)
        {
            InspectorScript.inspecting = true;
            cm.changeCamera(1);
            _IP.InspectObject(slotItem.prefab);
        }
    }


}
