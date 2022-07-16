using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace InteractionSystem
{
public class InteractionSystem : MonoBehaviour
{

    [SerializeField]
    public UnityEvent OnInteractEvents;

    public void OnMouseDown()
    {
        // TODO only select object if within a certain unobstructed distance from player
        Debug.Log("Invoking On Interact Events.");
        OnInteractEvents.Invoke();

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
}