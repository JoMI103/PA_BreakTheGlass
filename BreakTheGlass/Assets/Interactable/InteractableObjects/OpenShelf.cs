using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShelf : MonoBehaviour
{


    private Animator _an;
    private bool shelfisclosed = true;
    private RayCastReceiver receiver;
    [SerializeField] private string anName;


    private checkItem _CI;
    private bool lockk;

    private void Start()
    {
        receiver = GetComponent<RayCastReceiver>();
        _an = GetComponent<Animator>();
        _CI = GetComponent<checkItem>();
        lockk = false;


    }

    private void Update()
    {
      
        if (!(_an.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !_an.IsInTransition(0))) return;

        if (receiver.ctLeft)
        {
            receiver.castedLeft();

            if (_CI != null) lockk = _CI.checkItems();

            if (lockk)
            {
                receiver.castedLeft();

                if (shelfisclosed)
                {
                    _an.Play("Open" + anName);
                    shelfisclosed = false;
                }
                else
                {
                    _an.Play("Close" + anName);
                    shelfisclosed = true;
                }
            }
        }

    }

}
