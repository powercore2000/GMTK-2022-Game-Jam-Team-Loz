using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransferZone : MonoBehaviour
{
    /*
     * This class is to be attached to an empty game object with a collider (usually sphere?)
     * The object has a scene variable to tell it what scene to load when the player arrives
     * When the player enters the collider, it triggers the load sequence for the next scene
     */
    [Header("Set In Inspector")]
    public int targetIdx;
    public GameObject playerObj;

    [Header("Set Dynamically")]
    public PhysicsScene[] sceneArray;
    public PhysicsScene targetScene;

    private void Start()
    {
        //get scene array from other object
        //or I can make it a static variable attached to this script if that's easier
        if (targetIdx >= 0 && targetIdx < sceneArray.Length)
        {
            targetScene = sceneArray[targetIdx];
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == playerObj)
        {
            //load targetScene using SceneManagerBehaviour
        }
    }
}
