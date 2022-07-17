using DiceSystem;
using UnityEngine;
using PlayerSystems;

namespace EntityStatsSystem
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

            PlayerStatsInstance.SetCharacterStats(10, new D6_Dice(), new D6_Dice());

           
        }


        #endregion



    }

    [System.Serializable]
    public class PlayerStats : IEntity
    {
        #region Property Fields

        [field: SerializeField]
        public string EntityName { get; private set; }

        public ICharacterClass PlayerClass { get; private set; }

        [field: SerializeField]
        public int Health { get; private set; }

        [field: SerializeField]
        public int MaxHealth { get; private set; }

        [field: SerializeField]
        public bool IsDead { get; private set; }

        [field: SerializeField]
        public ICustomDie AttackDie { get; private set; }
        [field: SerializeField]
        public ICustomDie MovementDie { get; private set; }
        [field: SerializeField]
        public int CurrentMovementPoints { get; private set; }
        [field: SerializeField]
        public int TotalMovementPoints { get; private set; }
        [field: SerializeField]
        public bool HasMoved { get; private set; }
        [field: SerializeField]
        public bool HasAttacked { get; private set; }

        #endregion

        #region Player Status Methods
        public void SetCharacterStats(int health, ICustomDie attackDie, ICustomDie moveDie)
        {
            //TODO: Change this to a system where gamestate assigns the Player a class based on their choice earlier in the level
            PlayerClass = new WarriorClass();

            EntityName = "Player";
            MaxHealth = health;
            Health = MaxHealth;
            AttackDie = attackDie;
            MovementDie = moveDie;

        }

        public void Death()
        {

            Debug.Log("You died!");
            IsDead = true;
        }
        #endregion

        #region Player Dice Rolling Methods

        public int RollAttack()
        {

            return AttackDie.RollResult();
        }

        public int RollMovement()
        {
            TotalMovementPoints = MovementDie.RollResult();
            CurrentMovementPoints = TotalMovementPoints;
            return CurrentMovementPoints;
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