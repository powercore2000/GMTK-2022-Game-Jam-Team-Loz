using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceSystem
{
    public interface ICustomDie
    {
        string DieName { get; }
        int[] RollTableValues { get; }
        GameObject DicePrefab { get; }

        public int RollResult();



    }
}