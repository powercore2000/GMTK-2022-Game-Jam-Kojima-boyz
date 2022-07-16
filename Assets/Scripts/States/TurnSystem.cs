using System.Collections.Generic;
using Core;
using UnityEngine;

namespace States
{
    

    public class TurnSystem:MonoBehaviour
    {
        private State _currentState;
        private List<Enemy> _enemies;
        private Player _player;
        public Player Player => _player;
        public List<Enemy> Enemies => _enemies;
        
        private void Awake()
        {
            // find player
            
            // find enemies
            
            
        }

        
        private void Start()
        {
            SetState(new BeginState(this));
        }

       
        public void Attack()
        {
            _currentState.Attack();;
        }

        public void Heal()
        {
            _currentState.Heal();;
        }
        

        public void SetState(State state)
        {
            _currentState = state;
        }
    }
}


