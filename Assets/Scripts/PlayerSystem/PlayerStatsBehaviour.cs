using DiceSystem;
using UnityEngine;

namespace PlayerSystems
{
    //Monohebehaviour acessor for PlayerStats script
    public class PlayerStatsBehaviour : MonoBehaviour {

        #region Property Fields
        [field: SerializeField]
        public PlayerStats PlayerStatsInstance { get; private set; }
        #endregion

        #region Monobehaviour Methods
        //Initalizes the players stats to default values
        private void Awake()
        {
            PlayerStatsInstance = new PlayerStats();
            PlayerStatsInstance.SetCharacterStats(10);
        }
        #endregion



    }

    [System.Serializable]
    public class PlayerStats
    {
        #region Property Fields
        [field: SerializeField]
        public int Health { get; private set; }
        [field: SerializeField]
        public int MaxHealth { get; private set; }

        [field: SerializeField]
        public bool IsDead { get; private set; }

        [field: SerializeField]
        public ICustomDie PersonalDie { get; private set; }

        #endregion

        #region Player Status Methods
        public void SetCharacterStats(int health)
        {

            MaxHealth = health;
            Health = MaxHealth;

            PersonalDie = new D6_Dice();


        }

        public void Death()
        {

            Debug.Log("You died!");
            IsDead = true;
        }
        #endregion

        #region Player Dice Rolling Methods

        public int RollPersonalDie()
        {

            return PersonalDie.RollResult();
        }

        #endregion

        #region Player Effect Methods
        public void TakeDamage(int damage)
        {

            Health -= damage;

            if (Health <= 0) Death();
        }

        public void Heal(int ammount)
        {

            Health += ammount;
            Health = Mathf.Clamp(Health, 0, MaxHealth);
        }
        #endregion

    }



}