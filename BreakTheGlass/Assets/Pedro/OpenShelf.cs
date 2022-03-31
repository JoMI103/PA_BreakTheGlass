using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShelf : MonoBehaviour
{

    [SerializeField] private CheckTrigger trigger;
    private Animator Animation;
    private bool shelfisclosed = true;


    private void Start()
    {
        Animation = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (trigger.colliding)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (shelfisclosed)
                {
                    Animation.Play("OpenShelf");
                    shelfisclosed = false;
                }
                else
                {
                    Animation.Play("CloseShelf");
                    shelfisclosed = true;
                }               
            }
        }
    }

}
