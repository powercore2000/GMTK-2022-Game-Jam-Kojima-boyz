using System.Collections.Generic;
using Core;
using UnityEngine;
using EntityStatsSystem;
using PlayerSystems;

namespace States
{
   
    public class TurnSystem: MonoBehaviour
    {
        private State _currentState;
        private Enemy _enemy;
        private Player _player;
        public Player Player => _player;
        public Enemy CurrentEnemy => _enemy;

        //[field: SerializeField]
        public PlayerStats PlayerStats { get; private set; }
       // [field: SerializeField]
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
            var player = FindObjectOfType<PlayerStatsBehaviour>();
           PlayerStats = player.PlayerStatsInstance;
           EnemyStats = FindObjectOfType<EnemyStatsBehaviour>().EntityStatsInstance;
              //Debug.Log(player);
            SetState(new BeginState(this));
        }
       
        public void Attack()
        {
            _currentState.Attack();
        }

        public void Heal()
        {
            _currentState.Heal();
        }

        public void HandleAbility()
        {
            _currentState.Ability();
        }


        public void SetState(State state)
        {
            _currentState = state;
            _currentState.Start();
        }


        public void HandleAttack(IEntity attacker, IEntity defender) {

            Debug.Log($"{attacker.EntityName} hurting {defender.EntityName}!");
        
        }




    }
}


