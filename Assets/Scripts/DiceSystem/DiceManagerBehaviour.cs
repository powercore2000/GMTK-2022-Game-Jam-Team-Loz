using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceSystem {

    public class DiceManagerBehaviour : MonoBehaviour
    {
        // Start is called before the first frame update
        void Awake()
        {
            DiceManager.AddDice(new D4_Dice());
            DiceManager.AddDice(new D6_Dice());
            DiceManager.AddDice(new D8_Dice());
            DiceManager.AddDice(new D10_Dice());
            DiceManager.AddDice(new D12_Dice());
            DiceManager.AddDice(new D20_Dice());
            DiceManager.AddDice(new D100_Dice());

        }

    }


    public static class DiceManager
    {
        static Dictionary<string, ICustomDie> diceMasterList  = new Dictionary<string, ICustomDie>();
        public static Dictionary<string, ICustomDie> DiceMasterList => diceMasterList;
        public static void AddDice(ICustomDie die) {

            diceMasterList.Add(die.DieName,die);


        }

    }

}