using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiceSystem;

namespace DiceBehaviour{
    public class CustomDiceManagerBehaviour : MonoBehaviour
    {
        static bool addedDice;
        // Start is called before the first frame update
        void Awake()
        {
            if (!addedDice)
            {
                DiceManager.AddDice(new D4_Dice());
                DiceManager.AddDice(new D6_Dice());
                DiceManager.AddDice(new D8_Dice());
                DiceManager.AddDice(new D10_Dice());
                DiceManager.AddDice(new D12_Dice());
                DiceManager.AddDice(new D20_Dice());
                DiceManager.AddDice(new D100_Dice());
                DiceManager.AddDice(new HealDice());
                DiceManager.AddDice(new SacrificeDice());

                addedDice = true;
            }
        }

    }
}