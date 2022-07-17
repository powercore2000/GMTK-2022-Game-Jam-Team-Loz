using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerInteractable : MonoBehaviour
{


    [SerializeField]
    public UnityEvent OnEnterTrigger;

    [SerializeField]
    public UnityEvent OnInputInsideTrigger;

    bool inside;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {

            inside = true;
            OnEnterTrigger.Invoke();
        }
    }

}
