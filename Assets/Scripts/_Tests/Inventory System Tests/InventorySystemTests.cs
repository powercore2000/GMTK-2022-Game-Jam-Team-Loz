using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using InventorySystem;
using DiceSystem;

public class InventorySystemTests
{
    // Test to ensure d6 functions properly
    [Test]
    public void TestAddingInventory()
    {
        Inventory inventory = new Inventory();
        inventory.AddDie(new D10_Dice());
        Assert.IsTrue(inventory.InventoryAcessor.Count == 1);
        inventory.UseDieAtIndex(0);
        Assert.IsTrue(inventory.InventoryAcessor.Count == 0);
        //Debug.Log($"d6 rolled a {result}!");

    }


}
