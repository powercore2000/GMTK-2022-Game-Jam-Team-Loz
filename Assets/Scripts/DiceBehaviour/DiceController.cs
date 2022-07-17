using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using InventorySystem;
using DiceSystem;

namespace DiceBehaviour
{
    public class DiceController : MonoBehaviour
    {

        public bool selected = false;
        [SerializeField]
        string dieString;
        ICustomDie dieData;
        // Start is called before the first frame update


        void Start()
        {
            dieData = DiceManager.DiceMasterList[dieString];
            Debug.Log($"Starting Dice Controller with dice {dieData.DieName}");
        }


        public void OnDiceSelected()
        {
            Debug.Log("Dice Selected!");
            selected = true;
            GameObject player = GameObject.FindWithTag("Player");

            bool added = player.GetComponent<InventoryBehaviour>().Inventory.AddDie(dieData);

            if (added)
            {

                Debug.Log("Destroying Object.");
                Destroy(gameObject);

            }

        }


        private void OnDestroy()
        {

        }
    }
}