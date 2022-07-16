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
            
            throw new NotImplementedException();
        }

        public override void Heal()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            var enemies = _turnSystem.Enemies;
            foreach (var enemy in enemies)
            {
                enemy.Move(_turnSystem.Player.transform.position);
            }
            // check conditions of game
            
            
            _turnSystem.SetState(new PlayerTurn(_turnSystem));
        }

        public override void End()
        {
            throw new NotImplementedException();
        }
    }
}