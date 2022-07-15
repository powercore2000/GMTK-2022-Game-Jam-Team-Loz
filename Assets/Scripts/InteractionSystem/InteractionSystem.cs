using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{

    public static InteractionSystem current;

    private void Awake()
    {
        current = this;
    }



    public event Action OnDiceTriggerSelect;

    public void DiceTriggerSelect()
    {
        if (OnDiceTriggerSelect != null)
        {
            OnDiceTriggerSelect();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Interaction System");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
