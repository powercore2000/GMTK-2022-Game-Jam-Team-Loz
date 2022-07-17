using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHandler : MonoBehaviour
{
    public GameObject stick;
    public GameObject remoteObj;
    private bool _switched = true;

    public bool Switched
    {
        get
        {
            return _switched;
        }
        set
        {
            _switched = value;
            Vector3 tmpPos = stick.transform.localPosition;
            if (_switched == true)
            {
                tmpPos.z = -0.08f;
            } else
            {
                tmpPos.z = 0.08f;
            }
            stick.transform.localPosition = tmpPos;
            
        }
    }
    public void Toggle()
    {
        Switched = !Switched;
        remoteObj.SetActive(Switched);
    }
}
