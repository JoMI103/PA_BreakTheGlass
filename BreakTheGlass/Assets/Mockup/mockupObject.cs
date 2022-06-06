using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mockupObject : MonoBehaviour
{
    public int id;
    public bool raycastable;
    
    public mockupManager _MM;
    RayCastReceiver _RCR;

    public Item currentItem;

    private GameObject currentGameobject;

    public GameObject rayCastableCube;

    void Start()
    {
        _RCR = GetComponentInChildren<RayCastReceiver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!raycastable) return;


        if (_RCR.ctLeft)
        {
            if(currentItem == null)
            {
                
                _RCR.castedLeft();
                _MM.setMockupObject(id);
            }
        }

        if (_RCR.ctRight)
        {
            if (currentItem != null)
            {
                Debug.Log("gbrtge");
                _MM.removeMockupObject(currentItem, id);
                _RCR.castedRight();
            }
        }
    }

    public void addGameobject(Item item,GameObject go)
    {
        currentItem = item;
        currentGameobject = Instantiate(go,this.transform.position,this.transform.rotation,this.transform);
    }

    public void removeGameobject()
    {
        currentItem = null;
        Destroy(currentGameobject);
    }


    
}
