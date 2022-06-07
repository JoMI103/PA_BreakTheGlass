using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventorySystem : MonoBehaviour
{
    [SerializeField]
    private InspectorScript _IPS;

    public bool InventoryIsOpen;
    public InventorySlot[] slots;
    public GameObject inventoryUI;
    public WorldInspector wI;
    public Item nothing;

    public InventorySlot selectedSlot;

    public void Start()
    {
        InventoryIsOpen = false;
    }

    private void Update()
    {
        if (_IPS.inspecting) return;

        if (!inventoryUI.activeSelf && !wI.Worldinspecting)
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
            if (s.slotItem.name == nothing.name)
            {
                s.slotItem = i;
                updateSlots();
                selectedSlot = s;
                return;
            }
        }

        Debug.Log("no Space");

    }

    public void remove(Item i)
    {
        foreach (InventorySlot s in slots)
        {
            if (s.slotItem.name == i.name)
            {
                s.slotItem = nothing;
                updateSlots();
                return;
            }
        }

        Debug.Log("item not found");

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

    public void deSelectSlots()
    {
        selectedSlot = null;

        foreach (InventorySlot s in slots)
        {
            s.deSelectSlot();
        }
    }

    public void inspectItem() { if (selectedSlot != null) selectedSlot.InspectItem(); }

    public void useItem() { if (selectedSlot != null) selectedSlot.slotItem = nothing; selectedSlot.updateButton(); selectedSlot.deSelectSlot(); selectedSlot = null; }

    public void LoadMenu() { SceneManager.LoadScene("Menu"); }

    public void QuitGame() { Application.Quit(); }

}

