using UnityEngine;
using TurnSystem;



namespace Movement
{
    
    [RequireComponent(typeof(Movement))]
    public class Player: Entity
    {
        private TurnSystem.TurnSystem turnSystem = new TurnSystem.TurnSystem();
        private Movement _movement;
        
        
    
        private void Awake()
        {
            
            _movement = GetComponent<Movement>();
        }

        public override void Move(Vector2 newPos)
        {
            if (turnSystem.canMove)
            {
                Debug.Log(turnSystem.canMove);
                Debug.Log("It's not your turn yet");
                return;
            }
            else
            {
                _movement.Move(newPos);
                turnSystem.CanPlayerMove();
            }
        }
        
    }
}