using System.Collections.Generic;
using Core;
using UnityEngine;
using EntityStatsSystem;

namespace States
{
    

    public class TurnSystem: MonoBehaviour
    {
        private State _currentState;
        private Enemy _enemy;
        private Player _player;
        public Player Player => _player;
        public Enemy CurrentEnemy => _enemy;

        [field: SerializeField]
        public PlayerStats PlayerStats { get; private set; }
        [field: SerializeField]
        public EnemyStats EnemyStats { get; private set; }

        private void Awake()
        {


        }

        public void GetPlayer(PlayerStats player) {

            PlayerStats = player;
        }

        public void GetEnemy(EnemyStats enemy) {

            EnemyStats = enemy;
        }

        private void Start()
        {
            SetState(new BeginState(this));
            _currentState.Start();
            Debug.Log("Current state " + _currentState.GetType());
        }
       
        public void Attack()
        {
            _currentState.Attack();
        }

        public void Heal()
        {
            _currentState.Heal();
        }
        

        public void SetState(State state)
        {
            _currentState = state;
        }


        public void HandleAttack(IEntity attacker, IEntity defender) {

            Debug.Log($"{attacker.EntityName} hurting {defender.EntityName}!");
        
        }




    }
}


