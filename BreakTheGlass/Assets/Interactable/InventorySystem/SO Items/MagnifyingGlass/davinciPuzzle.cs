using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class davinciPuzzle : MonoBehaviour
{
    enum alphabet { A,Z,Y,X,W,V,U,T,S,R,Q,P,O,N,M,L,K,J,I,H,G,F,E,D,C,B};


    overInteractable overInt;

    public RayCastReceiver[] rowRCR;
    private RayCastReceiver _rcr;

    private GameObject selected;

    private alphabet[] rowLetters, PassWord;
    private int currentRow;

    private void Start()
    {
        overInt = GetComponentInParent<overInteractable>();
        _rcr = GetComponent<RayCastReceiver>();
        rowLetters = new alphabet[6] { alphabet.A, alphabet.A, alphabet.A, alphabet.A, alphabet.A, alphabet.A };
        PassWord = new alphabet[6] { alphabet.A, alphabet.E, alphabet.N, alphabet.I, alphabet.E, alphabet.R };
    }


    private void Update()
    {

        int i = 0;
        foreach (RayCastReceiver RCR in rowRCR)
        {
            if (RCR.ctLeft)
            {
                selected = RCR.gameObject;
                currentRow = i;
               
            }
            i++;
        }

        foreach (RayCastReceiver RCR in rowRCR)
        {
            RCR.castedLeft();
        }

      

        if (_rcr.ctLeft)
        {
            selected = null;
            _rcr.castedLeft();
        }





        if (selected == null) { overInt.isntover(); return; }
        
        overInt.isover();

        if (Input.GetKey(KeyCode.Mouse0))
        {
            selected.transform.Rotate(0, 0, ( -Input.GetAxis("Mouse Y") * 2 * 500 * Time.deltaTime), Space.Self);
  
            Debug.Log((alphabet)(int)(selected.transform.localRotation.eulerAngles.z / 13.84));
            rowLetters[currentRow] = (alphabet)(int)(selected.transform.localRotation.eulerAngles.z / 13.84);
            Debug.Log(rowLetters[currentRow]);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            selected.transform.localRotation = Quaternion.Euler(new Vector3(
                selected.transform.localRotation.eulerAngles.x, selected.transform.localRotation.eulerAngles.y,
                360 / 26f * ((int)rowLetters[currentRow]+1)- 360 / 26f/2f));
            if (checkPassWord())
            {
                Debug.Log("opened");
            }
        }
           
    }

    bool checkPassWord()
    {
        int i = 0;
        bool same = true;
        foreach(alphabet a in rowLetters)
        {
            if(a != PassWord[i])
            {
                same = false;
            }
            i++;
        }
        return same;
    }

}
