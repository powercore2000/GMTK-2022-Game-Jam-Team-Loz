using System;
using DiceSystem;
using PlayerSystems;
using UnityEngine;
using UnityEngine.Events;

namespace DiceBehaviour
{

    [Serializable]
    public class HealDice : ICustomDie
    {
        public int[] RollTableValues {get; private set;}
        public string DieName => "Heal Dice";
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

                        playerStatsScript.PlayerStatsInstance.Heal(5);


                    }
                    break;

                //Heal
                case 2:
                    {
                        Debug.Log("InCrease speed!");

                    }
                    break;

                //Heal
                case 3:
                    {

                        Debug.Log("Extra vision!");


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