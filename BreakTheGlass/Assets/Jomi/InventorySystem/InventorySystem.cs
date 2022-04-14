using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public InventorySlot[] slots;
    public GameObject inventoryUI;


    private void Update()
    {
        if (InspectorScript.inspecting) return;

        if (!inventoryUI.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            Cursor.lockState = CursorLockMode.None;
        }
    }


    public void addItem(Item i)
    {
        foreach (InventorySlot s in slots)
        {
            if (s.slotItem.name == "Nothing")
            {
                s.slotItem = i;
                updateSlots();
                return;
            }
        }

        Debug.Log("no Space");

    }


    

    public void updateSlots()
    {
        foreach(InventorySlot s in slots)
        {
            s.updateButton();
        }
    }

}
