using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private CheckTrigger frontTrigger, backTrigger;
    private Animator _an;
    private bool openBack,openFront;
    private RayCastReceiver receiver;

    private checkItem _CI;
    private bool lockk;

    private void Start()
    {
        receiver = GetComponentInChildren<RayCastReceiver>();
        _an = GetComponent<Animator>();
        openBack = false;
        openFront = false;
        _CI = GetComponent<checkItem>();
    }



    void Update()
    {
        if (!(_an.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !_an.IsInTransition(0))) return;

        if (!openFront && !openBack)
        {
            if (frontTrigger.colliding)
            {
                if (receiver.ctLeft)
                {
                    receiver.castedLeft();
                    if (_CI != null) lockk = _CI.checkItems();
                    if (lockk)
                    {
                      _an.Play("OpenBack");
                        openBack = true;
                    }
                }
            }

            if (backTrigger.colliding)
            {
                if (receiver.ctLeft)
                {
                    receiver.castedLeft();
                    if (_CI != null) lockk = _CI.checkItems();
                    if (lockk)
                    {
                        _an.Play("OpenFront");
                        openFront = true;
                    }
                }
            }
        }
        else
        {
            if (frontTrigger.colliding || backTrigger.colliding)
            {
                if (receiver.ctLeft)
                {
                    receiver.castedLeft();
                    if (openBack)
                    {
                        if (_CI != null) lockk = _CI.checkItems();
                        if (lockk)
                        {
                            openBack = false;
                            _an.Play("CloseBack");
                        }
                    }
                    
                    if (openFront)
                    {
                        if (_CI != null) lockk = _CI.checkItems();
                        if (lockk)
                        {
                            openFront = false;
                            _an.Play("CloseFront");
                        }
                    }
                        
                }
            }  
        }
        
    }
}
