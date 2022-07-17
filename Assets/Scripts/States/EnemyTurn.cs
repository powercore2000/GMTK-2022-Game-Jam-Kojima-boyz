using System;
using UnityEngine;

namespace States
{
    public class EnemyTurn : State
    {
        public EnemyTurn(TurnSystem system) : base(system)
        {
            Start();
        }

        public override void Start()
        {
           
            Attack();
        }

        public override void Attack()
        {
            _turnSystem.HandleAttack(_turnSystem.EnemyStats,_turnSystem.PlayerStats);
            _turnSystem.SetState(new PlayerTurn(_turnSystem));
        }

        public override void Heal()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            var enemies = _turnSystem.CurrentEnemy;
            enemies.Move(_turnSystem.Player.transform.position);
            // check conditions of game


            _turnSystem.SetState(new PlayerTurn(_turnSystem));
        }

        public override void End()
        {
            throw new NotImplementedException();
        }
    }
}