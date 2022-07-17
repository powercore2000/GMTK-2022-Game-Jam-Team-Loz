using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiceSystem;
using System;
using PlayerSystems;
using UnityEngine.Events;

namespace DiceBehaviour
{

    [Serializable]
    public class SacrificeDice : ICustomDie
    {
        public int[] RollTableValues {get; private set;}
        public string DieName => "Sacrifice Die";
        public GameObject DicePrefab { get; private set; }

        PlayerStatsBehaviour playerStatsScript;

        [SerializeField]
        UnityEvent OnDieRoll;

        [SerializeField]
        UnityEvent OnDieRollVFX;


        public int RollResult()
        {
            OnDieRoll.Invoke();
            OnDieRollVFX.Invoke();
            int result = UnityEngine.Random.Range(0, RollTableValues.Length);

            return result;
        }

        // Start is called before the first frame update
        void CheckForAbility(int result)
        {
            playerStatsScript = GameObject.FindWithTag("Player").GetComponent<PlayerStatsBehaviour>();
            switch (result) {

                //Heal
                case 1:
                    {

                        playerStatsScript.PlayerStatsInstance.TakeDamage(1);


                    }
                    break;

                //Heal
                case 2:
                    {
                        Debug.Log("Invisiblity!");

                    }
                    break;

                //Heal
                case 3:
                    {

                        Debug.Log("Heal 15?");


                    }
                    break;


            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}