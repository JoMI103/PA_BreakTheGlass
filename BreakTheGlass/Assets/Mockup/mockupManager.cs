using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mockupManager : MonoBehaviour
{
    public GameObject player;
    private InventorySystem _IS;


    public GameObject mockUpIn, mockUpOut;
    public GameObject placeObjectUI;

    public Transform[] placeVectors;

    public mockupObject[] mObjectIn,mObjectOut;



    void Start()
    {
        _IS = player.GetComponentInChildren<InventorySystem>();

        mObjectIn = new mockupObject[placeVectors.Length];
        mObjectOut = new mockupObject[placeVectors.Length];

        mockupObject mo;
        int i = 0;
        foreach(Transform tf in placeVectors)
        {
            Vector3 vectemp = Vector3.Scale(tf.localPosition, mockUpOut.transform.localScale);

            mObjectOut[i] = Instantiate(placeObjectUI, mockUpOut.transform.position + new Vector3(-vectemp.z, vectemp.y, vectemp.x), mockUpOut.transform.localRotation, mockUpOut.transform).GetComponent<mockupObject>();

            mObjectOut[i].raycastable = false;
            mObjectOut[i].rayCastableCube.SetActive(false);
            mObjectIn[i] = Instantiate(placeObjectUI, mockUpIn.transform.position + Vector3.Scale(tf.localPosition, mockUpIn.transform.localScale), mockUpIn.transform.localRotation, mockUpIn.transform).GetComponent<mockupObject>();
            mObjectIn[i].raycastable = true;
            mObjectIn[i]._MM = this;
            mObjectIn[i].id = i;

            i++;
            Destroy(tf.gameObject);
        }

    }

    public void setMockupObject(int id)
    {
        Item item = _IS.nothing;
        if (_IS.selectedSlot != null)
        {
            item = _IS.selectedSlot.slotItem;
        }
       
        if (item.placeableGameObject == null) return;
        _IS.remove(item);
        mObjectIn[id].addGameobject(item,item.placeableGameObject);
        mObjectOut[id].addGameobject(item,item.placeableGameObject);
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
}
