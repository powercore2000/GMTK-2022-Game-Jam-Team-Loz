using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using InventorySystem;
using DiceSystem;


public class DiceController : MonoBehaviour
{

    public bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Dice Controller");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDiceSelected()
    {
        Debug.Log("Dice Selected!");
        selected = true;
        GameObject player = GameObject.FindWithTag("Player");

        bool added = player.GetComponent<InventoryBehaviour>().Inventory.AddDie(new D6_Dice());

        if(added) {

            Debug.Log("Destroying Object.");
            Destroy(gameObject);

        }

    }

    private void OnDestroy()
    {

    }
}
