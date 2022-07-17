using UnityEngine;
using DiceSystem;
using GameStateManager;

namespace EntityStatsSystem
{
    public interface IEntity
    {
        #region Property Fields

        public string EntityName { get; }
        public int Health { get; }

        public int MaxHealth { get; }

        public bool IsDead { get; }


        public ICustomDie AttackDie { get; }

        public ICustomDie MovementDie { get; }

        public int CurrentMovementPoints { get; }

        public int TotalMovementPoints { get; }

        public bool HasMoved { get; }

        public bool HasAttacked { get; }
        #endregion

        #region Player Status Methods
        public void SetCharacterStats(int health, ICustomDie attackDie, ICustomDie moveDie);
        public void SetCharacterStats(CharacterClass playerClass,  ICustomDie attackDie, ICustomDie moveDie);
        public void Death();
        #endregion

        #region Player Dice Rolling Methods

        public int RollAttack();

        public int RollMovement();
        #endregion

        #region Player Effect Methods
        public void TakeDamage(int damage);

        public void Heal(int ammount);
        #endregion

    }




}
