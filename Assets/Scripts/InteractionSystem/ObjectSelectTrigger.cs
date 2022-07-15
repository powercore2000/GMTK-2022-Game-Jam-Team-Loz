using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelectTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Object Select Trigger.");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        // TODO only select object if within a certain unobstructed distance from player
        InteractionSystem.current.DiceTriggerSelect();

    }
}
