using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;
using EntitySystem;
using DiceSystem;

public class GameHandler : MonoBehaviour
{

    [SerializeField]
    // private GameObject entityGameObject;
    private GameObject inventoryGameObject;
    private InventoryBehaviour inventoryEntity;
    List<ICustomDie> inventory = new List<ICustomDie>();

    GameObject player;

    private void Awake()
    {
        // entity = entityGameObject.GetComponent<IEntity>();
        inventoryEntity = inventoryGameObject.GetComponent<InventoryBehaviour>();
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        // TODO set proper keys
        if(Input.GetKeyDown(KeyCode.P)) {
            // Save
            Debug.Log("Saving data");

            inventory = new List<ICustomDie>(inventoryEntity.Inventory.GetInventory());

            // Debug.Log("Saved Inventory count: "+ inventory.Count);

            // TODO Save stuff
            // PlayerPrefs.SetFloat("X", 0.5f);
            // PlayerPrefs.SetInt("count", count);
            // PlayerPrefs.Save();

        }

        // TODO set proper keys
        if(Input.GetKeyDown(KeyCode.L)) {
            // Load

            // Debug.Log("Load Inventory count: "+inventory.Count);

            player.GetComponent<InventoryBehaviour>().Inventory.SetInventory(inventory);

            // TODO load stuff
            // int temp = PlayerPrefs.GetInt("count");

        }
    }
}
