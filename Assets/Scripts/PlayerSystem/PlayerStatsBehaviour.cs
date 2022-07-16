using DiceSystem;
using UnityEngine;

namespace PlayerSystems
{

    public class PlayerStatsBehaviour : MonoBehaviour {

        [field: SerializeField]
        public PlayerStats PlayerStatsInstance { get; private set; }

        private void Awake()
        {
            PlayerStatsInstance = new PlayerStats();
        }
        void Start()
        {

            PlayerStatsInstance.SetCharacterStats(10, new D6_Dice(), new D6_Dice());
        }



    }

    [System.Serializable]
    public class PlayerStats
    {
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

        // Start is called before the first frame update


        public void SetCharacterStats(int health, ICustomDie attackDie, ICustomDie moveDie)
        {

            MaxHealth = health;
            Health = MaxHealth;
            AttackDie = attackDie;
            MovementDie = moveDie;

        }

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

        public void Death() {

            Debug.Log("You died!");
            IsDead = true;
        }

    }



}