using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DiceController : MonoBehaviour
{

    public bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Dice Controller");
        InteractionSystem.current.OnDiceTriggerSelect += OnDiceSelected;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDiceSelected()
    {
        Debug.Log("Dice Selected!");
        selected = true;

        // TODO add to inventory

        Destroy(gameObject);

    }

    private void OnDestroy()
    {
        InteractionSystem.current.OnDiceTriggerSelect -= OnDiceSelected;
    }
}
