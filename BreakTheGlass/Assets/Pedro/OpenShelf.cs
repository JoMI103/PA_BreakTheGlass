using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShelf : MonoBehaviour
{

    [SerializeField] private CheckTrigger trigger;
    private Animator _an;
    private bool shelfisclosed = true;
    private RayCastReceiver receiver;

    private void Start()
    {
        receiver = GetComponent<RayCastReceiver>();
        _an = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (!(_an.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !_an.IsInTransition(0))) return;

        if (trigger.colliding)
        {
            if (Input.GetKeyUp(KeyCode.E) && receiver.ct)
            {
                receiver.casted();

                if (shelfisclosed)
                {
                    _an.Play("OpenShelf");
                    shelfisclosed = false;
                }
                else
                {
                    _an.Play("CloseShelf");
                    shelfisclosed = true;
                }               
            }
        }
    }

}
