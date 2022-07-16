using System.Collections.Generic;
using DiceSystem;
using UnityEngine;

namespace InventorySystem
{
    //Monobehaviour wrapper
    public class InventoryBehaviour : MonoBehaviour
    {
        [field: SerializeField]
        public Inventory Inventory { get; private set; }

        void Awake()
        {
            Inventory = new Inventory();

            Inventory.AddDie(new D6_Dice());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    [System.Serializable]
    public class Inventory
    {

        const int maxSlots = 3;

        #region Property Fields
        public IReadOnlyCollection<ICustomDie> InventoryAcessor => inventory.AsReadOnly();

        [SerializeField]
        List<ICustomDie> inventory = new List<ICustomDie>();
        #endregion

        #region Inventory Manipulation Methods
        public bool AddDie(ICustomDie die) {

            if(inventory.Count < maxSlots) {

                inventory.Add(die);
                return true;
            }

            Debug.Log("Inventory full!");
            return false;

        }

        public void UseDieAtIndex(int index)
        {

            inventory[index].RollResult();
            inventory.RemoveAt(index);
        }

        public int GetCount() {
            return inventory.Count;
        }

        public List<ICustomDie> GetInventory() {
            return inventory;
        }

        public void SetInventory(List<ICustomDie> new_inventory) {
            inventory = new_inventory;
            return;
        }
        #endregion
    }


}