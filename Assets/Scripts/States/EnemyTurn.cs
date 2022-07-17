using System;

namespace States
{
    public class EnemyTurn : State
    {
        public EnemyTurn(TurnSystem system) : base(system)
        {
            
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public override void Attack()
        {

            _turnSystem.HandleAttack(_turnSystem.EnemyStats, _turnSystem.PlayerStats);
            End();
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
            _turnSystem.SetState(new EnemyTurn(_turnSystem));
        }
    }
}