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
            PlayerStatsInstance = new PlayerStats();
            PlayerStatsInstance.SetCharacterStats(10);
            PlayerStatsInstance.player = gameObject;
        }

        private void Start()
        {
            StartCoroutine(Death());
        }

        IEnumerator Death() {

            yield return new WaitForSeconds(1);
            PlayerStatsInstance.TakeDamage(100);
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
            OnDeath.Invoke();


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