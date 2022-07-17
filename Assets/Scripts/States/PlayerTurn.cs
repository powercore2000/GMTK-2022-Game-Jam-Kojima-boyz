using System;
using System.Threading.Tasks;

namespace States
{
    public class PlayerTurn : State
    {
        
        public PlayerTurn(TurnSystem system) : base(system)
        {
            
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public override void Attack()
        {
            _turnSystem.HandleAttack(_turnSystem.PlayerStats, _turnSystem.EnemyStats);
            End();
        }

        public override void Heal()
        {
            //Add a more relveant value later
            _turnSystem.PlayerStats.Heal(2);
        }

        public override void Move()
        {
            _turnSystem.Player.Move(_turnSystem.Player.ClickedTileCenterCoords);
            
            // check conditions of game
            
           
        }

        public async void Wait()
        {
            await Waiting();
        }

        public async Task Waiting()
        {
            while (_turnSystem.Player.IsMoving)
            {
                await Task.Yield();
            }
        }
        public override void End()
        {
            _turnSystem.SetState(new EnemyTurn(_turnSystem));
        }
    }
}