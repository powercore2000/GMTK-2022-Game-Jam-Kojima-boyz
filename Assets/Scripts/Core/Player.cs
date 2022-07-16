using UnityEngine;



namespace Movement
{
    [RequireComponent(typeof(Movement))]
    public class Player: MonoBehaviour
    {
        private Movement _movement;
        
        public bool canPlayerMove;
    
        private void Awake()
        {
            canPlayerMove = false;
            _movement = GetComponent<Movement>();
        }

        public void Move(Vector2 newPos)
        {
            if (!canPlayerMove)
            {
                Debug.Log("It's not your turn yet");
                return;
            }
            else
            {
                _movement.Move(newPos);
                canPlayerMove = false;
                
            }
        }
        
    }
}