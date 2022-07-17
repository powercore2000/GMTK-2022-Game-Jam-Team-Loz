using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceSystem {


    public static class DiceManager
    {
        static Dictionary<string, ICustomDie> diceMasterList  = new Dictionary<string, ICustomDie>();
        public static Dictionary<string, ICustomDie> DiceMasterList => diceMasterList;
        public static void AddDice(ICustomDie die) {

            diceMasterList.Add(die.DieName,die);


        }

    }

}