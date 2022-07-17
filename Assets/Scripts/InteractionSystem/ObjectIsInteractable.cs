using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectIsInteractable : MonoBehaviour
{
    [SerializeField] private string TagString = "Dice";
    [SerializeField] private UnityEvent OnDiceHit;

    //When we collide with an object, check if that collision was the one in the TagString variable
    //Hack: use this script multiple times on one object with different TagStrings if you want different things to fire different UnityEvents.
    //Or extend it with nice code.
    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == TagString) {
            Debug.Log("Dice hit - invoking any UnityEvents in " + gameObject.name);
            if (OnDiceHit != null)
            OnDiceHit.Invoke(); //Invoke UnityEvent listeners if they exist to be listened to
            else Debug.LogWarning("This UnityEvent in " + gameObject.name + " has no scripts in it!");
        }
    }


    public void debugTest(){
        Debug.Log("Fromage");
    }
}
