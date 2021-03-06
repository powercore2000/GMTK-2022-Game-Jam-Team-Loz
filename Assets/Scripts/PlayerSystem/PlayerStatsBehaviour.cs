using DiceSystem;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

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
            //This creates a new blank player stats instance, overwriting any changes made in the Inspector!
            //This is why OnDeath was doing nothing - it would be cleared at runtime
            //PlayerStatsInstance = new PlayerStats();
            PlayerStatsInstance.SetCharacterStats(10);
            PlayerStatsInstance.player = gameObject;
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

        [SerializeField]
        UnityEvent OnDeath;

        [field: SerializeField]
        public ICustomDie PersonalDie { get; private set; }

        public GameObject player {get; set;}

        #endregion

        #region Player Status Methods
        public void SetCharacterStats(int health)
        {

            MaxHealth = health;
            Health = MaxHealth;

            PersonalDie = new D6_Dice();


        }

        //Call when player dies, will call all death functions on the player
        public void Death()
        {
            Debug.Log("You died!");
            IsDead = true;
            //player.SendMessage("Death");

            if (OnDeath != null)
            OnDeath.Invoke();
            else {
                Debug.LogError("OnDeath has no event listeners inside! Check the Unity Inspector or any script which uses PlayerStats or OnDeath...");
            }


        }

        //Call when player respawn will call all respawn functions on the player
        public void Respawn()
        {
            Debug.Log("Respawning");
            IsDead = false;
            player.SendMessage("Respawn");
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