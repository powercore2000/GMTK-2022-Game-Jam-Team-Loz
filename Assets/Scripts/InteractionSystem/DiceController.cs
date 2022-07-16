using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

        // TODO add to inventory

        Debug.Log("Destroying Object.");
        Destroy(gameObject);

    }

    private void OnDestroy()
    {

    }
}
