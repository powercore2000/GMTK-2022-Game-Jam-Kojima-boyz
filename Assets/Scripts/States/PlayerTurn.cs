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
          
        }

        public override void Attack()
        {
            
        }

        public override void Heal()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            _turnSystem.Player.Move(_turnSystem.Player.ClickedTileCenterCoords);
            
            // check conditions of game
            
            _turnSystem.SetState(new EnemyTurn(_turnSystem));
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
            throw new NotImplementedException();
        }
    }
}