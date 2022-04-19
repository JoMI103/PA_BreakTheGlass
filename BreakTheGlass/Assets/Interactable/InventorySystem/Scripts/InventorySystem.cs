using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static bool InventoryIsOpen;

    public InventorySlot[] slots;
    public GameObject inventoryUI;
    public void Start()
    {
        InventoryIsOpen = false;
    }

    private void Update()
    {
        if (InspectorScript.inspecting) return;

        if (!inventoryUI.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryIsOpen = !InventoryIsOpen;
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

    public bool findItem(Item i)
    {
        foreach (InventorySlot s in slots)
        {
            if (s.slotItem.name == i.name)
            {
                return true;
            }
        }

        return false;
    }


    

    public void updateSlots()
    {
        foreach(InventorySlot s in slots)
        {
            s.updateButton();
        }
    }

}
