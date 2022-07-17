using System.Collections.Generic;
using Core;
using UnityEngine;
using EntityStatsSystem;
using PlayerSystems;
using System;
using System.Collections;
using DiceSystem;
using UnityEngine.Events;

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

        [SerializeField]
        float stateChange;

        [SerializeField]
        UnityEvent<int,int> UpdatePlayerHealth;

        [SerializeField]
        UnityEvent<int, int> UpdateEnemyHealth;

        [SerializeField]
        UnityEvent OnPlayerWin;

        [SerializeField]
        UnityEvent OnPlayerLoose;

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
            CheckIfEntitiesLive();
        }

        public void HandleAbility()
        {
            _currentState.Ability();
        }


        public void SetState(State state)
        {
            _currentState = state;
            StartCoroutine(StateChangeDelay());
        }

        IEnumerator StateChangeDelay() {

            yield return new WaitForSeconds(stateChange);
            _currentState.Start();
        }


        public void HandleAttack(IEntity attacker, IEntity defender, Action onAttackEnd) {

            int attackValue = attacker.AttackDie.RollResult();
            int defendValue = defender.MovementDie.RollResult();
            Debug.Log($"{attackValue} vs {defendValue}");
            if (attackValue > defendValue)
            {
                defender.TakeDamage(attackValue);
                Debug.Log($"{attacker.EntityName} hurting {defender.EntityName}!");
                PlayAnimation(onAttackEnd);
            }

            else {

                onAttackEnd.Invoke();
            }
            CheckIfEntitiesLive();


        }

        void CheckIfEntitiesLive() {

            //Debug.Log("Update");
            UpdatePlayerHealth.Invoke(PlayerStats.Health, PlayerStats.MaxHealth);
            UpdateEnemyHealth.Invoke(EnemyStats.Health, EnemyStats.MaxHealth);

            if (PlayerStats.Health <= 0)
            {
                Debug.Log("You loose!");
                OnPlayerLoose.Invoke();
            }

            else if (EnemyStats.Health <= 0) {

                Debug.Log("You win!");
                OnPlayerWin.Invoke();
            }
        }

        public void PlayAnimation(Action callBack) {


            StartCoroutine(WaitForAnimation(callBack));
        }

        IEnumerator WaitForAnimation(Action callBack) {

            yield return null;

            callBack.Invoke();


        }


    }
}


