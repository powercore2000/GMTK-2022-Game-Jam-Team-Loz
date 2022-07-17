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

     [SerializeField]
    public UnityEvent OnExitTrigger;

    bool inside;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {

            inside = true;
            OnEnterTrigger.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            inside = false;
            OnExitTrigger.Invoke();
        }

    }
    void Update() {
        //Insert input button here, if you are doing this inside the trigger zone, do something maybe
        if (Input.GetMouseButtonDown(0) && inside) {
            OnInputInsideTrigger.Invoke();
        }
    }

    public void debugText(string str){
        Debug.Log(str);
    }

}
