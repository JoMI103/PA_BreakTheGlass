using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mockupManager : MonoBehaviour
{
    public finalReward fr;

    public GameObject player;
    private InventorySystem _IS;


    public GameObject mockUpIn, mockUpOut;
    public GameObject placeObjectUI;


    [HideInInspector] public mockupObject[] mObjectIn,mObjectOut;
    [HideInInspector] public GameObject[] mObjectInSelectObject;
    [HideInInspector] public WorldInpectingObject WIO;

    private bool active;


    private GameObject rewardPortal1,rewardPortal2;

    [System.Serializable]
    public struct ItemPlace
    {
        public Transform placeItem;
        public Item defaultItem;
        public Item[] permitItems;
        public Item puzzleItem;
    }
     public ItemPlace[] itemsPlace;


    void Start()
    {
        
        _IS = player.GetComponentInChildren<InventorySystem>();

        mObjectIn = new mockupObject[itemsPlace.Length];
        mObjectOut = new mockupObject[itemsPlace.Length];
        mObjectInSelectObject = new GameObject[itemsPlace.Length];

        mockupObject mo;
        int i = 0;
        foreach(ItemPlace tf in itemsPlace)
        {
            Vector3 vectemp = Vector3.Scale(tf.placeItem.localPosition, mockUpOut.transform.localScale);

            mObjectOut[i] = Instantiate(placeObjectUI, mockUpOut.transform.position + new Vector3(-vectemp.z, vectemp.y, vectemp.x), mockUpOut.transform.localRotation, mockUpOut.transform).GetComponent<mockupObject>();

            mObjectOut[i].raycastable = false;
            mObjectOut[i].rayCastableCube.SetActive(false);
            mObjectIn[i] = Instantiate(placeObjectUI, mockUpIn.transform.position + Vector3.Scale(tf.placeItem.localPosition, mockUpIn.transform.localScale), mockUpIn.transform.localRotation, mockUpIn.transform).GetComponent<mockupObject>();
            mObjectIn[i].raycastable = true;
            mObjectIn[i]._MM = this;
            mObjectIn[i].id = i;
            mObjectInSelectObject[i] = mObjectIn[i].rayCastableCube.gameObject;
            i++;
            Destroy(tf.placeItem.gameObject);
        }

        i = 0;
        foreach(ItemPlace it in itemsPlace)
        {
            if(it.defaultItem != null)
            {
                setMockupObject(i, it.defaultItem);
            }
            i++;
        }



        active = true;
        foreach (GameObject g in mObjectInSelectObject) g.SetActive(false);
    }

    private void Update()
    {
        if (!WIO.inspecting)
        {
            if (!active)
            {
                foreach (GameObject g in mObjectInSelectObject) g.SetActive(true);
                foreach (mockupObject mo in mObjectIn) mo.raycastable = true;
                active = true;
            }
        }

        if (WIO.inspecting)
        {
            if (active)
            {
                foreach (GameObject g in mObjectInSelectObject) g.SetActive(false);
                foreach (mockupObject mo in mObjectIn) mo.raycastable = false;
                active = false;
            }
        }
    }

    public void setMockupObject(int id, Item defaulItem = null)
    {
        Item item = _IS.nothing;
        if(defaulItem != null)
        {
            item = defaulItem;
        }
        if (_IS.selectedSlot != null)
        {
            item = _IS.selectedSlot.slotItem;
        }
       
        if (item.placeableGameObject == null) return;

        if(itemsPlace[id].permitItems.Length > 0)
        {
            bool same = false;
            foreach (Item it in itemsPlace[id].permitItems)
            {

                if (item = it) { same = true; }
            }
          
            if (same) return;
        }
        
        _IS.remove(item);
        mObjectIn[id].addGameobject(item,item.placeableGameObject);
        mObjectOut[id].addGameobject(item,item.placeableGameObject);

        if (checkPuzzle()) {

            fr.activateReward();
            Debug.Log("puzzleCOmplete"); }
    }

    public void removeMockupObject(Item item, int id)
    {
        _IS.addItem(item);
        mObjectIn[id].removeGameobject();
        mObjectOut[id].removeGameobject();
    }

    public void setActivePlaceableObjects(bool var)
    {
        foreach (mockupObject mo in mObjectIn)
        {
            mo.rayCastableCube.SetActive(var);
        }
    }

    public bool checkPuzzle()
    {
        return true;
        bool var = true;
        int i = 0;
        foreach(ItemPlace ip in itemsPlace)
        {
            
            if(ip.puzzleItem != null)
            {
                if (ip.puzzleItem != mObjectIn[i].currentItem) var = false;
            }
            i++;
        }

        return var;
    }
}
