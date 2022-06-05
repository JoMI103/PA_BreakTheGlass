using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public InventorySystem _IS;

    public cameraManager cm;
    public InspectorScript _IP;
    public Item slotItem;

    public Image img;
    public Image selectImg;

    private void Start()
    {
        selectImg = GetComponent<Image>();
    }

    public void updateButton()
    {
        
        img.sprite = slotItem.image;
    }


    public void selectItem()
    {
        if (slotItem == _IS.nothing) return;
        _IS.deSelectSlots();
        _IS.selectedSlot = this;
        selectImg.enabled = true;
    }

    public void deSelectSlot()
    {
        _IS.selectedSlot = null;
        selectImg.enabled = false;
    }

    public void InspectItem()
    {
        if(slotItem.prefab != null)
        {
            _IP.inspecting = true;
            cm.changeCamera(1);
            _IP.InspectObject(slotItem.prefab);
        }
    }


}
