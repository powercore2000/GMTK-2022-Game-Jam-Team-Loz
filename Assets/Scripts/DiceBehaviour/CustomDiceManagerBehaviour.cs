using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiceSystem;

namespace DiceBehaviour{
    public class CustomDiceManagerBehaviour : MonoBehaviour
    {
        // Start is called before the first frame update
        void Awake()
        {
            DiceManager.AddDice(new HealDice());
            DiceManager.AddDice(new SacrificeDice());
        }

    }
}