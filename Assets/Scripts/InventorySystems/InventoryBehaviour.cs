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

        // Start is called before the first frame update
        void Awake()
        {
            Inventory = new Inventory();

            Inventory.AddDie(new D10_Dice());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
    
    [System.Serializable]
    public class Inventory
    {
        #region Property Fields
        public IReadOnlyCollection<ICustomDie> InventoryAcessor => inventory.AsReadOnly();

        [SerializeField]
        List<ICustomDie> inventory = new List<ICustomDie>();
        #endregion

        #region Inventory Manipulation Methods
        public void AddDie(ICustomDie die) {

            inventory.Add(die);
        }

        public void UseDieAtIndex(int index)
        {

            inventory[index].RollResult();
            inventory.RemoveAt(index);
        }
        #endregion
    }


}